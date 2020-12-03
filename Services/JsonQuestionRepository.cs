using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using QA_ForumV2.Interfaces;
using QA_ForumV2.Models;

namespace QA_ForumV2.Services
{
    public class JsonQuestionRepository : IQuestionRepository
    {
        //Jeffs jsonfile
        string JsonFileName = @"C:\Users\Bruger\Source\Repos\QA_ForumV2\Data\JsonQuestions.json"; // needs fix

        //Ebrus jsonfile
        //string JsonFileName = @"C:\Users\ebrub\OneDrive\Dokumenter\GitHub\QA_Forum\QA_Test_Json\QA_Test_Json\Data\JsonQuestions.json";


        public void AddQuestion(Question q)
        {
            bool QuestionExists = false;
            List<Question> ListOfQuestions = GetAllQuestions();

            for (int i = 0; i < ListOfQuestions.Count; i++)
            {
                if(ListOfQuestions[i].Title.ToLower() == q?.Title.ToLower())
                {
                    QuestionExists = true;
                    ListOfQuestions[i] = q;
                }
            }
            if(!QuestionExists) ListOfQuestions.Add(q);
            JsonFileWritter.WriteToJson(ListOfQuestions,JsonFileName);
        }
        public void DeleteQuestion(Question q)
        {
            List<Question> ListOfQuestions = GetAllQuestions();
            ListOfQuestions.Remove(q);
            JsonFileWritter.WriteToJson(ListOfQuestions,JsonFileName);
        }

        public Question GetQuestion(string title) 
        {
            foreach (var item in GetAllQuestions())
            {
                if(item.Title.ToLower() == title.ToLower()) return item;
            }
            return new Question();
        }

        public List<Question> GetAllQuestions()
        { 
            return JsonFileReader.ReadJson(JsonFileName);
        }

        public List<Question> FilterQuestionsByTitle(string title)
        {
            List<Question> ListOfQuestions = GetAllQuestions();
            List<Question> FilteredList = new List<Question>();

            foreach (var item in ListOfQuestions)
            {
                if(item.Title.ToLower().Contains(title.ToLower())) FilteredList.Add(item);
            }
            return FilteredList;
        }
        public List<Question> FilterQuestionsByCategory(string category)
        {
            List<Question> ListOfQuestions = GetAllQuestions();
            List<Question> FilteredList = new List<Question>();

            foreach (var item in ListOfQuestions)
            {
                if(item.Category?.ToLower() == category.ToLower()) FilteredList.Add(item);
            }
            return FilteredList;
        }

        public void DeleteComment()
        {

        }
    }
}
