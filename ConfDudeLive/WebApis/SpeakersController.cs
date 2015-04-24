using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataContracts;
using WebApis.Data_Access;

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
            using (var db = new ConferenceDbContext())
            {
                var speakers = db.Speakers.ToList();
                var speakersDto = speakers.Select(s => new SpeakerDto()
                {
                  Id  = s.Id, FirstName = s.FirstName, LastName = s.LastName
                }).ToList();

                return speakersDto;
            }
        }
    }
}
