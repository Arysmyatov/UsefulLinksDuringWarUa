using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using UsefulLinksDuringWarUa.Services;

namespace UsefulLinksDuringWarUa.Controllers
{
    [ApiController]
    [Route("api/message/update")]
    public class TelegramBotController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;

        public TelegramBotController(TelegramBot telegramBot, ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }
        
        [HttpPost]
        public async Task<IActionResult> Update([FromBody]object update)
        {
            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());

            if (upd?.Message?.Chat == null && upd?.CallbackQuery == null)
            {
                return Ok();
            }

            try
            {
                await _commandExecutor.Execute(upd);
            }
            catch (Exception e)
            {
                return Ok();
            }

            return Ok();

        }
        

    }
}