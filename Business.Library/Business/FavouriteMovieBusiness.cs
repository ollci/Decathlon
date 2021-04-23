using Business.Library.Interfaces;
using Entity.Library.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library.Business
{
    public class FavouriteMovieBusiness : BaseBusiness , IFavouriteMovie
    {
        BaseResponse<FavouriteMovie> favouriteMovieResponse = null;
        public FavouriteMovieBusiness(DecathlonDbContext dbEntities) : base(dbEntities)
        {

        }
        public async Task<BaseResponse<FavouriteMovie>> CreateFavouriteMovie(FavouriteMovie favouriteMovie)
        {
            try
            {
                favouriteMovie.CreatedOn = DateTime.Now;
                favouriteMovie.IsDeleted = false;

                _context.FavouriteMovies.Add(favouriteMovie);
                await _context.SaveChangesAsync();

                favouriteMovieResponse = new BaseResponse<FavouriteMovie>();
                favouriteMovieResponse.RelatedEntity = favouriteMovie;
                favouriteMovieResponse.ResultMessage = new Result() { ErrorCode = 0, Message = "Success" };
            }
            catch (Exception ex)
            {
                favouriteMovieResponse.ResultMessage = new Result() { ErrorCode = -1, Message = ex.Message };
            }
            return favouriteMovieResponse;
        }

        public async Task<BaseResponse<IEnumerable<FavouriteMovie>>> ListFavouriteMovie(int userId)
        {
            BaseResponse<IEnumerable<FavouriteMovie>> favouriteMoviesResponse = new();
            try
            { 
                IEnumerable<FavouriteMovie> favouriteMovies = await _context.FavouriteMovies.Where(i => i.UserId == userId).ToListAsync();
               
                if (favouriteMovies != null && favouriteMovies.Count() != 0)
                {
                    favouriteMoviesResponse.ResultMessage = new Result() { ErrorCode = 0, Message = "Success" };
                    favouriteMoviesResponse.RelatedEntity = favouriteMovies;
                }

            }
            catch (Exception ex)
            {
                favouriteMoviesResponse.ResultMessage = new Result() { ErrorCode = -1, Message = ex.Message };
            }
            return favouriteMoviesResponse;
        }

        public async Task<BaseResponse<FavouriteMovie>> DeleteFavouriteMovie(int id)
        {
            try
            {
               FavouriteMovie favouriteMovie = _context.FavouriteMovies.Where(i => i.Id == id).FirstOrDefault();
                
                    favouriteMovie.IsDeleted = true;
                    await _context.SaveChangesAsync();

                    favouriteMovieResponse = new BaseResponse<FavouriteMovie>();
                    favouriteMovieResponse.ResultMessage = new Result() { ErrorCode = 0, Message = "Success" };
                    favouriteMovieResponse.RelatedEntity = favouriteMovie;
            }
            catch (Exception ex)
            {
                favouriteMovieResponse.ResultMessage = new Result() { ErrorCode = -1, Message = ex.Message };
            }
            return favouriteMovieResponse;
        }
    }
}
