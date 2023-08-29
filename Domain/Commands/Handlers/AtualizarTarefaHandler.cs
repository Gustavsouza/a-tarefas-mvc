using MediatR;
using System.Threading;
using System.Threading.Tasks;
using a_tarefas_mvc.Domain.Commands.Requests;
using a_tarefas_mvc.Domain.Commands.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Domain.CommandHandlers
{
    public class AtualizarTarefaHandler : IRequestHandler<AtualizarTarefaRequest, TarefaResponse>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public AtualizarTarefaHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TarefaResponse> Handle(AtualizarTarefaRequest request, CancellationToken cancellationToken)
        {
            var tarefa = await _context.Tarefas.FindAsync(request.TarefaId);

            if (tarefa == null)
            {
                return null;
            }

            tarefa.Descricao = request.NovaDescricao;

            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var tarefaResponse = _mapper.Map<TarefaResponse>(tarefa);
            return tarefaResponse;
        }
    }
}