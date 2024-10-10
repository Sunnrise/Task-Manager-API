using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPI.Domain.Entities.Common;
using TaskManagerAPI.Domain.Entities.Identity;

namespace TaskManagerAPI.Domain.Entities
{
    public class Duty :EntityBase
    {
        public Guid AppUserId { get; set; }
        public string Title { get; set; } // Görev başlığı
        public string Description { get; set; } // Görev açıklaması
        public DateTime DueDate { get; set; } // Görev bitiş tarihi
        public DutyStatus Status { get; set; } // Görev durumu (Pending, Completed, Overdue vb.)
        public AppUser AppUser { get; set; } // Görevin sahibi olan kullanıcı
    }
}
