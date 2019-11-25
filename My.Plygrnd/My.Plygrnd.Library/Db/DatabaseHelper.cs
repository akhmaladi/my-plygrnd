using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace My.Plygrnd.Library.Db
{
    public interface IDatabaseHelper
    {
        IDataReader ReadFromStoredProcedure(string storedProcedureName, object parameterValues);
        void ExecuteStoredProcedure(string storedProcedureName, object parameterValues, Dictionary<string, object> outputParameters = null);
        string ExecuteStoredProcedureWithReturnValue(string storedProcedureName, object parameterValues, Dictionary<string, object> outputParameters = null);
    }

    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly IDbConnector dbConnector;

        public DatabaseHelper(IDbConnector _dbConnector)
        {
            dbConnector = _dbConnector;
        }

        public IDataReader ReadFromStoredProcedure(string storedProcedureName, object parameterValues)
        {
            var type = parameterValues.GetType();
            var connection = dbConnector.Connect();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 60 * 5;
                foreach (var propertyInfo in type.GetProperties())
                    command.AddParameter(propertyInfo.Name, propertyInfo.GetValue(parameterValues));

                var result = command.ExecuteReader();
                return result;
            }
        }

        public void ExecuteStoredProcedure(string storedProcedureName, object parameterValues, Dictionary<string, object> outputParameters = null)
        {
            var type = parameterValues.GetType();
            var paramDictionary = new Dictionary<string, IDataParameter>();
            var connection = dbConnector.Connect();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 60 * 5;
                foreach (var propertyInfo in type.GetProperties())
                    command.AddParameter(propertyInfo.Name, propertyInfo.GetValue(parameterValues));

                if (outputParameters != null) CreateOutputParameters(outputParameters, command, paramDictionary);

                command.ExecuteNonQuery();

                if (outputParameters == null)
                    return;

                PopulateOutputParameterValues(outputParameters, paramDictionary);
            }
        }

        public string ExecuteStoredProcedureWithReturnValue(string storedProcedureName, object parameterValues, Dictionary<string, object> outputParameters = null)
        {
            var type = parameterValues.GetType();
            var paramDictionary = new Dictionary<string, IDataParameter>();
            var connection = dbConnector.Connect();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 60 * 5;
                foreach (var propertyInfo in type.GetProperties())
                    command.AddParameter(propertyInfo.Name, propertyInfo.GetValue(parameterValues));

                if (outputParameters != null) CreateOutputParameters(outputParameters, command, paramDictionary);

                IDbDataParameter returnValue = command.CreateParameter();
                returnValue.Direction = ParameterDirection.ReturnValue;
                returnValue.ParameterName = "@value";
                command.Parameters.Add(returnValue);

                command.ExecuteNonQuery();

                if (outputParameters == null)
                    return returnValue.Value.ToString();

                PopulateOutputParameterValues(outputParameters, paramDictionary);

                return returnValue.Value.ToString();
            }
        }

        private static void CreateOutputParameters(Dictionary<string, object> outputParameters, IDbCommand command, Dictionary<string, IDataParameter> paramDictionary)
        {
            foreach (var key in outputParameters.Keys)
            {
                var p = command.CreateParameter();
                p.ParameterName = "@" + key;
                p.Direction = ParameterDirection.Output;
                p.Size = 1000;
                command.Parameters.Add(p);
                paramDictionary.Add(key, p);
            }
        }

        private static void PopulateOutputParameterValues(Dictionary<string, object> outputParameters, Dictionary<string, IDataParameter> paramDictionary)
        {
            foreach (var key in paramDictionary.Keys)
                if (paramDictionary.ContainsKey(key) && outputParameters.ContainsKey(key))
                    outputParameters[key] = paramDictionary[key].Value;
        }
    }

}
