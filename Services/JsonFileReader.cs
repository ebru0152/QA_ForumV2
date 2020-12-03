using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using QA_ForumV2.Models;

namespace QA_ForumV2.Services
{
    public class JsonFileReader
    {
        public static List<Question> ReadJson(string JsonFileName) 
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<List<Question>>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
