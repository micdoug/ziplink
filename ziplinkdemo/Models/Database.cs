using MySql.Data.Entity;
using System.Data.Entity;

namespace ziplinkdemo.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Database: DbContext
    {
        public DbSet<Link> Links { get; set; }

        public Database(): base("database")
        {
        }
    }
}