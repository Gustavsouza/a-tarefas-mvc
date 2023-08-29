using MediatR;
using a_tarefas_mvc.Domain.Commands.Responses;

namespace a_tarefas_mvc.Domain.Commands
{
    public class CriarTarefaRequest : IRequest<TarefaResponse>
    {
        public int IdUsuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}