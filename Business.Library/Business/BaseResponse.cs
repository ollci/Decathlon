using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library
{

    public class Result
    {
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }
    public class BaseResponse<T> where T : class
    {
        public Result ResultMessage { get; set; }
        public T RelatedEntity { get; set; }

    }
}
