using MediatR;
using a_tarefas_mvc.Domain.Commands.Responses;

namespace a_tarefas_mvc.Domain.Queries
{
    public class ObterUsuarioPorEmailRequest : IRequest<UsuarioResponse>
    {
        public string Email { get; set; }
    }
}