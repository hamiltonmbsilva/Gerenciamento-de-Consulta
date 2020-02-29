using AutoMapper;
using Repository.DTO;
using Repository.Models;
using RepositoryWebApi.Repository.Models;

namespace Repository.Map
{
    public class MapConfig
    {
        public static IMapper GetMap()
        {
            var map = new MapperConfiguration(cfg => {
                cfg.CreateMap<Paciente, PacienteListDTO>()// Cria o mapeamento entre Paciente e PacienteListDTO
                .ReverseMap();//possibilita o mapeamento de Paciente para PacienteListDTO e PacienteListDTO para Paciente

                cfg.CreateMap<Agendamento, AgendamentoListDTO>()
                .ForMember(dest => dest.NomePaciente, ori => ori.MapFrom(x => x.Pacientes.Nome))// Pega a propriedade nome dentro do objeto paciente e adiciona ela a propriedade NomePaciente
                .ReverseMap();

                cfg.CreateMap<Anaminese, AnamineseListDTO>()
                .ReverseMap();
            });

            IMapper mapper = map.CreateMapper();
            return mapper;
        }
    }
}
