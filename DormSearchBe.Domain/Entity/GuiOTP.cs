using DormSearchBe.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Entity
{
    public class GuiOTP : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? otp { get; set; }
        public Guid? Email_id { get; set; }
        public User? users { get; set; }
    }
}
