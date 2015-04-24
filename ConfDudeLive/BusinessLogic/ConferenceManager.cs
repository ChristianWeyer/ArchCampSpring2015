using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BusinessLogic.DataAccess;
using DataContracts;

namespace BusinessLogic
{
    public class ConferenceManager
    {
        public List<SpeakerDto> GetSpeakerList()
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
    }
}
