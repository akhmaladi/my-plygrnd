using My.Plygrnd.Library.Db;
using My.Plygrnd.Library.Models;
using System.Collections.Generic;

namespace My.Plygrnd.Library.DAL
{
    public interface IBusinessDAL
    {
        IList<BusinessInfo> GetBusinessInfo();
        BusinessOutlet GetBusinessOutlet(long businessId);
    }
    public class BusinessDAL : IBusinessDAL
    {
        private readonly IDatabaseHelper databaseHelper;

        public BusinessDAL(IDatabaseHelper _databaseHelper)
        {
            databaseHelper = _databaseHelper;
        }

        public IList<BusinessInfo> GetBusinessInfo()
        {
            var result = new List<BusinessInfo>();

            using (var reader = databaseHelper.ReadFromStoredProcedure("[dbo].[usp_Business_Get]", new { }))
            {
                while (reader.Read()) result.Add(reader.PopulateFromRow<BusinessInfo>());
            }

            return result;
        }

        public BusinessOutlet GetBusinessOutlet(long businessId)
        {
            var result = new BusinessOutlet();

            using (var reader = databaseHelper.ReadFromStoredProcedure("[dbo].[usp_BusinessOutlet_Get]", new { BusinessId = businessId }))
            {
                while (reader.Read())
                {
                    result.Id = (long)reader["Id"];
                    result.BusinessId = (long)reader["BusinessId"];
                    result.BranchId = reader["BranchId"].ToString();
                    result.Name = reader["Name"].ToString();
                    result.Address = reader["Address"].ToString();
                }
            }

            return result;
        }
    }
}
