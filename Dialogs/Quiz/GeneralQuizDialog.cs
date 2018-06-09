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
    public class GeneralQuizDialog : IDialog<object>
    {
        private string CorrectAnswer { get; set; }
        private int QuestionIndex { get; set; } = 0;
        private List<int> QuestionsList { get; set; } = new List<int>();

        public async Task StartAsync(IDialogContext context)
        {
            for (var v = 0; v < QuizFactory.GeneralQuestions.Count; v++)
            {
                QuestionsList.Add(v);
            }

            QuestionsList.OrderBy(m => new Random().Next());

            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var questionIndex = QuestionsList[QuestionIndex++];
            var question = QuizFactory.GeneralQuestions[questionIndex];

            CorrectAnswer = question.CorrectAnswer;

            PromptDialog.Choice(context, CheckAnswerAfterQuestion, question.Answers, question.Text, 
                "É o que temos pra hoje meu fio. Escolhe ae..", 3);
        }

        private async Task CheckAnswerAfterQuestion(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string optionSelected = await result;
                var state = QuizState.Lose;

                if (optionSelected == CorrectAnswer)
                {
                    await context.PostAsync("Ahh muleke, quem diria que essa por*a tá certa!");

                    if (QuizFactory.GeneralQuestions.Count - 1 > QuestionIndex)
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
                    await context.PostAsync("Dae mano? Tá errado.");
                }

                context.Done(state);
            }
            catch (TooManyAttemptsException ex)
            {
                context.Fail(new Exception("Ooopahh! Muitas tentativas : (."));
            }
        }
    }
}