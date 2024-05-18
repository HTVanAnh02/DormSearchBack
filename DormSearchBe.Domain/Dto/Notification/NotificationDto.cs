﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Dto.Notification
{
    public class NotificationDto
    {
        public Guid NotificationId { get; set; }
        public Guid HouseId { get; set; }
        public Guid UserId { get; set; }
        public string? Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime Notification_CreatedAt { get; set; }
    }
}