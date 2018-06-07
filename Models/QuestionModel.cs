using System.Collections.Generic;

namespace SimpleEchoBot.Models
{
    public class QuestionModel
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public string CorrectAnswer { get; set; }
    }
}