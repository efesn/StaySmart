using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySmart
{
    internal class ViewReservationsFunction
    {
        protected SqlConnection getConnection() // mssql server ile haberleşiyoruz
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-J3UGBQS; database=Reservation_Management_System; integrated security=True";
            return con;
        }

        public DataSet getData(String query) // db'den data çekiyoruz
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(String query,String message) //db'ye insert, update, delete yapıyoruz
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("'" + message + "'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // işlem başarılıysa mesaj gösteriyoruz
        }
    }
}
