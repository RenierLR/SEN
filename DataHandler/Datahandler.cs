using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    public class DataHandler
    {
        private static string connectionString = @"Data Source=DESKTOP-43A55O7\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";
        private static string providerName = "System.Data.SqlClient";

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public DataHandler() { }

        #region ADO.net dynamic query method

        public DataTable dynamicQueries<T>(string queryType, object objectClass, KeyValuePair<string, string[,]> table)
        {
            //return dalk n Datatable. As dit insert, delete, of update is, return null

            DataTable returnTable = null;

            try
            {
                StringBuilder queryString = new StringBuilder();
                queryString.Append("SELECT ");

                for (int i = 0; i < table.Value.GetLength(0); i++)
                {
                    if (i != table.Value.GetLength(0) - 1)
                    {
                        queryString.Append(table.Value[i, 0] + ", ");
                    }
                    else
                    {
                        queryString.Append(table.Value[i, 0] + " ");
                    }
                }

                queryString.Append("FROM ");
                queryString.Append(table.Key);
                
                DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

                DbConnection connection = factory.CreateConnection();
                connection.ConnectionString = connectionString;

                // Create the DbCommand.
                DbCommand command = factory.CreateCommand();
                command.CommandText = queryString.ToString();
                command.Connection = connection;

                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

                if (queryType == "SELECT")
                {
                    // Fill the DataTable.
                    returnTable = new DataTable();
                    adapter.Fill(returnTable);

                    return returnTable;
                }

                if (queryType != "SELECT")
                {

                    // Create the DbCommandBuilder.
                    DbCommandBuilder builder = factory.CreateCommandBuilder();
                    builder.DataAdapter = adapter;

                    // Cast it to itself
                    T spesificClass = (T)Convert.ChangeType(objectClass, typeof(T));

                    if (queryType == "INSERT")
                    {
                        // Get the insert commands.
                        adapter.InsertCommand = builder.GetInsertCommand();
                        System.Diagnostics.Debug.WriteLine(adapter.InsertCommand.CommandText);

                        // Fill the DataTable.
                        returnTable = new DataTable();
                        adapter.Fill(returnTable);

                        // Insert a new row.
                        DataRow newRow = returnTable.NewRow();

                        for (int i = 0; i < table.Value.GetLength(0); i++)
                        {
                            //PropertyInfo info = spesificClass.GetType().GetProperty(table.Value[i,1]);
                            //newRow[table.Value[i, 0]] = info.GetValue(spesificClass);
                            string dbColumn = table.Value[i, 0];
                            string propName = table.Value[i, 1];
                            var value = spesificClass.GetType().GetProperty(propName).GetValue(spesificClass);
                            newRow[dbColumn] = value;
                        }

                        returnTable.Rows.Add(newRow);

                        adapter.Update(returnTable);

                        return returnTable;
                    }
                    else

                    if (queryType == "UPDATE")
                    {
                        // Get the update commands.
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        System.Diagnostics.Debug.WriteLine(adapter.UpdateCommand.CommandText);

                        // Fill the DataTable.
                        returnTable = new DataTable();
                        adapter.Fill(returnTable);

                        // Edit an existing row.
                        //DataRow[] editRow = returnTable.Select("CustomerID = 'XYZZZ'");
                        //editRow[0]["CompanyName"] = "XYZ Corporation";

                        // Update the row based on GUID
                        DataRow[] editRow = returnTable.Select(string.Format("globalUniqueID = '{0}'", spesificClass.GetType().GetProperty("GUID").GetValue(spesificClass)));
                        //editRow[0]["CompanyName"] = "XYZ Corporation";
                        for (int i = 0; i < table.Value.GetLength(0); i++)
                        {
                            editRow[0][table.Value[i, 0]] = spesificClass.GetType().GetProperty(table.Value[i, 1]).GetValue(spesificClass);
                        }

                        adapter.Update(returnTable);

                        return returnTable;

                    }
                    else

                    if (queryType == "DELETE")
                    {
                        // Get the delete commands.
                        adapter.DeleteCommand = builder.GetDeleteCommand();
                        System.Diagnostics.Debug.WriteLine(adapter.DeleteCommand.CommandText);

                        // Fill the DataTable.
                        returnTable = new DataTable();
                        adapter.Fill(returnTable);

                        // Delete a row.
                        DataRow[] deleteRow = returnTable.Select(string.Format("globalUniqueID = '{0}'", spesificClass.GetType().GetProperty("GUID").GetValue(spesificClass)));
                        foreach (DataRow row in deleteRow)
                        {
                            row.Delete();
                        }

                        adapter.Update(returnTable);

                        return returnTable;
                    }


                }


            }
            catch (Exception e)
            {
                FileHandlerTxt FHandler = new FileHandlerTxt();
                FHandler.appendDataToTextFile(new List<string> { string.Format("Exception {0} on {1}", e.Message, DateTime.UtcNow.ToLongDateString()) });
            }


            return returnTable;
        }

        #endregion

        #region Stored procedure dynamic methods

        public void nonQuery(string query, Dictionary<string, string> parameters)
        {
            connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, string> item in parameters)
                {
                    command.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }


                command.ExecuteNonQuery();

            }
            catch (SqlException se)
            {
                FileHandlerTxt FHandler = new FileHandlerTxt();
                switch (se.Number)
                {
                    case 21:
                        FHandler.appendDataToTextFile(new List<string> { string.Format("Error code 21 : Fatal SQL problem occured : {0} on {1}", se.Message, DateTime.UtcNow.ToLongDateString()) });
                        break;
                    case 53:
                        FHandler.appendDataToTextFile(new List<string> { string.Format("Error code 53 : Error establishing a database connection : {0} on {1}", se.Message, DateTime.UtcNow.ToLongDateString()) });
                        break;
                    default:
                        FHandler.appendDataToTextFile(new List<string> { string.Format("SQLException {0} on {1}", se.Message, DateTime.UtcNow.ToLongDateString()) });
                        break;
                }
            }
            catch (Exception e)
            {
                FileHandlerTxt FHandler = new FileHandlerTxt();
                FHandler.appendDataToTextFile(new List<string> { string.Format("Exception {0} on {1}", e.Message, DateTime.UtcNow.ToLongDateString()) });
            }
            finally
            {
                connection.Close();
            }

        }

        public DataTable returnQuery(string query, Dictionary<string, string> parameters)
        {
            dataTable = new DataTable();
            connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, string> item in parameters)
                {
                    command.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }


                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

            }
            catch (SqlException se)
            {
                FileHandlerTxt FHandler = new FileHandlerTxt();
                switch (se.Number)
                {
                    case 21:
                        FHandler.appendDataToTextFile(new List<string> { string.Format("Error code 21 : Fatal SQL problem occured : {0} on {1}", se.Message, DateTime.UtcNow.ToLongDateString()) });
                        break;
                    case 53:
                        FHandler.appendDataToTextFile(new List<string> { string.Format("Error code 53 : Error establishing a database connection : {0} on {1}", se.Message, DateTime.UtcNow.ToLongDateString()) });
                        break;
                    default:
                        FHandler.appendDataToTextFile(new List<string> { string.Format("SQLException {0} on {1}", se.Message, DateTime.UtcNow.ToLongDateString()) });
                        break;
                }
            }
            catch (Exception e)
            {
                FileHandlerTxt FHandler = new FileHandlerTxt();
                FHandler.appendDataToTextFile(new List<string> { string.Format("Exception {0} on {1}", e.Message, DateTime.UtcNow.ToLongDateString()) });
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

        #endregion
    }
}
