using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Core.Utilities.Results.Interfaces;

namespace YigitAkuEmployee.Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public bool IsSuccess { get; }

        public string Message { get; }
        
        //Açıklama
        public Result()
        {
            IsSuccess=false; 
            Message=string.Empty;
        }
        public Result(bool isSuccess) : this() => IsSuccess = isSuccess;
        public Result(bool isSuccess, string messsage) : this(isSuccess) => Message = Message;
      
    }
}
