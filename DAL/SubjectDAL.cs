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
    public class SubjectDAL
    {
        public static string myConnStrng = @"Data Source = (LocalDb)\ktr;Initial Catalog = Academics; Integrated Security = True";
        public DataTable Select()
        {
            SqlConnection connection = new SqlConnection(myConnStrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = " select * from subject order by subjectID";
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
    }
}
