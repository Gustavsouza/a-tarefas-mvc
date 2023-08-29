using a_tarefas_mvc.Domain.Commands.Responses;
using MediatR;

namespace a_tarefas_mvc.Domain.Commands.Requests
{
    public class FinalizarTarefaRequest : IRequest<TarefaResponse>
    {
        public int TarefaId { get; set; }
    }
}