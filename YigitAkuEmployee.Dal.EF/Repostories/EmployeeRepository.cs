using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Core.DataAccess.EntitfyFramework;
using YigitAkuEmployee.Dal.Contexts;
using YigitAkuEmployee.Dal.İnt.Repostories;
using YigitAkuEmployee.Entities.DbSets;

namespace YigitAkuEmployee.Dal.EF.Repostories
{
    public class EmployeeRepository:EFBaseRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(YigitAkuDbContext context) : base(context) { }
    }
}
