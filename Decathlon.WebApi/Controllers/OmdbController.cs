using Business.Library.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Decathlon.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OmdbController : ControllerBase
    {
        private readonly IOmdb _omdb;
        public OmdbController(IOmdb omdb)
        {
            _omdb = omdb;
        }
        [HttpPost("SearchMovies")]
        public async Task<string> SearchFilms(string searchText)
        {
            return await _omdb.SearchFilms(searchText);
        }
        [HttpPost("GetMovieDetailsById")]
        public async Task<string> GetFilmById(string id)
        {
            return await _omdb.GetFilmById(id);
        }
    }
}
