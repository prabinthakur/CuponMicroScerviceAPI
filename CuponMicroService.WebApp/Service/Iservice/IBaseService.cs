using CuponMicroScerviceAPI.Model.ResponseDto;
using CuponMicroService.WebApp.Models;

namespace CuponMicroService.WebApp.Service.Iservice
{
    public interface IBaseService
    {

        Task<ResponseDTO>? SendAsync (RequestDto requestDto);
    }
}
