using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QA_ForumV2.Models
{
    public class Comment
    {
        public DateTime TimeOfPost;

        public User profile;

        public string Content{get;set;}
        public Comment(string content) // a list of normal text and code blocks will be sendt when creating a new comment
        {
            Content = content;
            TimeOfPost = DateTime.Now; // will this be called when the thread page is called
        }
        public Comment()
        {
        }
    }
}