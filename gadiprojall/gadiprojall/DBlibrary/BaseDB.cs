using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;


namespace DBlibrary
{
    public abstract class BaseDB<T> : DB
    {
        protected MySqlDataReader reader;
        protected abstract string GetTableName();
        protected abstract T GetRowByPK(object pk);
        protected abstract Task<T> GetRowByPKAsync(object pk);
        protected abstract T CreateModel(object[] row);
        protected abstract Task<T> CreateModelAsync(object[] row);
        protected abstract List<T> CreateListModel(List<object[]> rows);
        protected abstract Task<List<T>> CreateListModelAsync(List<object[]> rows);
        public object SelectAll()
        {
            List<object[]> list = (List<object[]>)StingListSelectAll("", new Dictionary<string, string>());
            return CreateListModel(list);
        }
        public object SelectAll(Dictionary<string, string> parameters)
        {
            List<object[]> list = (List<object[]>)StingListSelectAll("", parameters);
            return CreateListModel(list);
        }
        public object SelectAll(string query)
        {
            List<object[]> list = (List<object[]>)StingListSelectAll(query, new Dictionary<string, string>());
            return CreateListModel(list);
        }
        public object SelectAll(string query, Dictionary<string, string> parameters)
        {
            List<object[]> list = (List<object[]>)StingListSelectAll(query, parameters);
            return CreateListModel(list);
        }
        public async Task<List<T>> SelectAllAsync(string query)
        {
            return await SelectAllAsync(query, new Dictionary<string, string>());
        }
        public async Task<List<T>> SelectAllAsync(Dictionary<string, string> parameters)
        {
            return await SelectAllAsync("", parameters);
        }
        public async Task<List<T>> SelectAllAsync()
        {
            return await SelectAllAsync("", new Dictionary<string, string>());
        }
        public async Task<List<T>> SelectAllAsync(string query, Dictionary<string, string> parameters)
        {
            List<object[]> list = await StingListSelectAllAsync(query, parameters);
            return CreateListModel(list);
        }
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
        protected void AddParameterToCommand(string name, object value)
        {
            DbParameter p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            cmd.Parameters.Add(p);
        }
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
        private string PrepareWhereQueryWithParameters(Dictionary<string, string> parameters)
        {
            string where = "WHERE ";
            string AND = "AND";
            if (parameters != null && parameters.Count > 0)
            {
                foreach (KeyValuePair<string, string> param in parameters)
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
                
                reader = (MySqlDataReader) await cmd.ExecuteReaderAsync();
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
        protected object StingListSelectAll(string query, Dictionary<string, string> parameters)
        {
            object list = new List<object[]>();
            string where = "WHERE ";
            if (parameters != null && parameters.Count > 0)
            {
                int i = 0;
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    where += $"{param.Key} = '{param.Value}'"; //'{param.Value}'
                    i++;
                    if (i < parameters.Count)
                        where += " AND ";
                }
            }
            else
                where = "";
            string sqlCommand = $"{query} {where}";
            if (String.IsNullOrEmpty(query))
                sqlCommand = $"SELECT * FROM {GetTableName()} {where}";
            base.cmd.CommandText = sqlCommand;
            if (DB.conn.State != System.Data.ConnectionState.Open)
                DB.conn.Open();
            if (base.cmd.Connection.State != System.Data.ConnectionState.Open)
                base.cmd.Connection = DB.conn;

            try
            {
                this.reader = base.cmd.ExecuteReader();
                int size = reader.GetColumnSchema().ToArray().Length;
                object[] row;
                while (this.reader.Read())
                {
                    row = new object[size];
                    this.reader.GetValues(row);
                    ((List<object[]>)list).Add(row);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nsql:" + cmd.CommandText);
                ((List<string[]>)list).Clear();
            }
            finally
            {
                base.cmd.Parameters.Clear();
                if (reader != null) reader.Close();
                if (DB.conn.State == System.Data.ConnectionState.Open)
                    DB.conn.Close();
            }
            return list;
        }
        protected int exeNONquery(string query)
        {
            int num = -1;
            try
            {
                base.cmd.CommandText = query;
                if (DB.conn.State != System.Data.ConnectionState.Open)
                    DB.conn.Open();
                if (base.cmd.Connection.State != System.Data.ConnectionState.Open)
                    base.cmd.Connection = DB.conn;
                num = base.cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nsql:" + cmd.CommandText);
            }
            finally
            {
                base.cmd.Parameters.Clear();
                if (DB.conn.State == System.Data.ConnectionState.Open)
                    DB.conn.Close();
            }
            return num;
        }
        protected async Task<object> exeNONqueryAsync(string query)
        {
            int num = -1;
            try
            {
                base.cmd.CommandText = query;
                if (DB.conn.State != System.Data.ConnectionState.Open)
                    DB.conn.Open();
                if (base.cmd.Connection.State != System.Data.ConnectionState.Open)
                    base.cmd.Connection = DB.conn;
                num = base.cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nsql:" + cmd.CommandText);
            }
            finally
            {
                base.cmd.Parameters.Clear();
                if (DB.conn.State == System.Data.ConnectionState.Open)
                    DB.conn.Close();
            }
            return num;
        }
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
        protected async Task<object> InsertAsync(Dictionary<string, string> FindValue)
        {
            string s = $"INSERT INTO {GetTableName()} (";
            string s2 = "VALUES(";
            foreach (KeyValuePair<string, string> param in FindValue)
            {
                s += $"{param.Key}, ";
                s2 += $"'{param.Value}', ";
            }
            s = s.Remove(s.Length - 2);
            s2 = s2.Remove(s2.Length - 2);
            s += ")";
            s2 += ")";
            s += $" {s2};";
            return await exeNONqueryAsync(s);
        }
        protected int Insert(Dictionary<string, string> FindValue)
        {
            //INSERT INTO table_name (column1, column2, column3, ...)
            //VALUES(value1, value2, value3, ...);
            string s = $"INSERT INTO {GetTableName()} (";
            string s2 = "VALUES(";
            foreach (KeyValuePair<string, string> param in FindValue)
            {
                s += $"{param.Key}, ";
                s2 += $"'{param.Value}', ";
            }
            s = s.Remove(s.Length - 2);
            s2 = s2.Remove(s2.Length - 2);
            s += ")";
            s2 += ")";
            s += $" {s2};";
            return exeNONquery(s);
        }
        protected int Update(Dictionary<string, string> FildValue, Dictionary<string, string> parameters)
        {
            string query = $"UPDATE {GetTableName()} ";
            string val = "SET ";
            if (FildValue != null && FildValue.Count > 0)
            {
                int i = 0;
                foreach (KeyValuePair<string, string> param in FildValue)
                {
                    val += $"{param.Key} = '{param.Value}'";
                    i++;
                    if (i < FildValue.Count)
                        val += ", ";
                }
            }
            string where = "WHERE ";
            if (parameters != null && parameters.Count > 0)
            {
                int i = 0;
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    where += $"{param.Key} = '{param.Value}'";
                    i++;
                    if (i < parameters.Count)
                        where += " AND ";
                    else
                        where += ";";
                }
            }
            else
                where = "";
            query += val + " " + where;
            return exeNONquery(query);
        }
        protected int Delete(Dictionary<string, string> parameters)
        {
            string query = $"DELETE FROM {GetTableName()} ";
            string where = "WHERE ";
            if (parameters != null && parameters.Count > 0)
            {
                int i = 0;
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    where += $"{param.Key} = '{param.Value}'";
                    i++;
                    if (i < parameters.Count)
                        where += " AND ";
                    else
                        where += ";";
                }
            }
            else
                where = "";
            query += where;
            return exeNONquery(query);
        }
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
        protected async Task<int> DeleteAsync(Dictionary<string, string> parameters)
        {
            string where = PrepareWhereQueryWithParameters(parameters);

            string sqlCommand = $"DELETE FROM {GetTableName()} {where}";
            return await ExecNonQueryAsync(sqlCommand);
        }
    }


}
