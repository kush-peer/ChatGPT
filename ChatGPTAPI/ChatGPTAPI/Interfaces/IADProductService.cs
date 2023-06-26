using ChatGPTAPI.Model;

namespace ChatGPTAPI.Interfaces
{
    public interface IADProductService
    {
        Task<ADProductResponseModel> GenerateAdContent(CustomerRequestModel aDGenerateRequestModel);
    }
}
