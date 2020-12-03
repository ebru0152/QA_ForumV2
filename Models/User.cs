using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QA_ForumV2.Models
{
    public abstract class User
    {
        public bool IsMod;
        public string Name { get; set; }
        protected readonly DateTime CreationDate; 
        public int Posts { get; set; }

        public User(string name)
        {
            Name = name;
            CreationDate = DateTime.Now;
        }
    }
}
