using DAL.NHibernateClasses;
using EntityLayer;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DAL
{
    public class StudentDAL
    {
        public List<Student> Select()
        {
            ISession session = NHibernateSession.OpenSession();
            List<Student> studentList = new List<Student>();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    studentList = session.QueryOver<Student>().OrderBy(x => x.RollNo).Asc.List<Student>().ToList();
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
            return studentList;
        }
        public List<Student> Select(string keyword)
        {
            ISession session = NHibernateSession.OpenSession();
            List<Student> students = new List<Student>();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    students = session.CreateQuery("select c  from Student c where c.Name like '%" + keyword + "%' or c.RollNo like '%" + keyword + "%'").List<Student>().ToList();
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
            return students;
        }
        public void Insert(Student student,out string _status)
        {
            _status = null;
            ISession session = NHibernateSession.OpenSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.Save(student);
                    tx.Commit();
                    if (tx.WasCommitted)
                    {
                        _status = "Successfully inserted";
                    }
                }
            }
            catch (SqlException exception)
            {
                if (exception.Number == 2627) // Unique key violation
                    _status = "Roll No. Already assigned";
                else
                    _status = "Error occurred";
            }
            finally
            {
                session.Close();
            }
        }
        public void Update(Student student, out string _status)
        {
            _status = null;
            ISession session = NHibernateSession.OpenSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var studentRecord = session.QueryOver<Student>().Where(x => x.StudentID == student.StudentID).List<Student>().ToList();
                    foreach (var stud in studentRecord)
                    {
                        if (stud.StudentID == student.StudentID)
                        {
                            stud.Name = student.Name;
                            stud.RollNo = student.RollNo;
                            session.SaveOrUpdate(stud);
                            tx.Commit();
                            if (tx.WasCommitted)
                            {
                                _status = "Successfully Updated";
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
                session.Close();
            }
        }
        public void Delete(Student student,out string _status)
        {
            _status = null;
            ISession session = NHibernateSession.OpenSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var marksRecord = session.QueryOver<Student>().Where(x => x.StudentID == student.StudentID).SingleOrDefault();
                    session.Delete(marksRecord);
                    tx.Commit();
                    if (tx.WasCommitted)
                    {
                        _status = "Successfully Deleted";
                    }
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
