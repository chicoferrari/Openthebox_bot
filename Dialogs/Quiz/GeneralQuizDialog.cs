﻿using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using SimpleEchoBot.Factories;

namespace SimpleEchoBot.Dialogs.Quiz
{
    [Serializable]
    public class GeneralQuizDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var question = QuizFactory.GeneralQuestions[new Random().Next(0, QuizFactory.GeneralQuestions.Count - 1)];
            PromptDialog.Choice(context, this.CheckAnswerAfterQuestion, question.Answers, question.Text, "É o que temos pra hoje meu fio. Escolhe ae..", 3);
        }

        private async Task CheckAnswerAfterQuestion(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string optionSelected = await result;

                if (optionSelected == "Africanas ou europeias?")
                {
                    await context.PostAsync("Você acertou seu mizeravi!");
                }
                else
                {
                    await context.PostAsync("Aee cara? Ta me tirando...");
                }

                context.Done(optionSelected);
            }
            catch (TooManyAttemptsException ex)
            {
                context.Fail(new Exception("Ooopahh! Muitas tentativas : (."));
            }
        }
    }
}