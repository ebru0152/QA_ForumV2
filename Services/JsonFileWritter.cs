using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using QA_ForumV2.Models;

namespace QA_ForumV2.Services
{
    public class JsonFileWritter
    {
        public static void WriteToJson(List<Question> question,string JsonFileName)
        {
            using (FileStream outputSource = File.OpenWrite(JsonFileName))
            {
                var writter = new Utf8JsonWriter(outputSource, new JsonWriterOptions
                {
                    SkipValidation = false,
                    Indented = true  
                });
                JsonSerializer.Serialize<Question[]>(writter, question.ToArray());
            }
        }
    }
}
