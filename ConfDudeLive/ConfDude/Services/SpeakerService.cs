﻿using System;
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

        public SpeakerDto AddSpeaker(SpeakerDto speaker)
        {
            var result = httpClient.PostAsJsonAsync("speakers/list", speaker).Result;
            var speakerResult = result.Content.ReadAsAsync<SpeakerDto>().Result;

            return speakerResult;
        }

        public SpeakerDto UpdateSpeaker(SpeakerDto speaker)
        {
            var result = httpClient.PutAsJsonAsync("speakers/list", speaker).Result;
            var speakerResult = result.Content.ReadAsAsync<SpeakerDto>().Result;

            return speakerResult;
        }

        public void DemoError()
        {
            var result = httpClient.GetAsync("speakers/demoerror").Result;
            result.EnsureSuccessStatusCode();
        }
    }
}
