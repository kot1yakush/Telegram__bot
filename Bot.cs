using System;
using Telegram;
using Telegram__bot;
using Telegram.Bots.Extensions.Polling;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram__bot
{
    class Bot
    {
        private static string token { get; set; } = "5029966475:AAFFninG7674EspG-mk236FX_VAniFKAp0c";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += smsInBot;
            Console.ReadLine();

            client.StopReceiving();
        }

        private static async void smsInBot(object? sender, MessageEventArgs e)
        {
            var smg = e.Message;
            if (smg.Text != null)
            {
                
                var keyboard = new InlineKeyboardMarkup(new[]
{
    new []
    {       
        InlineKeyboardButton.WithCallbackData("Ярик просрал все сроки?", "callback1"),
    },
    new []
    {
        InlineKeyboardButton.WithCallbackData("Дать по щщам Ярику", "callback2"),      
    }
});
                await client.SendTextMessageAsync(smg.Chat.Id, "Тыкай...", replyMarkup: keyboard) ;
                client.OnCallbackQuery += async (object sc, CallbackQueryEventArgs ev) =>
                {
                    var message = ev.CallbackQuery.Message;
                    if (ev.CallbackQuery.Data == "callback1")
                    {
                        await client.SendTextMessageAsync(smg.Chat.Id, "Да", replyMarkup: keyboard); 
                    }
                    else
                    if (ev.CallbackQuery.Data == "callback2")
                    {
                        await client.SendTextMessageAsync(smg.Chat.Id, "Команда отправлена", replyMarkup: keyboard);
                        
                    }
                };
            };

            }


        }
    }