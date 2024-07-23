using AutoMapper;
using CuponMicroScerviceAPI.Data;
using CuponMicroScerviceAPI.Model;
using CuponMicroScerviceAPI.Model.CuponDto;
using CuponMicroScerviceAPI.Model.ResponseDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuponMicroScerviceAPI.Controllers
{
    [Route("api/Cupon")]
    [ApiController]
    public class CuponApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        private ResponseDTO _response;

        private IMapper _mapper;
        public CuponApiController(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;

            _response = new ResponseDTO();
            _mapper=mapper;
                
        }


        [HttpGet]

        public ResponseDTO Get()
        {
            try
            {

                IEnumerable<Cupons> lst= _db.Cupons.ToList();

                _response.result=_mapper.Map<IEnumerable<CuponDto>>(lst);
                
                

            }
            catch (Exception ex)
            {

                _response.IsSucess = false;
                _response.Message=ex.Message;
            }
           return _response;
        }

        [HttpGet("[action]/{code}")]


        public ResponseDTO  GetByCode(string code)
        {
            try
            {

                Cupons obj= _db.Cupons.FirstOrDefault(u=>u.CuponCode.ToLower()==code.ToLower());


                //CuponDto dto = new CuponDto()
                //{
                //    CuponId = obj.CuponId,
                //    CuponCode = obj.CuponCode,
                //    DiscountAmount = obj.DiscountAmount,
                //    MinAmount = obj.MinAmount,
                //};

              _response.result=  _mapper.Map<CuponDto>(obj);

              

            }
            catch (Exception ex)
            {

                _response.IsSucess = false;
                _response.Message = ex.Message;


            }
            return _response;
        }




        [HttpPost]
        public ResponseDTO Post([FromBody] CuponDto dto) {

            try
            {

                Cupons obj=_mapper.Map<Cupons>(dto);

                _db.Cupons.Add(obj);
                _db.SaveChanges();

                _response.result = _mapper.Map<CuponDto>(obj);


            }
            catch (Exception ex)
            {

                _response.IsSucess = false;
                _response.Message = ex.Message;


         
            }
            return _response;
        
        

        }


        [HttpPut]
        public ResponseDTO Put([FromBody] CuponDto cuponDto)
        {
            try
            {

                Cupons obj = _mapper.Map<Cupons>(cuponDto);

                _db.Cupons.Update(obj);
                _db.SaveChanges();
                _response.result = _mapper.Map<CuponDto>(obj);



            }
            catch (Exception ex)
            {

                _response.IsSucess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }


        [HttpDelete]
        public ResponseDTO delelte(int id)
        {

            try
            {
                Cupons obj=_db.Cupons.FirstOrDefault(u=>u.CuponId == id);
                _db.Cupons. Remove(obj);
                _db.SaveChanges();


            }
            catch (Exception ex)
            {
                _response.Message=ex.Message;
                _response.IsSucess=false;
                throw;
            }
            return _response;

        }

        [HttpGet("[action]/{id:int}")]
		public ResponseDTO GetCuponsById(int id)
		{
			try
			{

                Cupons obj = _db.Cupons.Find(id);


				//CuponDto dto = new CuponDto()
				//{
				//    CuponId = obj.CuponId,
				//    CuponCode = obj.CuponCode,
				//    DiscountAmount = obj.DiscountAmount,
				//    MinAmount = obj.MinAmount,
				//};

				_response.result = _mapper.Map<CuponDto>(obj);



			}
			catch (Exception ex)
			{

				_response.IsSucess = false;
				_response.Message = ex.Message;


			}
			return _response;
		}
	}



  


   



}
