using System;
using System.Collections.Generic;
using System.Net.Http;
using DataContracts;

namespace ConfDude.Services
{
    public class SpeakerService
    {
        private HttpClient httpClient;

        public SpeakerService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:26788/api/");
        }

        public List<SpeakerDto> GetSpeakerList()
        {
            var result = httpClient.GetAsync("speakers/list").Result;
            var speakers = result.Content.ReadAsAsync<List<SpeakerDto>>().Result;


            return speakers;
        }
    }
}
