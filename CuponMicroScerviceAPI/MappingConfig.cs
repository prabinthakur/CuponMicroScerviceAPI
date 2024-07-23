using AutoMapper;
using CuponMicroScerviceAPI.Model;
using CuponMicroScerviceAPI.Model.CuponDto;

namespace CuponMicroScerviceAPI
{
    public class MappingConfig
    {


        public static MapperConfiguration RegisterMaps()
        {

            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CuponDto,Cupons>();

                config.CreateMap<Cupons, CuponDto>();

            });

            return mappingConfig;

        }
    }
}
