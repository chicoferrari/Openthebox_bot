using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using SimpleEchoBot.Constants;
using SimpleEchoBot.Factories;
using SimpleEchoBot.Utils;

namespace SimpleEchoBot.Dialogs.Quiz
{
    [Serializable]
    public class NetworkQuizDialog : IDialog<object>
    {
        private string CorrectAnswer { get; set; }
        private int QuestionIndex { get; set; } = 0;
        private List<int> QuestionsList { get; set; } = new List<int>();

        public async Task StartAsync(IDialogContext context)
        {
            try
            {
                for (var v = 0; v < QuizFactory.NetworkingQuestions.Count; v++)
                {
                    QuestionsList.Add(v);
                }

                QuestionsList.OrderBy(m => new Random().Next());

                context.Wait(MessageReceivedAsync);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error={0} Dialog=\"Network\"", exception.Message);
            }
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            try
            {
                var questionIndex = QuestionsList[QuestionIndex++];
                var question = QuizFactory.NetworkingQuestions[questionIndex];

                CorrectAnswer = question.CorrectAnswer;

                PromptDialog.Choice(context, CheckAnswerAfterQuestion, question.Answers, question.Text, 
                    "É o que temos pra hoje meu fio. Escolhe ae..", 3);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error={0} Dialog=\"Networking\"", exception.Message);
            }
        }

        private async Task CheckAnswerAfterQuestion(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string optionSelected = await result;
                var state = QuizState.Lose;

                if (optionSelected == CorrectAnswer)
                {
                    await context.PostAsync("Você acertou seu mizeravi!");

                    if (QuizFactory.NetworkingQuestions.Count - 1 > QuestionIndex)
                    {
                        state = QuizState.Continue;
                    }
                    else
                    {
                        state = QuizState.Won;
                    }
                }
                else
                {
                    await context.PostAsync("Aee cara? Ta me tirando... ssá por*a tá errada!");
                }

                context.Done(state);
            }
            catch (TooManyAttemptsException exception)
            {
                Console.WriteLine("Error={0} Dialog=\"Networking\"", exception.Message);
                context.Fail(new Exception("Ooopahh! Muitas tentativas : (."));
            }
        }
    }
}