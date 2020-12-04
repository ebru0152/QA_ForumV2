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
    public class AstrologiModel : PageModel
    {
        [BindProperty]public IQuestionRepository repo{get;set;}
        [BindProperty]public List<Question> CategoryList{get;set;}

        public AstrologiModel(IQuestionRepository rep)
        {
            repo = rep;
        }
        public void OnGet()
        {
            CategoryList = new List<Question>();
            foreach (var item in repo.GetAllQuestions())
            {
                if(item.Category == "Astrologi") CategoryList.Add(item);
            }
        }
    }
}
