using Business.Library;
using Business.Library.OmdbModels;
using Entity.Library.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library
{
    public class UserBusiness : BaseBusiness, IUser
    {
        BaseResponse<User> userResponse = null;
        public UserBusiness(DecathlonDbContext dbEntities) : base(dbEntities)
        {

        }
        public async Task<BaseResponse<User>> CreateUser(User userRequest)
        {
            try
            {
                userRequest.CreatedOn = DateTime.Now;
                userRequest.IsDeleted = false;

                _context.Users.Add(userRequest);
                await _context.SaveChangesAsync();

                userResponse = new BaseResponse<User>();
                userResponse.RelatedEntity = userRequest;
                userResponse.ResultMessage = new Result() { ErrorCode = 0, Message = "Success" };
            }
            catch (Exception ex)
            {
                userResponse.ResultMessage = new Result() { ErrorCode = -1, Message = ex.Message };
            }
            return userResponse;
        }

    }
}
