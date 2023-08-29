using MediatR;
using System.Threading;
using System.Threading.Tasks;
using a_tarefas_mvc.Domain.Commands;
using Microsoft.EntityFrameworkCore;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Domain.CommandHandlers
{
    public class DeletarUsuarioHandler : IRequestHandler<DeletarUsuarioRequest>
    {
        private readonly Context _context;

        public DeletarUsuarioHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletarUsuarioRequest request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuarios.FindAsync(request.Id);

            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}