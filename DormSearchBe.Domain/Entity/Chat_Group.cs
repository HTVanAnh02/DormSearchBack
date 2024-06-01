using DormSearchBe.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Entity
{
    public class Chat_Group:BaseEntity
    {
        public Guid Chat_Group_Id { get; set; }
        public Guid UserSend_Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
