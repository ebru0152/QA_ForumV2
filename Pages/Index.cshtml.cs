using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QA_ForumV2.Interfaces;
using QA_ForumV2.Models;

namespace QA_ForumV2.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IQuestionRepository repo;
        public Question Question{get;set;}
        public string QuestionInput{get;set;}
        public string QuestionDescription{get;set;}
        public string CategoryInput{get;set;}
        public string SearchInput{get;set;}
        public string CategoryFilterInput{get;set;}
        public List<Question> CurrentFilterList{get;set;}

        public IndexModel(ILogger<IndexModel> logger, IQuestionRepository rep)
        {
            _logger = logger;
            repo = rep;
        }

        public void OnGet() 
        {
            SearchInput = "";
        }

        public IActionResult OnPost()
        {
            string search = SearchInput;
            if(SearchInput != "") return RedirectToPage("Search/Index", new { search });
            Question = new Question(QuestionInput,QuestionDescription, CategoryInput); // gets error if exact title match with existing one
            repo.AddQuestion(Question);
            return RedirectToPage("/Questions/Index", new { Question.Title});
        }
    }
}
