using ChatGPTAPI.Model;

namespace ChatGPTAPI.Interfaces
{
    public interface IWhatsappIncomingMessageService
    {
        Task<string> IncomingMessage(CustomerRequestModel incomingMessage);
    }
}
