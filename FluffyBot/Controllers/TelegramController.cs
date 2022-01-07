using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using FluffyBot.Core;

namespace FluffyBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : Controller
    {
        private IUpdateService _updateService;

        public TelegramController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        [HttpPost]
        public async Task<IActionResult> Update(Update update)
        {
            switch(update.Type)
            {
                case UpdateType.Message:
                    await _updateService.HandleMessage(update.Message);
                    break;

                case UpdateType.CallbackQuery:
                    await _updateService.HandleCallbackQuery(update.CallbackQuery);
                    break;
            }

            return Ok();
        }
    }
}
