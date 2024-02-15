using DBlibrary;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBL
{
    public abstract class BaseDB<T> : DB
    {
        protected MySqlDataReader reader;
        protected abstract string GetTableName();
        //protected abstract T GetRowByPK(object pk);
        protected abstract Task<T> GetRowByPKAsync(object pk);
        protected abstract T CreateModel(object[] row);
        protected abstract Task<T> CreateModelAsync(object[] row);
        protected abstract Task<List<T>> CreateListModelAsync(List<object[]> rows);
        protected abstract List<T> CreateListModel(List<object[]> rows);


        /// <summary>
        /// Add one parameters to Transact-SQL statement.
        /// </summary>
        /// <param name="name">Parameter name example:@id</param>
        /// <param name="value">Parameter value</param>
        protected void AddParameterToCommand(string name, object value)
        {
            DbParameter p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            cmd.Parameters.Add(p);
        }

        /// <summary>
        /// asynchronous version of SelectAll
        /// A generic operation to retrieve ALL data from the database.
        /// </summary>
        /// <returns>List of Objects</returns>
       public async Task<List<T>> SelectAllAsync()
        {
            return await SelectAllAsync("", new Dictionary<string, object>());
        }

        /// <summary>
        /// asynchronous version of SelectAll
        /// A generic operation to retrieve data from the database.
        /// </summary>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <returns>List of Objects</returns>
        public async Task<List<T>> SelectAllAsync(Dictionary<string, object> parameters)
        {
            return await SelectAllAsync("", parameters);
        }

        /// <summary>
        /// asynchronous version of SelectAll
        /// A generic operation to retrieve data from the database.
        /// </summary>
        /// <param name="query">SQL string</param>
        /// <returns>List of Objects</returns>
        public async Task<List<T>> SelectAllAsync(string query)
        {
            return await SelectAllAsync(query, new Dictionary<string, object>());
        }

        /// <summary>
        /// asynchronous version of SelectAll
        /// A generic operation to retrieve data from the database.
        /// </summary>
        /// <param name="query">SQL string</param>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <returns>List of Objects</returns>
        protected async Task<List<T>> SelectAllAsync(string query, Dictionary<string, object> parameters)
        {
            List<object[]> list = await StingListSelectAllAsync(query, parameters);
            return await CreateListModelAsync(list);
        }

        /// <summary>
        /// asynchronous version of Insert
        /// insert new records in a table using INSERT Statement.
        /// </summary>
        /// <param name="keyAndValue">Dictionary (Key & Value)</param>
        /// <returns>The number of rows affected.</returns>
        protected async Task<int> InsertAsync(Dictionary<string, object> keyAndValue)
        {
            string sqlCommand = PrepareInsertQueryWithParameters(keyAndValue);
            return await ExecNonQueryAsync(sqlCommand);
        }

        /// <summary>
        /// asynchronous version of InsertGetObj
        /// insert new records in a table using INSERT Statement.
        /// </summary>
        /// <param name="keyAndValue">Dictionary (Key & Value)</param>
        /// <returns>An object that includes the ID attribute from the database.</returns>
        protected async Task<object> InsertGetObjAsync(Dictionary<string, object> keyAndValue)
        {
            string sqlCommand = PrepareInsertQueryWithParameters(keyAndValue);
            sqlCommand += $" SELECT LAST_INSERT_ID();";
            object res = await ExecScalarAsync(sqlCommand);
            if (res != null)
            {
                return (object)await GetRowByPKAsync(res);
            }
            else
                return null;
        }

        /// <summary>
        /// asynchronous version of Update
        /// Update records in a table using SQL UPDATE Statement.
        /// </summary>
        /// <param name="FildValue">Dictionary (Key & Value)</param>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <returns>The number of rows affected.</returns>
        protected async Task<int> UpdateAsync(Dictionary<string, object> FildValue, Dictionary<string, object> parameters)
        {
            string where = PrepareWhereQueryWithParameters(parameters);

            string InKeyValue = PrepareUpdateQueryWithParameters(FildValue);
            if (string.IsNullOrEmpty(InKeyValue))
                return 0;

            string sqlCommand = $"UPDATE {GetTableName()} SET {InKeyValue}  {where}";
            return await ExecNonQueryAsync(sqlCommand);
        }

        /// <summary>
        /// asynchronous version of Delete
        /// Delete records in a table using SQL DELETE Statement.
        /// </summary>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <returns>The number of rows affected.</returns>
        protected async Task<int> DeleteAsync(Dictionary<string, object> parameters)
        {
            string where = PrepareWhereQueryWithParameters(parameters);

            string sqlCommand = $"DELETE FROM {GetTableName()} {where}";
            return await ExecNonQueryAsync(sqlCommand);
        }

        /// <summary>
        /// Prepare command and Connection before executing SQL command
        /// </summary>
        /// <example>DELETE FROM Customers WHERE CustomerID = 17</example>
        /// <param name="query">SQL query string</param>
        private async Task PreQuery(string query)
        {
            cmd.CommandText = query;
            if (conn.State != System.Data.ConnectionState.Open/* && cmd != null*/)
                await conn.OpenAsync();
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
                cmd.Connection = conn;
        }
        //private void PreQuery(string query)
        //{
        //    cmd.CommandText = query;
        //    if (DB.conn.State != System.Data.ConnectionState.Open)
        //        DB.conn.Open();
        //    if (cmd.Connection.State != System.Data.ConnectionState.Open)
        //        cmd.Connection = DB.conn;
        //}
        /// <summary>
        /// Make cleanup after sql command was executed
        /// </summary>
        private async Task PostQuery()
        {
            if (reader != null && !reader.IsClosed)
                await reader.CloseAsync();

            cmd.Parameters.Clear();
            if (conn.State == System.Data.ConnectionState.Open/* && conn != null*/)
                await conn.CloseAsync();
        }

        /// <summary>
        /// Prepare SQL Where closure from the given paremeters dictionary
        /// </summary>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <example>Where p1=v1 AND p2=v2</example>
        /// <returns>String of SQL Where closure</returns>
        private string PrepareWhereQueryWithParameters(Dictionary<string, object> parameters)
        {
            string where = "WHERE ";
            string AND = "AND";
            if (parameters != null && parameters.Count > 0)
            {
                foreach (KeyValuePair<string, object> param in parameters)
                {
                    //where += $"{param.Key} = {param.Value} {AND} ";
                    string prm = $"@W{param.Key}";
                    where += $"{param.Key}={prm} {AND} ";
                    AddParameterToCommand(prm, param.Value);
                }
                where = where.Remove(where.Length - AND.Length - 2);//remove last ' AND '
            }
            else
                where = "";
            return where;
        }

        /// <summary>
        /// Prepare Update Query With Parameters
        /// </summary>
        /// <param name="fields">Dictionary (Key & Value)</param>
        /// <returns>String of SQL</returns>
        private string PrepareUpdateQueryWithParameters(Dictionary<string, object> fields)
        {
            string InValue = "";
            if (fields != null && fields.Count > 0)
            {
                foreach (KeyValuePair<string, object> param in fields)
                {
                    string prm = $"@{param.Key}";
                    InValue += $"{param.Key}={prm},";
                    AddParameterToCommand(prm, param.Value);
                }
                InValue = InValue.Remove(InValue.Length - 1); //remove last ,
            }
            return InValue;
        }

        /// <summary>
        /// Prepare Insert Query With Parameters
        /// </summary>
        /// <param name="fields">Dictionary (Key & Value)</param>
        /// <returns>String of SQL</returns>
        private string PrepareInsertQueryWithParameters(Dictionary<string, object> fields)
        {
            if (fields == null || fields.Count == 0)
                return "";

            string InKey = "(" + string.Join(",", fields.Keys) + ")";
            string InValue = "VALUES(";
            for (int i = 0; i < fields.Values.Count; i++)
            {
                string pn = "@" + i;
                InValue += pn + ',';
                AddParameterToCommand(pn, fields.Values.ElementAt(i));
            }
            InValue = InValue.Remove(InValue.Length - 1);//remove last ,
            InValue += ")";

            string sqlCommand = $"INSERT INTO {GetTableName()}  {InKey} {InValue};";
            return sqlCommand;
        }

        /// <summary>
        /// asynchronous version of ExecNonQuery
        /// </summary>
        /// <param name="query">SQL string</param>
        /// <example>DELETE FROM Customers WHERE CustomerID = 17</example>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> ExecNonQueryAsync(string query)
        {
            if (String.IsNullOrEmpty(query))
                return 0;
            await PreQuery(query);
            int rowsEffected = 0;
            try
            {
                rowsEffected = await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nsql:" + cmd.CommandText);
            }
            finally
            {
                await PostQuery();
            }
            return rowsEffected;
        }

        /// <summary>
        /// TESTED asynchronous version of ExecScalar
        /// Executes the query, and returns the first column of the first row in the result
        /// </summary>
        /// <param name="query">SQL string</param>
        /// <returns>The first column of the first row in the result set, or a null.</returns>
        protected async Task<object> ExecScalarAsync(string query)
        {
            if (String.IsNullOrEmpty(query))
                return null;
            await PreQuery(query);
            object obj = null;
            try
            {
                obj = await cmd.ExecuteScalarAsync();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nsql:" + cmd.CommandText);
            }
            finally
            {
                await PostQuery();
            }
            return obj;
        }

        private async Task<List<object[]>> StingListSelectAllAsync(string query, Dictionary<string, object> parameters)
        {
            //List<object[]> list = new List<object[]>();
            //string where = PrepareWhereQueryWithParameters(parameters);
            //string sqlCommand = $"{query} {where}";
            //if (String.IsNullOrEmpty(query))
            //    sqlCommand = $"SELECT * FROM {GetTableName()} {where}";

            //----------------------------------------
            List<object[]> list = new List<object[]>();
            string sqlCommand = "";
            if (String.IsNullOrEmpty(query))
            {
                string where = PrepareWhereQueryWithParameters(parameters);
                sqlCommand = $"SELECT * FROM {GetTableName()} {where}";
            }
            else if (query.IndexOf("@") > 0) //(query.ToLower().IndexOf("where")>0 || query.ToLower().IndexOf("limit") > 0)
            {
                sqlCommand = query;
                foreach (KeyValuePair<string, object> param in parameters)
                {
                    AddParameterToCommand($"@{param.Key}", param.Value);
                }
            }
            else
            {
                string where = PrepareWhereQueryWithParameters(parameters);
                sqlCommand = $"{query} {where}";
            }
            //----------------------------------------
            await PreQuery(sqlCommand);
            try
            {
                reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
                var readOnlyData = await reader.GetColumnSchemaAsync();
                int size = readOnlyData.Count;
                object[] row;
                while (reader.Read())
                {
                    row = new object[size];
                    reader.GetValues(row);
                    list.Add(row);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nsql:" + cmd.CommandText);
                list.Clear();
            }
            finally
            {
                await PostQuery();
            }
            return list;
        }
    }
}
