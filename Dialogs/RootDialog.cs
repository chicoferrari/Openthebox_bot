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
        private NetworkQuizDialog NetworkQuizDialog = new NetworkQuizDialog();
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
            try
            {
                var message = (string) await result;

                if (message == QuizPathOptions.GeneralOption)
                {
                    await context.Forward(new GeneralQuizDialog(), ResumeAfterQuizDialog, QuizState.Started, CancellationToken.None);
                }
                else if (message == QuizPathOptions.NetworkingOption)
                {
                    await context.Forward(NetworkQuizDialog, ResumeAfterQuizDialog, QuizState.Started, CancellationToken.None);
                }
                else
                {
                    context.Done("Rolou uma opção bem invalida.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error={0} Dialog=\"Root\"", exception.Message);
                context.Fail(exception);
            }
        }

        private async Task ResumeAfterQuizDialog(IDialogContext context, IAwaitable<object> result)
        {
            var state = (QuizState) await result;

            if (state == QuizState.Continue)
            {
                await context.Forward(NetworkQuizDialog, ResumeAfterQuizDialog, state, CancellationToken.None);
            }
            else
            {
                if (state == QuizState.Won)
                    await context.PostAsync($"Aeeee caral**! Terminou essa bagaça!");
                else
                    await context.PostAsync($"Falou, valeu, você perdeu..");
            }
        }

        private async Task ResumeAfterSupportDialog(IDialogContext context, IAwaitable<object> result)
        {
            await result;

            await context.PostAsync("Obrigado por ter pedido ajuda, mas não sei se poderemos ajudar...");

            context.Wait(MessageReceivedAsync);
        }
    }
}