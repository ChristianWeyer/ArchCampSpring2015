using System.Collections.Generic;
using System.Web.Http;
using DataContracts;

namespace WebHost
{
    public class SpeakersController : ApiController
    {
        [HttpGet]
        [ActionName("ping")]
        public string GetPing()
        {
            return "OK";
        }

        [HttpGet]
        [ActionName("list")]
        public List<SpeakerDto> GetSpeakers()
        {
            return new List<SpeakerDto>
            {
                new SpeakerDto { FirstName = "Roland", LastName = "Speckmeier" },
                new SpeakerDto { FirstName = "Andreas", LastName = "Straßer" },
                new SpeakerDto { FirstName = "Martin", LastName = "Jäger" },
                new SpeakerDto { FirstName = "Christian", LastName = "XXXGaal" },
                new SpeakerDto { FirstName = "Christian", LastName = "XXXWeyer" },
                new SpeakerDto { FirstName = "Jörg", LastName = "Neumann" },
            };
        }
    }
}
