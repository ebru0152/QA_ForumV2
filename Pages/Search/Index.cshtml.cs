using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QA_ForumV2.Interfaces;
using QA_ForumV2.Models;

namespace QA_ForumV2.Pages.Search
{
    public class IndexModel : PageModel
    {
        [BindProperty]public IQuestionRepository repo{get;set;}
        [BindProperty]public List<Question> SearchList{get;set;}

        public IndexModel(IQuestionRepository rep)
        {
            repo = rep;
        }
        public void OnGet(string search)
        {
            SearchList = new List<Question>();
            SearchList = repo.FilterQuestionsByTitle(search);
        }
    }
}
