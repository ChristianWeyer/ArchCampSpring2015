using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using DataContracts;

namespace WebApis
{
    public class SpeakersController : ApiController
    {
        private ConferenceManager conferenceManager;

        public SpeakersController()
        {
            conferenceManager=new ConferenceManager();
        }

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
            return conferenceManager.GetSpeakerList();
        }

        [HttpPost]
        [ActionName("list")]
        public SpeakerDto AddSpeaker(SpeakerDto speakerDto)
        {
            return conferenceManager.AddSpeaker(speakerDto);
        }

        [HttpPut]
        [ActionName("list")]
        public SpeakerDto UpdateSpeaker(SpeakerDto speakerDto)
        {
            return conferenceManager.UpdateSpeaker(speakerDto);
        }

        [HttpGet]
        [ActionName("demoerror")]
        public void Foo()
        {
            throw new ConfDataException("Boom!");
        }
    }
}
