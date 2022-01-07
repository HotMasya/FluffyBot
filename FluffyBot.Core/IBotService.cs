using Telegram.Bot;

namespace FluffyBot.Core
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
        public char Prefix { get; }
    }
}
