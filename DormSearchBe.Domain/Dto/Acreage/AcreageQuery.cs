﻿using DormSearchBe.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Dto.Acreage
{
    public class AcreageQuery:BaseEntity
    {
        public Guid AcreageId { get; set; }
        public string Acreages { get; set; }
    }
}
