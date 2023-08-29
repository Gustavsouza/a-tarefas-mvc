using a_tarefas_mvc.Domain.Commands.Requests;
using a_tarefas_mvc.Domain.Commands.Responses;
using a_tarefas_mvc.Dtos;
using a_tarefas_mvc.Models;
using AutoMapper;

namespace a_tarefas_mvc.Mapper
{
    public class Entities : Profile
    {
        public Entities()
        {
            CreateMap<Usuario, Usuariodto>().ReverseMap();
            CreateMap<Usuario, CriarUsuarioRequest>().ReverseMap();
            CreateMap<Usuario, UsuarioResponse>().ReverseMap();
            CreateMap<Tarefa, TarefaResponse>().ReverseMap();
            CreateMap<Tarefa, TarefasDto>().ReverseMap();
        }
    }
}