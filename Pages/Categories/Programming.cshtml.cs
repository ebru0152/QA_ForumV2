using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QA_ForumV2.Models;
using QA_ForumV2.Interfaces;

namespace QA_ForumV2.Categories
{
    public class ProgrammingModel : PageModel
    {
        [BindProperty]public IQuestionRepository repo{get;set;}
        [BindProperty]public List<Question> CategoryList{get;set;}

        public ProgrammingModel(IQuestionRepository rep)
        {
            repo = rep;
        }
        public void OnGet()
        {
            CategoryList = new List<Question>();
            foreach (var item in repo.GetAllQuestions())
            {
                if(item.Category == "Programming") CategoryList.Add(item);
            }
        }
    }
}
