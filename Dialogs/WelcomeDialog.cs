using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleEchoBot.Dialogs
{
    [Serializable]
    public class WelcomeDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            PromptDialog.Confirm(
                context,
                AfterChoiceAsync,
                "Você gostaria de iniciar o desafio?",
                "Não entendi!",
                promptStyle: PromptStyle.Auto);
        }

        private async Task AfterChoiceAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;

            if (confirm)
            {
                context.Done("start");
            }
            else
            {
                await context.PostAsync("Porque não???????");
            }
        }
    }
}