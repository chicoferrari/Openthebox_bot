using Newtonsoft.Json;
using SimpleEchoBot.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SimpleEchoBot.Factories
{
    public class QuizFactory
    {
        public QuestionModel Question { get; set; }

        public QuizFactory()
        {
            var myPath = System.Web.Hosting.HostingEnvironment.MapPath("~") + "Resources/generalQuiz.json";
            Console.WriteLine(myPath);
            Question = JsonConvert.DeserializeObject<QuestionModel>(File.ReadAllText(myPath));
        }
    }
}