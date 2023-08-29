using MediatR;
using System.Threading;
using System.Threading.Tasks;
using a_tarefas_mvc.Domain.Queries;
using a_tarefas_mvc.Domain.Commands.Responses;
using AutoMapper;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Domain.QueryHandlers
{
    public class ObterTarefaPorIdHandler : IRequestHandler<ObterTarefaPorIdRequest, TarefaResponse>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ObterTarefaPorIdHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TarefaResponse> Handle(ObterTarefaPorIdRequest query, CancellationToken cancellationToken)
        {
            var tarefa = await _context.Tarefas.FindAsync(query.TarefaId);

            if (tarefa == null)
            {
                return null;
            }

            var tarefaResponse = _mapper.Map<TarefaResponse>(tarefa);
            return tarefaResponse;
        }
    }
}