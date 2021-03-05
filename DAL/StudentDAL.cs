using EntityLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class StudentDAL
    {
        public static string myConnStrng = @"Data Source = (LocalDb)\ktr;Initial Catalog = Academics; Integrated Security = True";
        public DataTable Select()
        {
            SqlConnection connection = new SqlConnection(myConnStrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from student order by rollNo";
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
                string sql = "select * from Student where Name like '%" + keyword + "%' or RollNo like '%" + keyword + "%' ";
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
        public void Insert(Student student,out string _status)
        {
            SqlConnection connection = new SqlConnection(myConnStrng);
            _status = null;
            try
            {
                string sql = "insert into Student(RollNo,Name) values(@RollNo,@Name)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@RollNo", student.RollNo);
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
                    _status = "Roll No. Already assigned";
                else
                    _status = "Error occurred";
            }
            finally
            {
                connection.Close();
            }
        }
        public void Update(Student student, out string _status)
        {
            SqlConnection connection = new SqlConnection(myConnStrng);
            _status = null;
            try
            {
                string sql = "update Student set Name = @Name where StudentId=@Id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Id", student.StudentID);
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
        public void Delete(Student student,out string _status)
        {
            SqlConnection connection = new SqlConnection(myConnStrng);
            _status = null;
            try
            {
                string sql = "delete from Student where StudentId=@Id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", student.StudentID);
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
