using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryMVpattern.Services
{
    class DataBaseAccess
    {
        private SqlConnection sqlConnection = new SqlConnection("Server=.;Database=LlibraryDB;Integrated Security=true;");


        private void OpenConnection()
        {
            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void CloseConnection()
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private SqlCommand initCommand(string StordProc, List<KeyValue> param)
        {

            try
            {
                SqlCommand command = new SqlCommand(StordProc, sqlConnection);
                command.CommandType = CommandType.StoredProcedure;



                foreach (KeyValue item in param)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }

                return command;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public DataTable SelectData(string StordProc, List<KeyValue> param)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(initCommand(StordProc, param));
                sqlDataAdapter.Fill(dt);
                return dt;


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           

        }

        public bool ExcuetCommand(string StordProc, List<KeyValue> param)
        {

            try
            {
                OpenConnection();
                return initCommand(StordProc, param).ExecuteNonQuery() >= 0;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();

            }

        }
    }
}
