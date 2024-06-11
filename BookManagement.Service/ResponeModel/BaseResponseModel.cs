using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Service.ResponeModel
{
    public class BaseResponseModel
    {
        public int Status { get; set; }

        public string Message { get; set; }
    }

    public class FailedResponseModel : BaseResponseModel
    {
        public object? Result { get; set; }
    }

    public class SuccessResponseModel : BaseResponseModel
    {
        public object? Result { get; set; }
    }
}
