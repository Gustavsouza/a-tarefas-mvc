using MediatR;
using System.Threading;
using System.Threading.Tasks;
using a_tarefas_mvc.Domain.Commands.Requests;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Domain.CommandHandlers
{
    public class DeletarTarefaHandler : IRequestHandler<DeletarTarefaRequest, bool>
    {
        private readonly Context _context;

        public DeletarTarefaHandler(Context context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletarTarefaRequest request, CancellationToken cancellationToken)
        {
            var tarefa = await _context.Tarefas.FindAsync(request.TarefaId);

            if (tarefa == null)
            {
                return false;
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}