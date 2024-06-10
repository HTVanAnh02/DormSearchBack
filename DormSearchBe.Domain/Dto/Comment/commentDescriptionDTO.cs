using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Dto.Comment
{
    public class commentDescriptionDTO
    {
        public string? message { get; set; }
        public string? commentDescription_ID { get; set; }
        public string? commentDescriptionReps_ID { get; set; }
        public string? comment_ID { get; set; }
        public string? account_ID { get; set; }

    }
}
