using AutoMapper;
using SmartSchool.WebAPI.DTOs;

namespace SmartSchool.WebAPI.Helpers
{
	public class ProfessorProfile : Profile
	{
        public ProfessorProfile()
        {
            CreateMap<Professor, ProfessorDTO>()
                .ForMember(p => p.Nome, map => map.MapFrom(src => $"{src.Nome} {src.Sobrenome}"));

            CreateMap<ProfessorDTO, Professor>();
            CreateMap<ProfessorRegisterDTO, Professor>().ReverseMap();
        }
    }
}
