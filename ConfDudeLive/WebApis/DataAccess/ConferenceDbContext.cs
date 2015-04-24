using System.Data.Entity;

namespace WebApis.DataAccess
{
    public class ConferenceDbContext : DbContext
    {

        public DbSet<Speaker> Speakers{ get; set; }
    }
}
