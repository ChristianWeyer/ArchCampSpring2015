using System;

namespace WebApis.DataAccess
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Bio { get; set; }
    }
}
