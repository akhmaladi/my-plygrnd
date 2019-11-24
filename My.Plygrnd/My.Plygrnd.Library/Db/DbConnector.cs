using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace My.Plygrnd.Library.Db
{
    public interface IDbConnector { IDbConnection Connect(); }

    public class DbConnector : IDbConnector
    {
        private SqlConnection sqlConnection;

        public IDbConnection Connect()
        {
            if (sqlConnection == null || sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString);
                sqlConnection.Open();
            }

            return sqlConnection;
        }
    }
}
