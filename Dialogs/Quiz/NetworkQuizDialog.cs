using System;
using System.Collections.Generic;
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
        private List<int> QuestionsMade { get; set; } = new List<int>();

        public async Task StartAsync(IDialogContext context)
        {
            try
            {
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
                int TotalQuestions = QuizFactory.NetworkingQuestions.Count - 1;
                var questionIndex = new UniqueRandom().GetRandomExcept(0, TotalQuestions, QuestionsMade);
                var question = QuizFactory.NetworkingQuestions[questionIndex];

                QuestionsMade.Add(questionIndex);
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

                    if (QuizFactory.GeneralQuestions.Count - 1 > QuestionsMade.Count)
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