using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Event_Managment_and_Ticketing_System.Models
{
    public class DALAccounts
    {
        string cs = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public bool CheckLogin(Accounts a)
        {
            using(SqlConnection  conn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LoginDetails", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", a.Username);
                    cmd.Parameters.AddWithValue("@Password", a.Password);
                    conn.Open();
                    SqlDataReader rdr= cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        a.Userid = Convert.ToInt32(rdr["Userid"]);
                        a.Username = Convert.ToString(rdr["Username"]);
                        return true;
                    }
                    else { 
                        return false;
                    }
                }
            }
        }
    }
}