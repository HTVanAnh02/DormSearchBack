﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Domain.Dto.Otp
{
    public class updatePassword
    {
        public string? email { get; set; }
        public string? password { get; set; }
        public string? token { get; set; }
    }
}
