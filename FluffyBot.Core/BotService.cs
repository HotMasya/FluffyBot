using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace FluffyBot.Core
{
    public class BotService : IBotService
    {
        public TelegramBotClient Client { get; }

        public char Prefix { get; }

        private TelegramBotOptions _botOptions;

        public BotService(IOptions<TelegramBotOptions> botOptions)
        {
            _botOptions = botOptions.Value;
            Client = new TelegramBotClient(_botOptions.Token);
            Prefix = _botOptions.Prefix;
        }
    }
}
