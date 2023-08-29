using a_tarefas_mvc.Data;
using a_tarefas_mvc.Domain.Commands.Requests;
using a_tarefas_mvc.Domain.Commands.Responses;
using a_tarefas_mvc.Dtos;
using a_tarefas_mvc.Models;
using AutoMapper;
using MediatR;

namespace a_tarefas_mvc.Domain.Commands.Handlers
{
    public class CriarUsuarioHandler : IRequestHandler<CriarUsuarioRequest, UsuarioResponse>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CriarUsuarioHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioResponse> Handle(CriarUsuarioRequest request, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Usuario>(request);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            var usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);
            return usuarioResponse;
        }
    }
}