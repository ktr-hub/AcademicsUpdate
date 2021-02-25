using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academics
{
    public class Semester
    {
        public int semesterID { get; set; }
        public string semesterDescription{ get; set; }

        public static Dictionary<string, int> semesterToId;
        
        //Accessing semester dataTable
        public static void Select()
        {
            SqlConnection connection = new SqlConnection(Student.myConnStrng);
            DataTable table = new DataTable();
            semesterToId = new Dictionary<string, int>();
            try
            {
                string sql = "select * from Semester";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    semesterToId[reader.GetString(1)] = reader.GetInt32(0);
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
        }
    }
}
