using EntityLayer;
using System;
using System.Collections.Generic;
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
        public static string myConnStrng = @"Data Source = (LocalDb)\ktr;Initial Catalog = Academics; Integrated Security = True";
        public DataTable Select()
        {
            SqlConnection connection = new SqlConnection(myConnStrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select s.StudentId, s.RollNo, s.Name, "+
                                "sem.SemesterDescription, sem.SemesterId, "+
                                "sub.SubjectId , sub.SubjectName, "+
                                "m.marksId, m.marks "+
                              "from student s "+
                              "join MarksDetails m "+
                              "on s.StudentId = m.StudentId "+
                              "join Subject sub "+
                              "on sub.SubjectID = m.SubjectID "+
                              "join Semester sem "+
                              "on sem.SemesterID = m.SemesterID "+
                              "order by s.RollNo; ";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public DataTable Select(string keyword)
        {
            SqlConnection connection = new SqlConnection(myConnStrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from(SELECT Student.StudentId,Student.RollNo, Student.Name, Semester.SemesterId, Semester.SemesterDescription, Subject.SubjectId, Subject.SubjectName, MarksDetails.MarksId, MarksDetails.Marks from MarksDetails, Student, Subject, Semester WHERE  MarksDetails.SubjectID = Subject.SubjectID AND MarksDetails.SemesterID = Semester.SemesterID AND MarksDetails.StudentID = Student.StudentID) as MyTable where  MyTable.RollNo like '%" + keyword + "%' or MyTable.Name like '%" + keyword + "%' or MyTable.SemesterDescription like '%" + keyword + "%' or MyTable.SubjectName like '%" + keyword + "%' or MyTable.Marks like '%"+keyword+"%'";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public void Insert(Marks marks, out string _status)
        {
            SqlConnection connection = new SqlConnection(myConnStrng);
            _status = null;
            try
            {
                string sql = "insert into MarksDetails values(@StudentID,@SemesterID,@SubjectID,@Marks)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@StudentID", marks.student.StudentID);
                command.Parameters.AddWithValue("@SemesterID", marks.semester.SemesterID);
                command.Parameters.AddWithValue("@SubjectID", marks.subject.SubjectID);
                command.Parameters.AddWithValue("@Marks", marks.MarksScored);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
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
                connection.Close();
            }
        }
        public void Update(Marks marks, out string _status)
        {
            SqlConnection connection = new SqlConnection(myConnStrng);
            _status = null;
            try
            {
                string sql = "update marksDetails set Marks=@Marks where MarksID=@MarksID;";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Marks", marks.MarksScored);
                command.Parameters.AddWithValue("@MarksID", marks.MarksID);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    _status = "Successfully Updated";
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
            SqlConnection connection = new SqlConnection(myConnStrng);
            _status = null;
            try
            {
                string sql = "delete from marksDetails where MarksID=@MarksID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MarksID", marks.MarksID);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    _status = "Deleted successfully";
                }
            }
            catch (Exception exception)
            {
                _status = exception.Message;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
