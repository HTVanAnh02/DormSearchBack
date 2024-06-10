using DormSearchBe.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Entity
{
    public class Comment : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? Message { get; set; }
        public Guid? accountId { get; set; }
        public Guid? HousesId { get; set; }
        public virtual User? Account { get; set; }
        public virtual Houses? Houses { get; set; }
        public virtual IList<CommentDescription>? commentDescriptions { get; set; }
    }
}
