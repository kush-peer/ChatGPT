using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;

namespace ChatGPTAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public OpenAiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            try
            {
                var openai = new OpenAIAPI(_configuration.GetValue<string>("openAPIAIKey"));
                var completionRequest = new CompletionRequest
                {
                    Prompt = query,
                    Model = OpenAI_API.Models.Model.DavinciText,
                    MaxTokens = 1024
                };

                var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

                var outputResult =
                    completions.Completions.Aggregate("", (current, completion) => current + completion.Text);

                return Ok(outputResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
