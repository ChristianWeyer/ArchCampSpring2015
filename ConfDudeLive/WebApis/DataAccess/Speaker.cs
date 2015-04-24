using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApis.DataAccess
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Birthday { get; set; }
        public string Bio { get; set; }
    }
}
