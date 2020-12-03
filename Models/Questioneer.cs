using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QA_ForumV2.Models
{
    public class Questioneer : User
    {
        public List<Expertise> ExpertiseTags {get; }
        public Questioneer(string name) : base (name)
        {           
            IsMod = false;
            ExpertiseTags = new List<Expertise>();
        }

        // a third party should confirm their degree, which is a role we will play for simpplicity in this version
        // a user can send a application and a mod will be notified if it is valid and add a Expertise tag to them
        // if by mistake, you can remove an expertise tag
    }
}
