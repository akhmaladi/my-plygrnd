using My.Plygrnd.Library.DAL;
using My.Plygrnd.Library.Db;
using System.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace My.Plygrnd.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IDbConnector, DbConnector>();
            container.RegisterType<IDatabaseHelper, DatabaseHelper>();
            container.RegisterType<ILoginDAL, LoginDAL>();
            container.RegisterType<IBusinessDAL, BusinessDAL>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}