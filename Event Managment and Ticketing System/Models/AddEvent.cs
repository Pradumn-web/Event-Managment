using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event_Managment_and_Ticketing_System.Models
{
    public class AddEvent
    {
        public HttpPostedFileBase EventImage { get; set; } // form se image milegi
        public byte[] Event_Poster { get; set; }           // DB me byte[] save karne ke liye
        public int Price { get; set; }
        public string Event_title { get; set; }
        public string Speaker_Singer { get; set; }
        public string Location { get; set; }
        public string language { get; set; }
        public DateTime Event_DateTime { get; set; }
        public DateTime Publish_From { get; set; }
        public DateTime Publish_Till { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public int category_Id { get; set; }
    }
}