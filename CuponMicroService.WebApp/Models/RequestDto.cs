using static CuponMicroService.WebApp.Utilities.SD;

namespace CuponMicroService.WebApp.Models
{
    public class RequestDto
    {

        public ApiType ApiType { get; set; } = ApiType.GET;
        public string URL { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
