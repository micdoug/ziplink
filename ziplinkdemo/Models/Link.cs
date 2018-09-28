using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ziplinkdemo.Models
{
    [Table("links")]
    public class Link
    {
        [Column("id")]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Visits { get; set; }
        public DateTime? LastVisit { get; set; }
        public bool Enabled { get; set; }
        public string Url { get; set; }
    }
}