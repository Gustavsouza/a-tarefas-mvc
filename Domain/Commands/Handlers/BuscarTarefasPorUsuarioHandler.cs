using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using a_tarefas_mvc.Domain.Queries;
using a_tarefas_mvc.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Domain.QueryHandlers
{
    public class BuscarTarefasPorUsuarioHandler : IRequestHandler<BuscarTarefasPorUsuarioRequest, List<TarefasDto>>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public BuscarTarefasPorUsuarioHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TarefasDto>> Handle(BuscarTarefasPorUsuarioRequest query, CancellationToken cancellationToken)
        {
            var tarefas = await _context.Tarefas
                .Include(t => t.Usuario)
                .Where(t => t.Usuario.Id == query.UsuarioId)
                .OrderBy(t => t.DataFim.HasValue ? t.DataFim.Value : DateTime.MaxValue)
                .ToListAsync();

            var tarefasDto = _mapper.Map<List<TarefasDto>>(tarefas);
            return tarefasDto;
        }
    }
}