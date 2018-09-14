using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ziplink.Models;

namespace ziplink.Infrastructure
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DatabaseContext: DbContext
    {
        public DbSet<Link> Links { get; set; }
        public DatabaseContext(): base("database")
        {

        }
    }
}