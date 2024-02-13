using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Core.DataAccess.Interfaces;
using YigitAkuEmployee.Entities.DbSets;

namespace YigitAkuEmployee.Dal.İnt.Repostories
{
    public interface IEmployeeRepository : IAsyncRepository,
    IAsyncInsertableRepository<Employee>,
    IAsyncFindableRepository<Employee>,
    IAsyncDeleteableRepository<Employee>,
    IAsyncUpdateableRepository<Employee>,
    IAsyncTransactionRepository
    {
    }
}
