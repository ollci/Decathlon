using Business.Library;
using Business.Library.Interfaces;
using Entity.Library.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Decathlon.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteMovieController : ControllerBase
    {
        private readonly IFavouriteMovie _favouriteMovie;
        public FavouriteMovieController(IFavouriteMovie favouriteMovie)
        {
            _favouriteMovie = favouriteMovie;
        }

        [HttpPost("CreateFavouriteMovie")]
        public async Task<BaseResponse<FavouriteMovie>> CreateFavouriteMovie(FavouriteMovie favouriteMovie)
        {
            return await _favouriteMovie.CreateFavouriteMovie(favouriteMovie);
        }
        [HttpPost("ListFavouriteMovies")]
        public async Task<BaseResponse<IEnumerable<FavouriteMovie>>> ListFavouriteMovie(int userId)
        {
            return await _favouriteMovie.ListFavouriteMovie(userId);
        }
        [HttpPost("DeleteFavouriteMovie")]
        public async Task<BaseResponse<FavouriteMovie>> DeleteFavouriteMovie(int id)
        {
            return await _favouriteMovie.DeleteFavouriteMovie(id);
        }
    }
}
