using AutoMapper;
using SmartSchool.WebAPI.DTOs;

namespace SmartSchool.WebAPI.Helpers
{
	public class AlunoProfile : Profile
	{
        public AlunoProfile()
        {
            CreateMap<Aluno, AlunoDTO>()
                .ForMember(x => x.Nome, opt => opt.MapFrom(x => $"{x.Nome} {x.Sobrenome}"))
                .ForMember(x => x.Idade, opt => opt.MapFrom(x => x.DataNasc.GetCurrentAge()));

            CreateMap<AlunoDTO, Aluno>();

            CreateMap<Aluno,AlunoRegisterDTO>().ReverseMap();
        }
    }
}
