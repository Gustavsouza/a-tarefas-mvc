using MediatR;
using System.Threading;
using System.Threading.Tasks;
using a_tarefas_mvc.Domain.Commands;
using a_tarefas_mvc.Domain.Commands.Responses;
using a_tarefas_mvc.Models;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Domain.CommandHandlers
{
    public class CriarTarefaHandler : IRequestHandler<CriarTarefaRequest, TarefaResponse>
    {
        private readonly Context _context;

        public CriarTarefaHandler(Context context)
        {
            _context = context;
        }

        public async Task<TarefaResponse> Handle(CriarTarefaRequest request, CancellationToken cancellationToken)
        {
            var novaTarefa = new Tarefa
            {
                UsuarioId = request.IdUsuario,
                Descricao = request.Descricao,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim
            };

            _context.Tarefas.Add(novaTarefa);
            await _context.SaveChangesAsync();

            var tarefaResponse = new TarefaResponse
            {
                Id = novaTarefa.Id,
                Descricao = novaTarefa.Descricao,
                DataInicio = novaTarefa.DataInicio,
                DataFim = novaTarefa.DataFim
            };

            return tarefaResponse;
        }
    }
}