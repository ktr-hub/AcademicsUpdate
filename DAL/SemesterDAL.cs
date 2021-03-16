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
    public class SemesterDAL
    {
        public List<Semester> Select()
        {
            ISession session = NHibernateSession.OpenSession();
            List<Semester> semesters = new List<Semester>();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    semesters = session.QueryOver<Semester>().List<Semester>().ToList();
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
            return semesters;
        }
    }
}
