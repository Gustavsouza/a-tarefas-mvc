using MediatR;
using a_tarefas_mvc.Domain.Commands;
using a_tarefas_mvc.Domain.Commands.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Domain.CommandHandlers
{
    public class AtualizarUsuarioHandler : IRequestHandler<AtualizarUsuarioRequest, UsuarioResponse>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public AtualizarUsuarioHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioResponse> Handle(AtualizarUsuarioRequest request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == request.Id);

            if (usuario == null)
            {
                return null;
            }

            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.DataNascimento = request.DataNascimento;

            await _context.SaveChangesAsync();

            var usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);
            return usuarioResponse;
        }
    }
}