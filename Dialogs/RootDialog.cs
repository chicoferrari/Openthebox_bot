using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading;
using System.Threading.Tasks;
using SimpleEchoBot.Constants;
using SimpleEchoBot.Dialogs.Quiz;
using SimpleEchoBot.Notifications;

namespace SimpleEchoBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private readonly NetworkQuizDialog NetworkQuizDialog = new NetworkQuizDialog();
        private readonly GeneralQuizDialog GeneralQuizDialog = new GeneralQuizDialog();
        private readonly SupportDialog SupportDialog = new SupportDialog();
        private readonly ChoiceDialog ChoiceDialog = new ChoiceDialog();
        private string Quiz { get; set; } 

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            if (message.Text.ToLower().Contains("help") || message.Text.ToLower().Contains("ajuda"))
            {
                await context.Forward(SupportDialog, ResumeAfterSupportDialog, message, CancellationToken.None);
            }
            else if (message.Text.ToLower().Contains("start") || message.Text.ToLower().Contains("iniciar"))
            {
                await context.Forward(ChoiceDialog, ResumeAfterChoiceDialog, message, CancellationToken.None);
            }
        }

        private async Task ResumeAfterChoiceDialog(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var message = (string) await result;

                Quiz = message;
                await ResumeQuiz(context, QuizState.Started);
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
                await ResumeQuiz(context, state);
            }
            else
            {
                if (state == QuizState.Won)
                {
                    Notification.SendNotification();
                    await context.PostAsync($"Aeeee caral**! Terminou essa bagaça!");
                }
                else
                {
                    await context.PostAsync($"Falou, valeu, você perdeu..");
                }
                    
            }
        }

        private async Task ResumeAfterSupportDialog(IDialogContext context, IAwaitable<object> result)
        {
            await result;

            await context.PostAsync("Obrigado por ter pedido ajuda, mas não sei se poderemos ajudar...");

            context.Wait(MessageReceivedAsync);
        }

        private async Task ResumeQuiz(IDialogContext context, QuizState state)
        {
            var quiz = (IDialog<object>) GeneralQuizDialog;
            if (Quiz == QuizPathOptions.NetworkingOption)
            {
                quiz = NetworkQuizDialog;
            }

            await context.Forward(quiz, ResumeAfterQuizDialog, QuizState.Started, CancellationToken.None);
        }
    }
}