using ChatGPTAPI.Interfaces;
using ChatGPTAPI.Model;
using OpenAI_API;

namespace ChatGPTAPI.Services
{
    public class BotAPIService : IBotAPIService
    {
        private readonly IConfiguration _configuration;
        public BotAPIService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<string>> GenerateContent(ADGenerateRequestModelDTO generateRequestModel)
        {
            try
            {
                var apiKey = _configuration.GetValue<string>("openAPIAIKey");
                var rq = new List<string>
                {
                    Capacity = 0
                };
                var api = new OpenAIAPI(new APIAuthentication(apiKey));
                var completionRequest = new OpenAI_API.Completions.CompletionRequest()
                {
                    Prompt = generateRequestModel.prompt,
                    Model = OpenAI_API.Models.Model.DavinciText,
                    Temperature = 0.5,
                    MaxTokens = 100,
                    TopP = 1.0,
                    FrequencyPenalty = 0.0,
                    PresencePenalty = 0.0,

                };
                var result = await api.Completions.CreateCompletionsAsync(completionRequest);
                rq.AddRange(result.Completions.Select(choice => choice.Text));
                return rq;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
