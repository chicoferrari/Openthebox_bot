using Microsoft.Bot.Builder.Dialogs;
using SimpleEchoBot.Constants;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                string optionSelected = await result;

                switch (optionSelected)
                {
                    case QuizPathOptions.NetworkingOption:
                        await context.PostAsync("Ae sim quero ver você responder tudo...");
                        break;

                    case QuizPathOptions.GeneralOption:
                        await context.PostAsync("Bora responder e abrir ssápo**a...");
                        break;
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