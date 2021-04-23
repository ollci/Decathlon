using Business.Library.Interfaces;
using Business.Library.OmdbModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library.Business
{
    public class OmdbBusiness : IOmdb
    {

        public async Task<string> SearchFilms(string searchText)
        {
            HttpClient client = new HttpClient();

            
            var response = await client.GetAsync("http://www.omdbapi.com/?s=" + searchText + "&apikey=b51eb1d4");

            string responseString = response.Content.ReadAsStringAsync().Result;
            

            return responseString;

        }
        public async Task<string> GetFilmById(string id)
        {
            HttpClient client = new HttpClient();


            var response = await client.GetAsync("http://www.omdbapi.com/?i=" + id + "&apikey=b51eb1d4");

            string responseString = response.Content.ReadAsStringAsync().Result;


            return responseString;

        }
    }
}
