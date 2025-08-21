using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event_Managment_and_Ticketing_System.Models
{
    public class Showevent
    {
        public int EventId { get; set; }
        public HttpPostedFileBase EventImage { get; set; } 
        public byte[] Event_Poster { get; set; }           
        public string Event_title { get; set; }
        public int Price { get; set; }
        public string Speaker_Singer { get; set; }
        public string Location { get; set; }
        public string language { get; set; }
        public DateTime Event_DateTime { get; set; }
        public DateTime Publish_From { get; set; }
        public DateTime Publish_Till { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string category_Name { get; set; }
        public int catrgoeyId { get; set; }
    }
}