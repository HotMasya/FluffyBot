using Telegram.Bot.Types.ReplyMarkups;

namespace FluffyBot.DataService.Models
{
    public class SearchFilter
    {
        public bool IsAdult { get; set; } = false;
        public bool IsUkrNet { get; set; } = false;
        public bool IsGmail { get; set; } = false;

        public InlineKeyboardMarkup InlineKeyboard
        {
            get
            {
                string underageMark = IsAdult ? "✅" : "⬛️";
                string ukrnetMark = IsUkrNet ? "✅" : "⬛️";
                string gmailMark = IsGmail ? "✅" : "⬛️";
                var buttons = new[]
                {
                    new [] { InlineKeyboardButton.WithCallbackData(underageMark + " Есть 18 лет", "filter:isadult")},
                    new [] { InlineKeyboardButton.WithCallbackData(ukrnetMark + " Почта UkrNet", "filter:ukrnet")},
                    new [] { InlineKeyboardButton.WithCallbackData(gmailMark + " Почта Gmai", "filter:gmail")}
                };
                return new InlineKeyboardMarkup(buttons);
            }        
        }
    }
}
