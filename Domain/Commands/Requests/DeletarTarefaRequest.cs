using MediatR;
using a_tarefas_mvc.Domain.Commands.Responses;

namespace a_tarefas_mvc.Domain.Commands.Requests
{
    public class DeletarTarefaRequest : IRequest<bool>
    {
        public int TarefaId { get; set; }
    }
}