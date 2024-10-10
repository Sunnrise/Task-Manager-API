using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI.Domain.Entities.Common
{
    public class EntityBase : IEntityBase
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
