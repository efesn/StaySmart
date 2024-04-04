using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySmart
{
    internal class DbFunction
    {
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-J3UGBQS; database=Reservation_Management_System; integrated security=True";
            return con;
        }

        public DataSet getData(String query)
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

        public void setData(String query, String message)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("'" + message + "'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public SqlDataReader getForCombo(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }

        public bool IsValidNamePass(string username, string password, out string role)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT COUNT(*) FROM User_Table WHERE User_Name = @Username AND User_Password = @Password";
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
            {
                // Retrieve the user role
                cmd.CommandText = "SELECT UserRole FROM User_Table WHERE User_Name = @Username";
                object userRole = cmd.ExecuteScalar();
                role = (userRole != DBNull.Value) ? userRole.ToString() : string.Empty;
            }
            else
            {
                role = string.Empty;
            }
            con.Close();
            return count > 0;
        }

        public string GetUserRole(string username, string password)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT UserRole FROM User_Table WHERE User_Name = @Username AND User_Password = @Password";
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            object userRole = cmd.ExecuteScalar();
            con.Close();
            return (userRole != DBNull.Value) ? userRole.ToString() : string.Empty;
        }

        public DataTable GetReservationData(string userEmail)
        {
            DataTable reservationData = new DataTable();

            try
            {
                using (SqlConnection con = getConnection())
                {
                    con.Open();
                    string query = "SELECT * FROM New_Reservation WHERE customerEmail = @UserEmail";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(reservationData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching reservation data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return reservationData;
        }

        public int GetPlaceCount()
        {
            int count = 0;
            try
            {
                using (SqlConnection con = getConnection())
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Add_Place";
                    SqlCommand cmd = new SqlCommand(query, con);
                    count = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching place count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }

        public int GetReservationCount()
        {
            int count = 0;
            try
            {
                using (SqlConnection con = getConnection())
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM New_Reservation";
                    SqlCommand cmd = new SqlCommand(query, con);
                    count = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching reservation count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }



    }
}
