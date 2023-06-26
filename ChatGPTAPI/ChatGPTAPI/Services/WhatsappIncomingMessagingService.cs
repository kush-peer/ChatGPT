using ChatGPTAPI.Interfaces;
using ChatGPTAPI.Model;

namespace ChatGPTAPI.Services
{
    public class WhatsappIncomingMessagingService : IWhatsappIncomingMessageService
    {
        private readonly IADProductService _productService;

        public WhatsappIncomingMessagingService(IADProductService aDProductService)
        {
            _productService = aDProductService;
        }

        public async Task<string> IncomingMessage(CustomerRequestModel incomingMessage)
        {

            var returnedMessage = await _productService.GenerateAdContent(incomingMessage);
            var messages = returnedMessage.ADContent[2];
            return messages;

        }
    }
}