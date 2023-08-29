using MediatR;
using a_tarefas_mvc.Dtos;

namespace a_tarefas_mvc.Domain.Queries
{
    public class BuscarTarefasPorUsuarioRequest : IRequest<List<TarefasDto>>
    {
        public int UsuarioId { get; set; }
    }
}