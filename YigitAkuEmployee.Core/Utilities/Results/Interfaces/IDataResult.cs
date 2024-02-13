using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YigitAkuEmployee.Core.Utilities.Results.Interfaces
{
    public interface IDataResult<T>:IResult where T:class
    {
        T Data { get; }
    }
}
