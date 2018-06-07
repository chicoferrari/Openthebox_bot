using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading;
using System.Threading.Tasks;
using SimpleEchoBot.Constants;
using SimpleEchoBot.Dialogs.Quiz;

namespace SimpleEchoBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            if (message.Text.ToLower().Contains("help") || message.Text.ToLower().Contains("ajuda"))
            {
                await context.Forward(new SupportDialog(), ResumeAfterSupportDialog, message, CancellationToken.None);
            }
            else if (message.Text.ToLower().Contains("start") || message.Text.ToLower().Contains("iniciar"))
            {
                await context.Forward(new ChoiceDialog(), ResumeAfterChoiceDialog, message, CancellationToken.None);
            }
            else
            {
                await context.PostAsync("Ae... Não entendi o que você quis dizer...");
            }
        }

        private async Task ResumeAfterChoiceDialog(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result;

            if ((string) message == QuizPathOptions.GeneralOption)
            {
                await context.Forward(new GeneralQuizDialog(), ResumeAfterQuizDialog, message, CancellationToken.None);    
            }
            if ((string) message == QuizPathOptions.NetworkingOption)
            {
                await context.Forward(new NetworkQuizDialog(), ResumeAfterQuizDialog, message, CancellationToken.None);
            }
        }

        private async Task ResumeAfterQuizDialog(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync($"Aeeee caral**! Terminou essa bagaça!");

            context.Wait(MessageReceivedAsync);
        }

        private async Task ResumeAfterSupportDialog(IDialogContext context, IAwaitable<object> result)
        {
            await result;

            await context.PostAsync("Obrigado por ter pedido ajuda, mas não sei se poderemos ajudar...");

            context.Wait(MessageReceivedAsync);
        }
    }
}