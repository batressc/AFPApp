using AFPApp.DataAccess.Model;
using AFPApp.Entities.Dto;
using AutoMapper;

namespace AFPApp.BusinessLogic {
    internal class AutoMapperConfiguration : Profile {
        public AutoMapperConfiguration() {
            CreateMap<AfiliadoCreateDto, Afiliado>();
            CreateMap<AfiliadoUpdateDto, Afiliado>();
            CreateMap<Afiliado, AfiliadoDisplayDto>().ReverseMap();
        }
    }
}
