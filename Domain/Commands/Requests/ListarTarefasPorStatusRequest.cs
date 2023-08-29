using a_tarefas_mvc.Domain.Commands.Responses;
using MediatR;

namespace a_tarefas_mvc.Domain.Commands.Requests
{
    public class ListarTarefasPorStatusRequest : IRequest<List<TarefaResponse>>
    {
        public bool TarefaFinalizada { get; set; }
    }
}