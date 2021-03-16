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
    public class MarksDAL
    {
        public static string myConnStrng = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

        public List<Marks> Select()
        {
            List<Marks> marksEntities = new List<Marks>();
            ISession session = NHibernateSession.OpenSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    marksEntities = session.QueryOver<Marks>().List<Marks>().ToList();
                    return marksEntities;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                //session.Close();
            }
            return marksEntities;
        }
        public List<Marks> Select(string keyword)
        {
            ISession session = NHibernateSession.OpenSession();
            List<Marks> marksEntities = new List<Marks>();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    marksEntities = session.CreateQuery("select c  from Marks c where c.student.Name like '%" + keyword + "%' or c.student.RollNo like '%" + keyword + "%' or c.subject.SubjectName like '%" + keyword + "%' or c.semester.SemesterDescription like '%" + keyword + "%' or c.MarksScored like '%" + keyword + "%'").List<Marks>().ToList();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                //session.Close();
            }
            return marksEntities;
        }
        public void Insert(Marks marks, out string _status)
        {
            ISession session = NHibernateSession.OpenSession();
            _status = null;
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.Save(marks);
                    tx.Commit();
                    if (tx.WasCommitted)
                        _status = "Successfully inserted";
                }
            }
            catch (SqlException exception)
            {
                if (exception.Number == 2627) // Unique key violation
                    _status = "Marks Already entered";
                else
                    _status = "Error occurred";
            }
            finally
            {
                session.Close();
            }
        }
        public void Update(Marks marks, out string _status)
        {
            SqlConnection connection = new SqlConnection(myConnStrng);
            _status = null;
            try
            {
                ISession session = NHibernateSession.OpenSession();
                List<Marks> marksRecord = new List<Marks>();
                using (ITransaction tx = session.BeginTransaction())
                {
                    marksRecord = session.QueryOver<Marks>().Where(x => x.MarksID == marks.MarksID).List<Marks>().ToList();
                    foreach (var mark in marksRecord)
                    {
                        if (mark.MarksID == marks.MarksID)
                        {
                            mark.MarksScored = marks.MarksScored;
                            session.SaveOrUpdate(mark);
                            tx.Commit();
                            if (tx.WasCommitted)
                            {
                                _status = "Updated Successfully";
                                break;
                            }
                        }
                    }
                }
            }
            catch (SqlException exception)
            {
                _status = exception.Message;
            }
            finally
            {
                connection.Close();
            }
        }
        public void Delete(Marks marks, out string _status)
        {
            ISession session = NHibernateSession.OpenSession();
            _status = null;
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var marksRecord = session.QueryOver<Marks>().Where(x => x.MarksID == marks.MarksID).SingleOrDefault();
                    session.Delete(marksRecord);
                    tx.Commit();
                    if (tx.WasCommitted)
                        _status = "Deleted successfully";
                }
            }
            catch (Exception exception)
            {
                _status = exception.Message;
            }
            finally
            {
                session.Close();
            }
        }
    }
}
