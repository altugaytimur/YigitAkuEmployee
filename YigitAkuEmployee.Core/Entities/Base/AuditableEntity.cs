using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Core.Entities.Interfaces;

namespace YigitAkuEmployee.Core.Entities.Base
{
    public abstract class AuditableEntity: BaseEntity,ISoftDeletableEntity
    {
        public AuditableEntity()
        {
            DateCreated = DateTime.UtcNow;
        }
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        public DateTime? DateCreated { get; set; }


    }
}
