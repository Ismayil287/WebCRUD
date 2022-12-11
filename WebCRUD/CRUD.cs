using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebCRUD
{
    public class CRUD
    {
        public static int Update(int id, string name, string age, string adress, string email)
        {
            SqlConnection conn = new SqlConnection(DataSource.DS);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Customer set CustomerName='"+name+"',Age='"+age+"',Adress='"+adress+"',Email='"+email+"' where ID='"+id+"'", conn);
            int t = cmd.ExecuteNonQuery();
            conn.Close();
            return t;
        }
        public static int Delete(int id)
        {
            SqlConnection conn = new SqlConnection(DataSource.DS);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Customer where ID='" + id + "'", conn);
            int t = cmd.ExecuteNonQuery();
            conn.Close();
            return t;
        }
    }
}