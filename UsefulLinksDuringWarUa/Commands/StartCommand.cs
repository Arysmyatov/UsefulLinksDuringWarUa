using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UsefulLinksDuringWarUa.Services;

namespace UsefulLinksDuringWarUa.Commands
{
    public class StartCommand : BaseCommand
    {
        private readonly IUserService userService;
        private readonly TelegramBotClient botClient;
        private readonly IBuildMarkupByButtons buildMarkupByButtons;
        public override UrlLink[] urls => null;

        public StartCommand(
            IUserService userService, 
            TelegramBot telegramBot, 
            IBuildMarkupByButtons buildMarkupByButtons)
        {
            this.userService = userService;
            botClient = telegramBot.GetBot().Result;
            this.buildMarkupByButtons = buildMarkupByButtons;
        }

        public override string Name => CommandNames.StartCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var user = userService.GetOrCreate(update);
            var inlineKeyboard = buildMarkupByButtons.GetMarkups();

            var textMessage = "Перелік корисних посилань під час війни. " +
                              "Щоб ви були у максимальній безпеці держава, " +
                              "волонтери та активісти створили джерела " +
                              "з необхідною інформацією. А ми зібрали " +
                              " ці джерела в один перелік. Все в одному місці. \n \n" +
                              "Джерело: dou.ua";
            
            await botClient.SendTextMessageAsync(user.ChatId, textMessage, ParseMode.Markdown,
                replyMarkup: inlineKeyboard);
        }
    }
}