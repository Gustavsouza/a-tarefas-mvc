using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using a_tarefas_mvc.Domain.Commands.Responses;
using a_tarefas_mvc.Models;
using a_tarefas_mvc.Domain.Commands.Requests;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Domain.Commands.Handlers
{
    public class ListarTarefasPorStatusHandler : IRequestHandler<ListarTarefasPorStatusRequest, List<TarefaResponse>>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ListarTarefasPorStatusHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TarefaResponse>> Handle(ListarTarefasPorStatusRequest request, CancellationToken cancellationToken)
        {
            var tarefas = await _context.Tarefas
                .Where(t => t.TarefaFinalizada == request.TarefaFinalizada)
                .ToListAsync();

            var tarefasResponse = _mapper.Map<List<TarefaResponse>>(tarefas);
            return tarefasResponse;
        }
    }
}