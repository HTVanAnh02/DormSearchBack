using DormSearchBe.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Entity
{
    public class Acreage:BaseEntity
    {
        public Guid AcreageId { get; set; }
        public string Acreages { get; set; }
        public ICollection<Houses>? Houses { get; set; }
    }
}
