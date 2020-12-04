using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QA_ForumV2.Interfaces;
using QA_ForumV2.Models;

namespace QA_ForumV2.Pages.Questions
{
    public class IndexModel : PageModel
    {
        [BindProperty]public Question CurrentQuestion{get;set;}
        private IQuestionRepository repo;
        [BindProperty]public string Input {get;set;}

        public IndexModel(IQuestionRepository rep)
        {
            repo = rep;
        }
        public void OnGet(string title)
        {
            CurrentQuestion = repo.GetQuestion(title);
        }

        public IActionResult OnPost(string input)
        {
            Question current = repo.GetQuestion(CurrentQuestion.Title); // remember to write it to storage
            Comment comment = new Comment(input);
            current.AddComment(comment);
            repo.AddQuestion(current);
            return RedirectToPage("Index", new { CurrentQuestion.Title });
        }

        public List<Comment> GetComments(){return CurrentQuestion.GetAllComments();}
    }
}
