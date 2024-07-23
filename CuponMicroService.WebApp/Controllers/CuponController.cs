using Azure.Core.Pipeline;
using CuponMicroScerviceAPI.Model.CuponDto;
using CuponMicroScerviceAPI.Model.ResponseDto;
using CuponMicroService.WebApp.Service.Iservice;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CuponMicroService.WebApp.Controllers
{

    
    public class CuponController : Controller
    {
        private readonly ICuponService _cuponService;

        public CuponController(ICuponService cuponService)
        {
            _cuponService = cuponService;
            
        }

        public async Task<IActionResult> CuponIndex()
        {

            List<CuponDto> lst = new List<CuponDto>();

            ResponseDTO ? response= await  _cuponService.GetAllCuponAsync();
            if (response!=null && response.IsSucess)
            {

                lst=JsonConvert.DeserializeObject<List<CuponDto>>(Convert.ToString(response.result));

            }
            
            return View(lst);
        }


        public async Task<IActionResult> CuponCreate()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CuponCreate(CuponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDTO? response =await _cuponService.Create(model);
                if (response!=null && response.IsSucess)
                {
                    return RedirectToAction("CuponIndex");

                }

            }

            return View(model);
        }

        
        public async Task<IActionResult> CuponDelete (int cuponid)
        {


            ResponseDTO? dto = await _cuponService.GetCuponsById(cuponid);
            if (dto != null && dto.IsSucess)
            {
                CuponDto cuponDto = JsonConvert.DeserializeObject<CuponDto>(Convert.ToString(dto.result));

                return View(cuponDto);
            }
            return View();

          

        }

        [HttpPost]
        public async Task<IActionResult> CuponDelete(CuponDto model)
        {
            ResponseDTO dto = await _cuponService.Delete(model.CuponId);
            if (dto.IsSucess && dto!=null)
            {
                return RedirectToAction("CuponIndex");

            }
            return View();
        }


    }
}
