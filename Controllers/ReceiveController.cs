
using Microsoft.AspNetCore.Mvc;

namespace TextPlus_BE.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ReceiveController : BaseController
    {
        // private readonly IMessageService _messageService;
        // private readonly IJwtSettings _jwtSettings;
        // public ReceiveController(IMessageService messageService, IJwtSettings jwtSettings)
        // {
        //     _messageService = messageService;
        //     _jwtSettings = jwtSettings;
        // }

        [HttpPost("receiveMessage")]
        public async Task<IActionResult> ReceiveMessage()
        {

            return Ok();
        }

    }

}
