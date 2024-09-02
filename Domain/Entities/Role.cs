using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Role : EntityBase
    {
        public Role()
        {
        }

        public Role(string name, string description)
        {
            Name = name;
            Description = description;
           
        }



        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
