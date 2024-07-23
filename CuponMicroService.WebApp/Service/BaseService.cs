using CuponMicroScerviceAPI.Model.ResponseDto;
using CuponMicroService.WebApp.Models;
using CuponMicroService.WebApp.Service.Iservice;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using static CuponMicroService.WebApp.Utilities.SD;

namespace CuponMicroService.WebApp.Service
{
    public class BaseService : IBaseService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

       
        public async Task<ResponseDTO>? SendAsync(RequestDto requestDto)
        {
            HttpClient client = _httpClientFactory.CreateClient("MeroClient");

            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(requestDto.URL);

            if (requestDto.Data!=null)
            {
                message.Content=new StringContent(JsonConvert.SerializeObject(requestDto.Data),Encoding.UTF8,"application/json");

            }

            HttpResponseMessage? apiresponse = null;

            switch (requestDto.ApiType)
            {

                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }
            apiresponse = await client.SendAsync(message);

            switch (apiresponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new() { IsSucess = false, Message = "notfound" };

                case HttpStatusCode.Unauthorized:
                    return new()
                    {

                        IsSucess = false,
                        Message = "unauthorized"
                    };
                case HttpStatusCode.Forbidden:
                    return new()
                    {
                        IsSucess = false,
                        Message = "forbideen"
                    };
                case HttpStatusCode.InternalServerError:
                    return new()
                    { IsSucess = false, Message = "internal server effect" };

                default:
                    var apiContent = await apiresponse.Content.ReadAsStringAsync();
                    var responseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                    return responseDTO;
            }

        }
    }
}
