using DormSearchBe.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Entity
{
    public class Notification : BaseEntity
    {
        public Guid NotificationId { get; set; }
        public Guid? HouseId { get; set; }
        public Guid? UserId { get; set; }
        public string? Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime Notification_CreatedAt { get; set; }
        public User? User { get; set; }
        public Houses? Houses { get; set; }
        public Notification()
        {
            IsRead = false;
            createdAt = DateTime.Today.AddDays(1).AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);
        }
    }
}
