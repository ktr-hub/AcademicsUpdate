using DAL.NHibernateClasses;
using EntityLayer;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class SubjectDAL
    {
       public List<Subject> Select()
        {
            ISession session = NHibernateSession.OpenSession();
            List<Subject> subjects = new List<Subject>();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var subjectList = session.QueryOver<Subject>().List<Subject>().ToList();
                    return subjectList;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                session.Close();
            }
            return subjects;
        }
    }
}
