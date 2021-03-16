using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;
namespace DAL.NHibernateClasses
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var cfg = new NHibernate.Cfg.Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = @"Data Source=localhost;Initial Catalog=Academics;Integrated Security=true;MultipleActiveResultSets=true;";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
                x.LogSqlInConsole = true;
            });
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sessionFactory = cfg.BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            return session;
        }
    }
}
