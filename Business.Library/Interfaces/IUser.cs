using Entity.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library
{
    public interface IUser
    {
        Task<BaseResponse<User>> CreateUser(User userRequest);
    }
}
