using ChatGPTAPI.Interfaces;
using ChatGPTAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ChatGPTAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ADGeneratorController : ControllerBase
    {
        private readonly IADProductService _adProduct;
        public ADGeneratorController(IADProductService adProduct)
        {
            _adProduct = adProduct;
        }

        [HttpPost]
        public async Task<ActionResult<ADProductResponseModel>> GenerateAD(CustomerRequestModel aDGenerateRequestModel)
        {
            try
            {

                var response = await _adProduct.GenerateAdContent(aDGenerateRequestModel);

                return response;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
