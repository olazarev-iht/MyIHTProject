﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.APCHardware
{
    public class ConstParamsModel
    {
        // may be delete the Id
        public Guid Id { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Step { get; set; }
    }
}
