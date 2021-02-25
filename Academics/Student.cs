using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Academics
{
    public class Student
    {
        // Data of a student
        public int StudentID { get; set; }
        public int RollNo { get; set; }
        public String Name { get; set; }

        public static Dictionary<int, int> rollToId;

        // ADO operations on Student table
        public static string myConnStrng = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        
        public static DataTable Select()
        {
            SqlConnection connection = new SqlConnection(myConnStrng);
            DataTable dt = new DataTable();
            SqlDataReader reader = null;
            rollToId = new Dictionary<int, int>();
            try
            {
                string sql = "select * from student";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dt); 
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rollToId[reader.GetInt32(1)]= reader.GetInt32(0);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
            return dt;
        }
        public bool Insert()
        {
            bool isSuccess = false;

            SqlConnection connection = new SqlConnection(myConnStrng);
            try
            {
                string sql = "insert into Student(RollNo,Name) values(@RollNo,@Name)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", this.Name);
                command.Parameters.AddWithValue("@RollNo", this.RollNo);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
            }
            catch (SqlException exception)
            {
                if (exception.Number == 2627) // Unique key violation
                    MessageBox.Show("Roll No. Already assigned");
                else
                    MessageBox.Show("Sql Constraint error");
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
            SqlConnection connection = new SqlConnection(myConnStrng);
            try
            {
                string sql = "update Student set Name = @Name where StudentId=@Id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", this.Name);
                command.Parameters.AddWithValue("@Id", this.StudentID);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
            }
            catch (SqlException exception)
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
            SqlConnection connection = new SqlConnection(myConnStrng);
            try
            {
                string sql = "delete from Student where RollNo = @Roll and Name=@name";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Roll", this.RollNo);
                command.Parameters.AddWithValue("@name", this.Name);
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
