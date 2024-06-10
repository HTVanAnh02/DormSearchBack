using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Dto.Comment
{
    public class CommentDTO
    {
        public string? message { get; set; }
        public string? houseproduct_id { get; set; }
        public string? account_id { get; set; }
    }
}
