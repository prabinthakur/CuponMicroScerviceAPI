using CuponMicroScerviceAPI.Model.CuponDto;
using CuponMicroScerviceAPI.Model.ResponseDto;
using CuponMicroService.WebApp.Models;
using CuponMicroService.WebApp.Service.Iservice;
using CuponMicroService.WebApp.Utilities;

namespace CuponMicroService.WebApp.Service
{
    public class CuponService : ICuponService
    {

        private readonly IBaseService _baseService;

        public CuponService(IBaseService baseService)
        {
            
            _baseService = baseService;
        }
        public Task<ResponseDTO?> Create(CuponDto cuponDto)
        {


            return _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=cuponDto,
                URL = SD.CuponApiBase + "/api/Cupon/"
            });
        }

        public Task<ResponseDTO?> Delete(int id)
        {

            return _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                URL = SD.CuponApiBase + "/api/Cupon/" + id
            });
        }

        public Task<ResponseDTO?> GetAllCuponAsync()
        {
          return   _baseService.SendAsync(new RequestDto()
            {
                ApiType=SD.ApiType.GET,
                URL=SD.CuponApiBase+ "/api/Cupon"
            });
        }

        public Task<ResponseDTO?> GetCupon(string CuponCode)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                URL = SD.CuponApiBase + "/api/Cupon/GetByCode" + CuponCode
            });
        }

        public Task<ResponseDTO?> GetCuponsById(int id)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                URL = SD.CuponApiBase + "/api/Cupon/GetCuponsById" + id
            });
        }

        public Task<ResponseDTO?> Update(CuponDto cuponDto)
        {



            return _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = cuponDto,
                URL = SD.CuponApiBase + "/api/Cupon/"
            });
        }
    }
}
