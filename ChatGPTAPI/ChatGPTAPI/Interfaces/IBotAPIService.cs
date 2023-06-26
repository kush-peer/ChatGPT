using ChatGPTAPI.Model;

namespace ChatGPTAPI.Interfaces
{
    public interface IBotAPIService
    {
        Task<List<string>> GenerateContent(ADGenerateRequestModelDTO generateRequestModel);
    }
}
