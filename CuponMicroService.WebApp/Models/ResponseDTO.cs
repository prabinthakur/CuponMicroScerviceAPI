using Azure.Core.Pipeline;

namespace CuponMicroScerviceAPI.Model.ResponseDto
{
    public class ResponseDTO
    {

        public object? result { get; set; }
        public bool IsSucess { get; set; } = true;
        public string Message { get; set; }
    }
}
