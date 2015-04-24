using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using DataContracts;
using WebApis.DataAccess;

namespace WebApis
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
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToList();

                return speakersDto;
            }
        }

        [HttpPost]
        [ActionName("list")]
        public SpeakerDto AddSpeaker(SpeakerDto speakerDto)
        {
            using (var db = new ConferenceDbContext())
            {
                var speaker = new Speaker { FirstName = speakerDto.FirstName, LastName = speakerDto.LastName };
                db.Entry(speaker).State = EntityState.Added;
                db.SaveChanges();

                return new SpeakerDto { Id = speaker.Id, FirstName = speaker.FirstName, LastName = speaker.LastName };
            }
        }

        [HttpPut]
        [ActionName("list")]
        public SpeakerDto UpdateSpeaker(SpeakerDto speakerDto)
        {
            using (var db = new ConferenceDbContext())
            {
                var speaker = new Speaker
                {
                    Id = speakerDto.Id,
                    FirstName = speakerDto.FirstName,
                    LastName = speakerDto.LastName
                };
                db.Entry(speaker).State = EntityState.Modified;
                db.SaveChanges();

                return new SpeakerDto { Id = speaker.Id, FirstName = speaker.FirstName, LastName = speaker.LastName };
            }
        }

        [HttpGet]
        [ActionName("demoerror")]
        public void Foo()
        {
            throw new ConfDataException("Boom!");
        }
    }
}
