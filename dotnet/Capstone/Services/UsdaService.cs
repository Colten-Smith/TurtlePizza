using Capstone.Models;
using RestSharp;

namespace Capstone.Services
{
    public class UsdaService
    {
        public IRestClient client;
        public UsdaService(string apiUrl)
        {
            client = new RestClient(apiUrl);
        }
        public UsdaFood GetFoodByFcdId(int id)
        {
            RestRequest request = new RestRequest($"/v1/food/{id}");
            IRestResponse<UsdaFood> response = client.Get<UsdaFood>(request);
            if (!response.IsSuccessful)
            {
                throw new System.Exception("The USDA Database could not be reached.");
            }
            return response.Data;
        }
    }
}
