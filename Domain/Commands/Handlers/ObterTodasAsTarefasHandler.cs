using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using a_tarefas_mvc.Domain.Queries;
using a_tarefas_mvc.Domain.Commands.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Domain.QueryHandlers
{
    public class ObterTodasAsTarefasHandler : IRequestHandler<ObterTodasAsTarefasRequest, List<TarefaResponse>>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ObterTodasAsTarefasHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TarefaResponse>> Handle(ObterTodasAsTarefasRequest query, CancellationToken cancellationToken)
        {
            var tarefas = await _context.Tarefas.ToListAsync();

            var tarefasResponse = _mapper.Map<List<TarefaResponse>>(tarefas);
            return tarefasResponse;
        }
    }
}