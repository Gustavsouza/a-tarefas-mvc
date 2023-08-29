using MediatR;
using System.Threading;
using System.Threading.Tasks;
using a_tarefas_mvc.Domain.Queries;
using a_tarefas_mvc.Domain.Commands.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Domain.QueryHandlers
{
    public class ObterTodosUsuariosHandler : IRequestHandler<ObterTodosUsuariosRequest, List<UsuarioResponse>>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ObterTodosUsuariosHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UsuarioResponse>> Handle(ObterTodosUsuariosRequest query, CancellationToken cancellationToken)
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            var usuariosResponse = _mapper.Map<List<UsuarioResponse>>(usuarios);
            return usuariosResponse;
        }
    }
}