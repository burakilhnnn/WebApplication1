﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public string Stock { get; set; }
        public string ProductName { get; set; }
    }
}
