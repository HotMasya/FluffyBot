using FluffyBot.DataService.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FluffyBot.Core
{
    public class UpdateService : IUpdateService
    {
        private IBotService _botService;
        private ILogger<UpdateService> _logger;

        public UpdateService(IBotService botService, ILogger<UpdateService> logger)
        {
            _botService = botService;
            _logger = logger;
        }

        public async Task HandleCallbackQuery(CallbackQuery query)
        {
            _logger.LogInformation($"Got callback query from {query.From.Username}.");

            if(query.Data.IndexOf("filter") >= 0)
            {
                SearchFilter filter = Data.Filters[query.Message.Chat.Id];
                switch(query.Data)
                {
                    case "filter:isadult":
                        filter.IsAdult = !filter.IsAdult;
                        break;
                    case "filter:ukrnet":
                        filter.IsUkrNet = !filter.IsUkrNet;
                        break;
                    case "filter:gmail":
                        filter.IsGmail = !filter.IsGmail;
                        break;
                }
                await _botService.Client.EditMessageReplyMarkupAsync(query.Message.Chat, query.Message.MessageId, filter.InlineKeyboard);
            }
        }

        public async Task HandleMessage(Message message)
        {
            if (message.From.IsBot || message.Text is null || !message.Text.StartsWith(_botService.Prefix)) return;

            _logger.LogInformation($"Got message from {message.From.Username}.");

            if(message.Text.ToLower() == "/filters")
            {
                if(Data.Filters.ContainsKey(message.Chat.Id))
                {
                    Data.Filters.Remove(message.Chat.Id);
                }
                SearchFilter filter = new SearchFilter();
                Data.Filters.Add(message.Chat.Id, filter);
                await _botService.Client.SendTextMessageAsync(message.Chat, "Select filters", replyMarkup: filter.InlineKeyboard);
            }
        }
    }
}
