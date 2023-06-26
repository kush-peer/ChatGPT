using ChatGPTAPI.Interfaces;
using ChatGPTAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace ChatGPTAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsappController : TwilioController
    {
        private readonly IWhatsappIncomingMessageService _whatsappIncomingMessageService;
        public WhatsappController(IWhatsappIncomingMessageService whatsappIncomingMessageService)
        {
            _whatsappIncomingMessageService = whatsappIncomingMessageService;
        }

        [HttpPost]
        public async Task<IActionResult> IncomingMessages([FromBody]string body)
        {
            try
            {
                var customerResponse = new CustomerRequestModel
                {
                    Message = body
                };
                var response = await _whatsappIncomingMessageService.IncomingMessage(customerResponse);
                return new MessagingResponse()
                    .Message($"{response}")
                    .ToTwiMLResult();

            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
