using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LibraryMVpattern.Services
{
   abstract class DataBaseOprations
    {
        public abstract string StoredProcedureName { get; }
        public abstract List<KeyValue>GetSqlParameters();
        public abstract List<DataBaseOprations> ListFromDataTable(DataTable dt);

        DataBaseAccess DataBaseAccess = new DataBaseAccess();

        public bool Insert()
        {
            try
            {
                List<KeyValue> parameters = GetSqlParameters();
                parameters.Add(new KeyValue("@OperationsType", DatabaseOperationsTypes.Insert));
                return DataBaseAccess.ExcuetCommand(StoredProcedureName, parameters);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Updaet()
        {
            try
            {
                List<KeyValue> parameters = GetSqlParameters();
                parameters.Add(new KeyValue("@OperationsType", DatabaseOperationsTypes.Update));
                return DataBaseAccess.ExcuetCommand(StoredProcedureName, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Delete()
        {
            try
            {
                List<KeyValue> parameters = GetSqlParameters();
                parameters.Add(new KeyValue("@OperationsType", DatabaseOperationsTypes.Delete));
                return DataBaseAccess.ExcuetCommand(StoredProcedureName, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<DataBaseOprations> Select()
        {
            try
            {
                List<KeyValue> parameters = GetSqlParameters();
                parameters.Add(new KeyValue("@OperationsType", DatabaseOperationsTypes.Select));
                DataTable dt = DataBaseAccess.SelectData(StoredProcedureName, parameters);
                return ListFromDataTable(dt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
