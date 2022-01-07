using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FluffyBot.Core
{
    public interface IUpdateService
    {
        Task HandleMessage(Message message);
        Task HandleCallbackQuery(CallbackQuery query);
    }
}
