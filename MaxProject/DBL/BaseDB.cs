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
        protected abstract T GetRowByPK(object pk);
        protected abstract Task<T> GetRowByPKAsync(object pk);
        protected abstract T CreateModel(object[] row);
        protected abstract Task<T> CreateModelAsync(object[] row);
        protected abstract Task<List<T>> CreateListModelAsync(List<object[]> rows);
        protected abstract List<T> CreateListModel(List<object[]> rows);
        /// <summary> 
        /// A generic operation to retrieve ALL data from the database
        /// </summary>
        /// <returns>List of Objects</returns>
        public List<T> SelectAll()
        {
            return SelectAll("", new Dictionary<string, string>());
        }

        /// <summary> 
        /// A generic operation to retrieve data from the database
        /// </summary>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <returns>List of Objects</returns>
        public List<T> SelectAll(Dictionary<string, string> parameters)
        {
            return SelectAll("", parameters);
        }

        /// <summary> 
        /// A generic operation to retrieve data from the database.
        /// </summary>
        /// <param name="query">SQL string</param>
        /// <returns>List of Objects</returns>
        public List<T> SelectAll(string query)
        {
            return SelectAll(query, new Dictionary<string, string>());
        }

        /// <summary> 
        /// A generic operation to retrieve data from the database.
        /// </summary>
        /// <param name="query">SQL string</param>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <returns>List of Objects</returns>
        public List<T> SelectAll(string query, Dictionary<string, string> parameters)
        {
            List<object[]> list = StingListSelectAll(query, parameters);
            return CreateListModel(list);
        }

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
        /// Executes the command in query string, returning the number of rows affected.
        /// </summary>
        /// <param name="query">SQL string</param>
        /// <example>DELETE FROM Customers WHERE CustomerID = 17</example>
        /// <returns>The number of rows affected.</returns>
        protected int ExecNonQuery(string query)
        {
            if (String.IsNullOrEmpty(query))
                return 0;

            PreQuery(query);

            int rowsEffected = 0;
            try
            {
                rowsEffected = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nsql:" + cmd.CommandText);
            }
            finally
            {
                PostQuery();
            }
            return rowsEffected;
        }

        /// <summary>
        /// TESTED Executes the query, and returns the first column of the first row in the result
        /// </summary>
        /// <param name="query">SQL string</param>
        /// <returns>The first column of the first row in the result set, or a null.</returns>
        protected object ExecScalar(string query)
        {
            if (String.IsNullOrEmpty(query))
                return null;

            PreQuery(query);
            object obj = null;
            try
            {
                obj = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nsql:" + cmd.CommandText);
            }
            finally
            {
                PostQuery();
            }
            return obj;
        }


        /// <summary>
        /// insert new records in a table using INSERT Statement.
        /// </summary>
        /// <param name="keyAndValue">Dictionary (Key & Value)</param>
        /// <returns>The number of rows affected.</returns>
        protected int Insert(Dictionary<string, string> keyAndValue)
        {
            string sqlCommand = PrepareInsertQueryWithParameters(keyAndValue);
            if (sqlCommand != "")
            {
                return ExecNonQuery(sqlCommand);
            }
            return 0;
        }

        /// <summary>
        /// insert new records in a table using INSERT Statement.
        /// </summary>
        /// <param name="keyAndValue">Dictionary (Key & Value)</param>
        /// <returns>An object that includes the ID attribute from the database.</returns>
        protected object InsertGetObj(Dictionary<string, string> keyAndValue)
        {
            string sqlCommand = PrepareInsertQueryWithParameters(keyAndValue);
            if (sqlCommand != "")
            {
                sqlCommand += $" SELECT LAST_INSERT_ID();";
                object res = ExecScalar(sqlCommand);
                if (res != null)
                {
                    return GetRowByPK(res);
                }
            }
            return null;
        }

        /// <summary>
        /// Update records in a table using SQL UPDATE Statement.
        /// </summary>
        /// <param name="FildValue">Dictionary (Key & Value)</param>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <returns>The number of rows affected.</returns>
        protected int Update(Dictionary<string, string> FildValue, Dictionary<string, string> parameters)
        {
            if (FildValue == null || FildValue.Count == 0)
                return 0;

            string InKeyValue = PrepareUpdateQueryWithParameters(FildValue);
            string where = PrepareWhereQueryWithParameters(parameters);

            string sqlCommand = $"UPDATE {GetTableName()} SET {InKeyValue}  {where}";
            return ExecNonQuery(sqlCommand);
        }

        /// <summary>
        /// Delete records in a table using SQL DELETE Statement.
        /// </summary>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <returns>The number of rows affected.</returns>
        protected int Delete(Dictionary<string, string> parameters)
        {
            string where = PrepareWhereQueryWithParameters(parameters);

            string sqlCommand = $"DELETE FROM {GetTableName()} {where}";
            return ExecNonQuery(sqlCommand);
        }

        /// <summary>
        /// asynchronous version of SelectAll
        /// A generic operation to retrieve ALL data from the database.
        /// </summary>
        /// <returns>List of Objects</returns>
        public async Task<List<T>> SelectAllAsync()
        {
            return await SelectAllAsync("", new Dictionary<string, string>());
        }

        /// <summary>
        /// asynchronous version of SelectAll
        /// A generic operation to retrieve data from the database.
        /// </summary>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <returns>List of Objects</returns>
        public async Task<List<T>> SelectAllAsync(Dictionary<string, string> parameters)
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
            return await SelectAllAsync(query, new Dictionary<string, string>());
        }

        /// <summary>
        /// asynchronous version of SelectAll
        /// A generic operation to retrieve data from the database.
        /// </summary>
        /// <param name="query">SQL string</param>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <returns>List of Objects</returns>
        public async Task<List<T>> SelectAllAsync(string query, Dictionary<string, string> parameters)
        {
            List<object[]> list = await StingListSelectAllAsync(query, parameters);
            return CreateListModel(list);
        }

        /// <summary>
        /// asynchronous version of ExecNonQuery
        /// </summary>
        /// <param name="query">SQL string</param>
        /// <example>DELETE FROM Customers WHERE CustomerID = 17</example>
        /// <returns>The number of rows affected.</returns>
        protected async Task<int> ExecNonQueryAsync(string query)
        {
            if (String.IsNullOrEmpty(query))
                return 0;
            PreQuery(query);
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
                PostQuery();
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
            PreQuery(query);
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
                PostQuery();
            }
            return obj;
        }

        /// <summary>
        /// asynchronous version of Insert
        /// insert new records in a table using INSERT Statement.
        /// </summary>
        /// <param name="keyAndValue">Dictionary (Key & Value)</param>
        /// <returns>The number of rows affected.</returns>
        protected async Task<int> InsertAsync(Dictionary<string, string> keyAndValue)
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
        protected async Task<object> InsertGetObjAsync(Dictionary<string, string> keyAndValue)
        {
            string sqlCommand = PrepareInsertQueryWithParameters(keyAndValue);
            sqlCommand += $" SELECT LAST_INSERT_ID();";
            object res = await ExecScalarAsync(sqlCommand);
            if (res != null)
            {
                return GetRowByPK(res);
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
        protected async Task<int> UpdateAsync(Dictionary<string, string> FildValue, Dictionary<string, string> parameters)
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
        protected async Task<int> DeleteAsync(Dictionary<string, string> parameters)
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
        private void PreQuery(string query)
        {
            cmd.CommandText = query;
            if (DB.conn.State != System.Data.ConnectionState.Open)
                DB.conn.Open();
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
                cmd.Connection = DB.conn;
        }

        /// <summary>
        /// Make cleanup after sql command was executed
        /// </summary>
        private void PostQuery()
        {
            if (reader != null && !reader.IsClosed)
                reader?.Close();

            cmd.Parameters.Clear();
            if (DB.conn.State == System.Data.ConnectionState.Open)
                DB.conn.Close();
        }

        /// <summary>
        /// Prepare SQL Where closure from the given paremeters dictionary
        /// </summary>
        /// <param name="parameters">Dictionary (Key & Value)</param>
        /// <example>Where p1=v1 AND p2=v2</example>
        /// <returns>String of SQL Where closure</returns>
        private string PrepareWhereQueryWithParameters(Dictionary<string, string> parameters)
        {
            string where = "WHERE ";
            string AND = "AND";
            if (parameters != null && parameters.Count > 0)
            {
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    //where += $"{param.Key} = {param.Value} {AND} ";
                    string prm = $"@{param.Key}";
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
        private string PrepareUpdateQueryWithParameters(Dictionary<string, string> fields)
        {
            string InValue = "";
            if (fields != null && fields.Count > 0)
            {
                foreach (KeyValuePair<string, string> param in fields)
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
        private string PrepareInsertQueryWithParameters(Dictionary<string, string> fields)
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

        private List<object[]> StingListSelectAll(string query, Dictionary<string, string> parameters)
        {
            List<object[]> list = new List<object[]>();
            string where = PrepareWhereQueryWithParameters(parameters);
            string sqlCommand = $"{query} {where}";
            if (String.IsNullOrEmpty(query))
                sqlCommand = $"SELECT * FROM {GetTableName()} {where}";

            PreQuery(sqlCommand);
            try
            {
                reader = cmd.ExecuteReader();
                int size = reader.GetColumnSchema().Count;
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
                PostQuery();
            }
            return list;
        }

        private async Task<List<object[]>> StingListSelectAllAsync(string query, Dictionary<string, string> parameters)
        {
            List<object[]> list = new List<object[]>();
            string where = PrepareWhereQueryWithParameters(parameters);
            string sqlCommand = $"{query} {where}";
            if (String.IsNullOrEmpty(query))
                sqlCommand = $"SELECT * FROM {GetTableName()} {where}";
            PreQuery(sqlCommand);
            try
            {
                this.reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
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
                PostQuery();
            }
            return list;
        }
    }
}
