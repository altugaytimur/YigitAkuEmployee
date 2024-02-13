using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YigitAkuEmployee.Core.Entities.Interfaces
{
    public interface IUpdatableEntity : ICreatableEntity, IEntity
    {
        string ModifiedBy { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}
