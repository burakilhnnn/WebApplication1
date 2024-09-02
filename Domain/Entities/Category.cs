﻿using Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category: EntityBase
    {

        public Category() { }
        public Category( string name,int parentId)
        {
            ParentId = parentId;
            Name = name;
        }
        public  int ParentId { get; set; }
        public  string Name { get; set; }
        
    }
}
