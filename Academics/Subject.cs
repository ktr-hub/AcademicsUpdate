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
    public class Subject
    {
        public string subjectName { get; set; }
        public int subjectID { get; set; }

        public static Dictionary<string, int> subjectNameToID; 
        //Accessing subject dataTable
        public static void Select()
        {
            SqlConnection connection = new SqlConnection(Student.myConnStrng);
            DataTable table = new DataTable();
            subjectNameToID = new Dictionary<string, int>();
            try
            {
                string sql = "select * from Subject";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    subjectNameToID[reader.GetString(1)] = reader.GetInt32(0);
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
