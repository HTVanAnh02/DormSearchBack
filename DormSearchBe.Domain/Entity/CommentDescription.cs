using DormSearchBe.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Entity
{
    public class CommentDescription : BaseEntity
    {
        [Key]
        public Guid? Id { get; set; }
        public string? Message { get; set; }
        public Guid? UserId { get; set; }
        public Guid? Id_Commnet { get; set; }
        public Guid? RepComment3_N { get; set; }
        public Guid? RepComment2 {  get; set; }
        public virtual CommentDescription? RepComment2s { get; set; }

        public virtual Comment? comments { get; set; }
        public virtual User? Account { get; set; }
        public virtual IList<CommentDescription>? commentDescriptions { get; set; }
    }
}
