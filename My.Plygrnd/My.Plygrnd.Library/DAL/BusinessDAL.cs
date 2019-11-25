using My.Plygrnd.Library.Db;
using My.Plygrnd.Library.Models;
using System.Collections.Generic;

namespace My.Plygrnd.Library.DAL
{
    public interface IBusinessDAL
    {
        IList<BusinessInfo> GetBusinessInfo();
        IList<BusinessOutlet> GetBusinessOutlet(long businessId);
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

        public IList<BusinessOutlet> GetBusinessOutlet(long businessId)
        {
            var result = new List<BusinessOutlet>();

            using (var reader = databaseHelper.ReadFromStoredProcedure("[dbo].[usp_BusinessOutlet_Get]", new { BusinessId = businessId }))
            {
                while (reader.Read()) result.Add(reader.PopulateFromRow<BusinessOutlet>());
            }

            return result;
        }
    }
}
