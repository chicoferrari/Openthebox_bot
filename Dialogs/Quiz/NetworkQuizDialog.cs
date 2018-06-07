using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;
using SimpleEchoBot.Factories;

namespace SimpleEchoBot.Dialogs.Quiz
{
    [Serializable]
    public class NetworkQuizDialog : IDialog<object>
    {
        private string CorrectAnswer { get; set; }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var question = QuizFactory.NetworkingQuestions[new Random().Next(0, QuizFactory.GeneralQuestions.Count - 1)];
            /*
            using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, context.Activity as Activity))
            {
                //Resolve scope for IBotDataStore<BotData>
                IBotDataStore<BotData> stateStore = scope.Resolve<IBotDataStore<BotData>>();

                /* Retrieve user address. Address key holds information about Bot, Channel, User and conversation */
            /*Address key = Address.FromActivity(context.Activity as Activity);

            //Load user data with the help of key
            BotData userData = await stateStore.LoadAsync(key, BotStoreType.BotPrivateConversationData, CancellationToken.None);

            userData.SetProperty<string>("correct_answer", question.CorrectAnswer);

            await stateStore.SaveAsync(key, BotStoreType.BotPrivateConversationData, userData, CancellationToken.None);
        }*/
            CorrectAnswer = question.CorrectAnswer;

            PromptDialog.Choice(context, this.CheckAnswerAfterQuestion, question.Answers, question.Text, "É o que temos pra hoje meu fio. Escolhe ae..", 3);
        }

        private async Task CheckAnswerAfterQuestion(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string optionSelected = await result;

                if (optionSelected == CorrectAnswer)
                {
                    await context.PostAsync("Você acertou seu mizeravi!");
                }
                else
                {
                    await context.PostAsync("Aee cara? Ta me tirando... ssá por*a tá errada!");
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