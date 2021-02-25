using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
namespace Academics
{
    public class Marks
    {
        public int MarksID { get; set; }
        public Student student;
        public Subject subject;
        public Semester semester;
        public int marks{ get; set; }
        public Marks()
        {
            student = new Student();
            subject = new Subject();
            semester = new Semester();
        }
        // ADO operations on Marks table
        static string myConnectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        public static DataTable Select()
        {
            SqlConnection connection = new SqlConnection(myConnectionString);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select s.StudentId, s.RollNo, s.Name, " +
                                "sem.SemesterDescription, sem.SemesterId, "+
                                "sub.SubjectId , sub.SubjectName, "+
                                "m.marksId, m.marks "+
                                  "from student s "+
                                  "join MarksDetails m "+
                                  "on s.StudentId = m.StudentId "+
                                  "join Subject sub "+
                                  "on sub.SubjectID = m.SubjectID "+
                                  "join Semester sem "+
                                  "on sem.SemesterID = m.SemesterID "; 
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

        public bool Insert()
        {
            bool isSuccess = false;

            SqlConnection connection = new SqlConnection(myConnectionString);
            try
            {
                string sql = "insert into marksDetails values(@studentId,@semId,@subId,@marks)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@studentId", this.student.StudentID);
                command.Parameters.AddWithValue("@subId",this.subject.subjectID);
                command.Parameters.AddWithValue("@semId", this.semester.semesterID);
                command.Parameters.AddWithValue("@marks", this.marks);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
            }
            catch(SqlException Exception)
            {
                if (Exception.Number == 2627) // Unique key Violation
                {
                    MessageBox.Show("Data already exist. Try to update");
                }
                else
                {
                    MessageBox.Show("Sql Constraint error");
                }
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;
        }

        public bool Update()
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(myConnectionString);
            try
            {
                string sql = "update marksDetails set Marks=@marks where marksId=@marksId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@marksId", this.MarksID);
                command.Parameters.AddWithValue("@marks", this.marks);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;
        }

        public bool Delete()
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(myConnectionString);
            try
            {
                string sql = "delete from marksDetails where marksId=@marksId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@marksId", this.MarksID);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;
        }

    }
}
