using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApis.Data_Access
{
    public class ConferenceDbContext : DbContext
    {

        public DbSet<Speaker> Speakers{ get; set; }
    }
}
