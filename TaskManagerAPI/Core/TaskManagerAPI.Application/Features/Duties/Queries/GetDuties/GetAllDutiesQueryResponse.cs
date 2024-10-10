using TaskManagerAPI.Domain.Entities.Identity;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Features.Duties.Queries.GetDuties
{
    public class GetAllDutiesByIdQueryResponse
    {
        public GetAllDutiesByIdQueryResponse()
        {
        }

        public Guid AppUserId { get; set; }
        public string Title { get; set; } // Görev başlığı
        public string Description { get; set; } // Görev açıklaması
        public DateTime DueDate { get; set; } // Görev bitiş tarihi
        public DutyStatus Status { get; set; } // Görev durumu (Pending, Completed, Overdue vb.)
        public AppUser AppUser { get; set; } // Görevin sahibi olan kullanıcı
    }

}
