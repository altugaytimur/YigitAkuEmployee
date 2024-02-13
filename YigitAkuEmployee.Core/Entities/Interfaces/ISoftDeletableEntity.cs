using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YigitAkuEmployee.Core.Entities.Interfaces
{
    public interface ISoftDeletableEntity: ICreatableEntity, IUpdatableEntity, IEntity
    {
        string? DeletedBy { get; set; }

        DateTime? DeletedDate { get; set; }
    }
}
