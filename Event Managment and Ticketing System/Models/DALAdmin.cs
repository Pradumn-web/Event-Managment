using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Razor.Generator;

namespace Event_Managment_and_Ticketing_System.Models
{
    public class DALAdmin
    {
        string cs = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public List<Category> GetCategory()
        {
            List<Category> c= new List<Category>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd=new SqlCommand("sp_getcategory", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr= cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        c.Add(new Category
                        {
                            catrgoeyId = Convert.ToInt32(rdr["catrgoeyId"]),
                            category_Name = Convert.ToString(rdr["category_Name"])
                        });
                    }
                }
            }
            return c;
        }
        public void AddData(AddEvent a)
        {
            using(SqlConnection con=new SqlConnection(cs))
            {
                using(SqlCommand cmd= new SqlCommand("sp_AddData", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Event_Poster", a.Event_Poster);
                    cmd.Parameters.AddWithValue("@Event_title", a.Event_title);
                    cmd.Parameters.AddWithValue("@Price", a.Price);
                    cmd.Parameters.AddWithValue("@Speaker_Singer", a.Speaker_Singer);
                    cmd.Parameters.AddWithValue("@Location", a.Location);
                    cmd.Parameters.AddWithValue("@language", a.language);
                    cmd.Parameters.AddWithValue("@Event_DateTime", a.Event_DateTime);
                    cmd.Parameters.AddWithValue("@Publish_From", a.Publish_From);
                    cmd.Parameters.AddWithValue("@Publish_Till", a.Publish_Till);
                    cmd.Parameters.AddWithValue("@Duration", a.Duration);
                    cmd.Parameters.AddWithValue("@Description", a.Description);
                    cmd.Parameters.AddWithValue("@category_Id", a.category_Id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Showevent s)
        {
            using(SqlConnection con= new SqlConnection(cs))
            {
                using(SqlCommand cmd= new SqlCommand("UpdateEvent", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EventId", s.EventId);
                    cmd.Parameters.Add("@Event_Poster", SqlDbType.VarBinary).Value = (object)s.Event_Poster ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@Event_title", s.Event_title);
                    cmd.Parameters.AddWithValue("@Price", s.Price);
                    cmd.Parameters.AddWithValue("@Speaker_Singer", s.Speaker_Singer);
                    cmd.Parameters.AddWithValue("@Location", s.Location);
                    cmd.Parameters.AddWithValue("@language", s.language);
                    cmd.Parameters.AddWithValue("@Event_DateTime", s.Event_DateTime);
                    cmd.Parameters.AddWithValue("@Publish_From", s.Publish_From);
                    cmd.Parameters.AddWithValue("@Publish_Till", s.Publish_Till);
                    cmd.Parameters.AddWithValue("@Duration", s.Duration);
                    cmd.Parameters.AddWithValue("@Description", s.Description);
                    cmd.Parameters.AddWithValue("@catrgoeyId", s.catrgoeyId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("sp_deleteEvent", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EventId", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}