using MediatR;
using a_tarefas_mvc.Domain.Commands.Responses;

namespace a_tarefas_mvc.Domain.Commands.Requests
{
    public class AtualizarTarefaRequest : IRequest<TarefaResponse>
    {
        public int TarefaId { get; set; }
        public string NovaDescricao { get; set; }
    }
}