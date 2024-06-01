using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Dto.Chat
{
    public class ChatQuery
    {
        public Guid Chat_Group_Id { get; set; }
        public Guid UserSend_Id { get; set; }
        public Guid UserId { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }

    }
}
