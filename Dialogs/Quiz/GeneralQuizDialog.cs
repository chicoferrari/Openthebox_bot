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
    public class GeneralQuizDialog : IDialog<object>
    {
        private string CorrectAnswer { get; set; }
        private int QuestionIndex { get; set; } = 0;
        private List<int> QuestionsList { get; set; } = new List<int>();
        private readonly int QuestionCount = 5;
        private Random Random = new Random();

        public void Initalize()
        {
            for (var v = 0; v < QuestionCount; v++)
            {
                QuestionsList.Add(v);
            }

            
            QuestionsList = QuestionsList.OrderBy(k => k = Random.Next(0, QuestionCount)).ToList();
        }

        public async Task StartAsync(IDialogContext context)
        {
            if (QuestionIndex == 0) Initalize();

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
                    await context.PostAsync("Dae mano? Tá errado.");
                }

                if (state != QuizState.Continue)
                {
                    QuestionIndex = 0;
                    QuestionsList.Clear();
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