using NHibernate;
using System.Web;
namespace DAL.NHibernateClasses
{
    public static class NHibernateHelper
    {
        private static readonly ISessionFactory _sessionFactory;
        private const string CurrentSessionKey = "nhibernate.current_session";
        static NHibernateHelper()
        {
            _sessionFactory = new NHibernate.Cfg.Configuration().Configure().BuildSessionFactory();
        }
        public static ISession GetCurrentSession()
        {
            var context = HttpContext.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;
            if (currentSession == null)
            {
                currentSession = _sessionFactory.OpenSession();
                context.Items[CurrentSessionKey] = currentSession;
            }
            return currentSession;
        }
        public static void CloseSession()
        {
            var context = HttpContext.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;
            if (currentSession == null)
            {
                return;
            }
            currentSession.Close();
            context.Items.Remove(CurrentSessionKey);
        }
        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }
    }
}
