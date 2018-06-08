using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using SimpleEchoBot.Constants;

namespace SimpleEchoBot.Dialogs
{
    [Serializable]
    public class ChoiceDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() { QuizPathOptions.NetworkingOption, QuizPathOptions.GeneralOption }, "Qual tipo de quiz você vai escolher?", "Escolhe um dos dois ae..", 3);
        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var optionSelected = await result;

                if (optionSelected == QuizPathOptions.NetworkingOption)
                {
                    await context.PostAsync("Ae sim quero ver você responder tudo...");
                }
                else if (optionSelected == QuizPathOptions.GeneralOption)
                {
                    await context.PostAsync("Bora responder e abrir ssápo**a...");
                }

                context.Done(optionSelected);
            }
            catch (TooManyAttemptsException ex)
            {
                Console.WriteLine("Error={0} Dialog=\"Choice\"", ex.Message);
                context.Fail(new Exception("Ooopahh! Muitas tentativas : (."));
            }
        }
    }
}