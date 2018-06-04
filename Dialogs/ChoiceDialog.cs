using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleEchoBot.Dialogs
{
    [Serializable]
    public class ChoiceDialog : IDialog<string>
    {
        private const string NetworkingOption = "Redes de Computadores";
        private const string GeneralOption = "Conhecimentos Gerais";

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() { NetworkingOption, GeneralOption }, "Qual tipo de quiz você vai escolher?", "Escolhe um dos dois ae..", 3);
        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string optionSelected = await result;

                switch (optionSelected)
                {
                    case NetworkingOption:
                        await context.PostAsync("Ae sim quero ver você responder tudo...");
                        break;

                    case GeneralOption:
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