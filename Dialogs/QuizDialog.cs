using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using SimpleEchoBot.Factories;
using SimpleEchoBot.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleEchoBot.Dialogs
{
    [Serializable]
    public class QuizDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var question = new QuizFactory().Question;
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