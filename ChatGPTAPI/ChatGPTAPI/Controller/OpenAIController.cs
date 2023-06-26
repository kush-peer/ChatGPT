using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;

namespace ChatGPTAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAiController : ControllerBase
    {
        public OpenAiController()
        {

        }
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            try
            {
                var openai = new OpenAIAPI("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");
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
