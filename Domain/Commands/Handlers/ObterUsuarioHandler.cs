using MediatR;
using System.Threading;
using System.Threading.Tasks;
using a_tarefas_mvc.Domain.Queries;
using a_tarefas_mvc.Domain.Commands.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Domain.QueryHandlers
{
    public class ObterUsuarioPorEmailHandler : IRequestHandler<ObterUsuarioPorEmailRequest, UsuarioResponse>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ObterUsuarioPorEmailHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioResponse> Handle(ObterUsuarioPorEmailRequest query, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == query.Email);

            if (usuario == null)
            {
                return null;
            }

            var usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);
            return usuarioResponse;
        }
    }
}