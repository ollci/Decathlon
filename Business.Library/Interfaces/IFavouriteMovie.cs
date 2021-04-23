using Entity.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library.Interfaces
{
    public interface IFavouriteMovie
    {
        Task<BaseResponse<FavouriteMovie>> CreateFavouriteMovie(FavouriteMovie favouriteMovie);
        Task<BaseResponse<IEnumerable<FavouriteMovie>>> ListFavouriteMovie(int userId);
        Task<BaseResponse<FavouriteMovie>> DeleteFavouriteMovie(int id);
    }
}
