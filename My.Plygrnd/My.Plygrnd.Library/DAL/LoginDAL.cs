using My.Plygrnd.Library.Db;

namespace My.Plygrnd.Library.DAL
{
    public interface ILoginDAL
    {
        string Login(string username, string password);
    }

    public class LoginDAL : ILoginDAL
    {
        private readonly IDatabaseHelper databaseHelper;

        public LoginDAL(IDatabaseHelper _databaseHelper)
        {
            databaseHelper = _databaseHelper;
        }

        public string Login(string username, string password)
        {
            var parameters = new
            {
                Username = username,
                Password = password
            };

            var result = databaseHelper.ExecuteStoredProcedureWithReturnValue("usp_Login", parameters, null);

            return result;
        }
    }
}
