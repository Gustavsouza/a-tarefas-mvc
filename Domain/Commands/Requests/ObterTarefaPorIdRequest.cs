using MediatR;
using a_tarefas_mvc.Domain.Commands.Responses;

namespace a_tarefas_mvc.Domain.Queries
{
    public class ObterTarefaPorIdRequest : IRequest<TarefaResponse>
    {
        public int TarefaId { get; set; }
    }
}