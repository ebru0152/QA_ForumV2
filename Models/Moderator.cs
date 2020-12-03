using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QA_ForumV2.Models
{
    public class Moderator : User
    {
        public Moderator(string name) : base(name) // can a mod have expertise?? and then can he give it to himself? obviously you give mod to people you trust and if he has 10 tags he is obviously trolling
        {
            IsMod = true;
        }

        public void AddExpertiseTag(Questioneer questioneer, Expertise expertise)
        {
            questioneer.ExpertiseTags.Add(expertise);
        }

        public void RemoveExpertise(Questioneer questioneer, Expertise expertise) 
        { 
            questioneer.ExpertiseTags.Remove(expertise);
        }
    }
}
