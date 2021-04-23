using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library.Interfaces
{
    public interface IOmdb
    {

        Task<string> SearchFilms(string search);
        Task<string> GetFilmById(string id);
    }
}
