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
        private Dictionary<string, string> CorrectAnswer { get; set; } = new Dictionary<string, string>();
        private Dictionary<string, int> QuestionIndex { get; set; } = new Dictionary<string, int>();
        private Dictionary<string, List<int>> QuestionsList { get; set; } = new Dictionary<string, List<int>>();
        private readonly int QuestionCount = 5;
        private readonly int QuestionTotal = QuizFactory.GeneralQuestions.Count - 1;
        private Random Random = new Random();

        public async Task StartAsync(IDialogContext context)
        {
            if (QuestionIndex[context.Activity.Conversation.Id] == 0)
            {
                for (var v = 0; v < QuestionTotal; v++)
                {
                    QuestionsList[context.Activity.Conversation.Id].Add(v);
                }

                QuestionsList[context.Activity.Conversation.Id] = QuestionsList[context.Activity.Conversation.Id].OrderBy(k => k = Random.Next(0, QuestionTotal)).ToList();
            }

            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var questionIndex = QuestionsList[context.Activity.Conversation.Id][QuestionIndex[context.Activity.Conversation.Id]++];
            var question = QuizFactory.GeneralQuestions[questionIndex];

            CorrectAnswer[context.Activity.Conversation.Id] = question.CorrectAnswer;

            PromptDialog.Choice(context, CheckAnswerAfterQuestion, question.Answers, question.Text, 
                "É o que temos pra hoje meu fio. Escolhe ae..", 3, PromptStyle.Keyboard);
        }

        private async Task CheckAnswerAfterQuestion(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string optionSelected = await result;
                var state = QuizState.Lose;

                if (optionSelected == CorrectAnswer[context.Activity.Conversation.Id])
                {
                    await context.PostAsync("Ahh muleke, quem diria que essa por*a tá certa!");

                    if (QuestionIndex[context.Activity.Conversation.Id] < QuestionCount)
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
                    QuestionIndex[context.Activity.Conversation.Id] = 0;
                    QuestionsList[context.Activity.Conversation.Id].Clear();
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