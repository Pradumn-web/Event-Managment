using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Event_Managment_and_Ticketing_System.Models
{
    public class DALHome
    {
        string cs = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public List<Showevent> ShowEvent()
        {
            List<Showevent> L=new List<Showevent>();
            using(SqlConnection conn = new SqlConnection(cs))
            {
                using(SqlCommand cmd = new SqlCommand("sp_showdataonhomepage", conn))
                {
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        L.Add(new Showevent
                        {
                            EventId = Convert.ToInt32(rdr["EventId"]),
                            Event_Poster = (byte[])rdr["Event_Poster"],
                            Event_title = Convert.ToString(rdr["Event_title"]),
                            Speaker_Singer = Convert.ToString(rdr["Speaker_Singer"]),
                            Location = Convert.ToString(rdr["Location"]),
                            Event_DateTime = Convert.ToDateTime(rdr["Event_DateTime"]),
                            Publish_From = Convert.ToDateTime(rdr["Publish_From"]),
                            Publish_Till = Convert.ToDateTime(rdr["Publish_Till"]),
                            Description = Convert.ToString(rdr["Description"]),
                            Duration = Convert.ToInt32(rdr["Duration"]),
                            Price = Convert.ToInt32(rdr["Price"]),
                            language = Convert.ToString(rdr["language"]),
                            category_Name = Convert.ToString(rdr["category_Name"])
                        });
                    }
                }
            }
            return L;
        }
    
    public Showevent GetElementById(int id)
        {
            Showevent s = new Showevent();
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("getElementById", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EventId", id);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        s.EventId = Convert.ToInt32(rdr["EventId"]);
                        s.Event_Poster = (byte[])rdr["Event_Poster"];
                        s.Event_title = Convert.ToString(rdr["Event_title"]);
                        s.Description = Convert.ToString(rdr["Description"]);
                        s.Event_DateTime = Convert.ToDateTime(rdr["Event_Datetime"]);
                        s.Location = Convert.ToString(rdr["Location"]);
                        s.Speaker_Singer = Convert.ToString(rdr["Speaker_Singer"]);
                        s.Publish_From = Convert.ToDateTime(rdr["Publish_From"]);
                        s.Publish_Till = Convert.ToDateTime(rdr["Publish_Till"]);
                        s.Duration = Convert.ToInt32(rdr["Duration"]);
                        s.Price = Convert.ToInt32(rdr["Price"]);
                        s.language = Convert.ToString(rdr["language"]);
                        s.category_Name = Convert.ToString(rdr["category_Name"]);
                        s.catrgoeyId = Convert.ToInt32(rdr["catrgoeyId"]);
                        
                }
                }
            }
            return s;
        }
    }
}