using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ziplink.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Visited { get; set; }
        public DateTime LastVisit { get; set; }
        public bool Enabled { get; set; }
        public string Url { get; set; }
    }
}