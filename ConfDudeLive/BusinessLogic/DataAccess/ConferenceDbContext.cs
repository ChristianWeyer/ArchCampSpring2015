using System.Data.Entity;

namespace BusinessLogic.DataAccess
{
    public class ConferenceDbContext : DbContext
    {

        public DbSet<Speaker> Speakers{ get; set; }
    }
}
