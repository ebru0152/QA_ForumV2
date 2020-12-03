using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace QA_ForumV2.Models
{
    public class Question
    {
        public string Title {get; set;} = "";
        public string Description{get; set;} = "";
        public string PostTime{get; set;}      // prop's most have a set property for some reason
        public string Category {get;set;}
        public List<Comment> Comments{get;set;}

        public Question(string title, string description, string category)
        {   
            Title = title;
            Description = description;
            Category = category;
            PostTime = DateTime.Now.ToString();
            Comments = new List<Comment>();
        }
        public Question()
        {
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public List<Comment> GetAllComments()
        {
            return Comments;
        }

        public void DeleteComment(Comment comment)
        {
            GetAllComments().Remove(comment);
        }
    }
}
