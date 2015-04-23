using ConfDude.Models;
using System.Collections.Generic;

namespace ConfDude.Services
{
    public class SpeakerService
    {
        public Speaker GetSpeakerById(int id)
        {
            return new Speaker { FirstName = "Christian", LastName = "Weyer" };
        }

        public List<Speaker> GetSpeakerList()
        {
            return new List<Speaker>
            {
                new Speaker { FirstName = "Roland", LastName = "Speckmeier" },
                new Speaker { FirstName = "Andreas", LastName = "Straßer" },
                new Speaker { FirstName = "Martin", LastName = "Jäger" },
                new Speaker { FirstName = "Christian", LastName = "Gaal" },
                new Speaker { FirstName = "Christian", LastName = "Weyer" },
                new Speaker { FirstName = "Jörg", LastName = "Neumann" },
            };
        }
    }
}
