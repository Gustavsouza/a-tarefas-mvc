using System;
using System.Threading;
using System.Threading.Tasks;
using a_tarefas_mvc.Data;
using a_tarefas_mvc.Domain.Commands.Requests;
using a_tarefas_mvc.Domain.Commands.Responses;
using a_tarefas_mvc.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace a_tarefas_mvc.Domain.Commands.Handlers
{
    public class FinalizarTarefaHandler : IRequestHandler<FinalizarTarefaRequest, TarefaResponse>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public FinalizarTarefaHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TarefaResponse> Handle(FinalizarTarefaRequest request, CancellationToken cancellationToken)
        {
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == request.TarefaId);

            if (tarefa == null)
            {
                return null;
            }

            tarefa.TarefaFinalizada = true;
            if (!tarefa.DataFim.HasValue)
            {
                tarefa.DataFim = DateTime.Now;
            }

            tarefa.TempoSolucao = (int)(tarefa.DataFim - tarefa.DataInicio).Value.TotalMinutes;

            await _context.SaveChangesAsync();

            var tarefaResponse = _mapper.Map<TarefaResponse>(tarefa);
            return tarefaResponse;
        }
    }
}