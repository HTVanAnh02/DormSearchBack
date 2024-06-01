using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Dto.Chat
{
    public class ChatMessDto
    {
        public Guid? MessagesId { get; set; }
        public string? Messages { get; set; }
        public Guid UserId { get; set; }
        public Guid? UserSend { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
    }
}
