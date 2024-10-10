using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI.Domain.Entities
{
    public enum DutyStatus
    {
        Assigned=0,
        Progress=1,
        Completed=2,
        Overdue=3
    }
}
