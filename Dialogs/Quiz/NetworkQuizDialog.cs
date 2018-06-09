using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using SimpleEchoBot.Constants;
using SimpleEchoBot.Factories;

namespace SimpleEchoBot.Dialogs.Quiz
{
    [Serializable]
    public class NetworkQuizDialog : IDialog<object>
    {
        private string CorrectAnswer { get; set; }
        private int QuestionIndex { get; set; } = 0;
        private List<int> QuestionsList { get; set; } = new List<int>();
        private readonly int QuestionCount = 5;
        private readonly int QuestionTotal = QuizFactory.NetworkingQuestions.Count - 1;
        private Random Random = new Random();
        public void Initalize()
        {
            for (var v = 0; v < QuestionTotal; v++)
            {
                QuestionsList.Add(v);
            }

            QuestionsList = QuestionsList.OrderBy(k => k = Random.Next(0, QuestionTotal)).ToList();
        }

        public async Task StartAsync(IDialogContext context)
        {
            try
            {
                if (QuestionIndex == 0) Initalize();

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

                    if (QuestionIndex < QuestionCount)
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

                if (state != QuizState.Continue)
                {
                    QuestionIndex = 0;
                    QuestionsList.Clear();
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