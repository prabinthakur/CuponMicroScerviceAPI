using CuponMicroScerviceAPI.Model.CuponDto;
using CuponMicroScerviceAPI.Model.ResponseDto;

namespace CuponMicroService.WebApp.Service.Iservice
{
    public interface ICuponService
    {

        Task<ResponseDTO?> GetCupon(string CuponCode);
        Task<ResponseDTO?> GetAllCuponAsync();
        Task<ResponseDTO?> GetCuponsById(int id);
        Task<ResponseDTO?> Create(CuponDto cuponDto);
        Task<ResponseDTO?> Update(CuponDto cuponDto);
        Task<ResponseDTO?> Delete(int id);
    }
}
