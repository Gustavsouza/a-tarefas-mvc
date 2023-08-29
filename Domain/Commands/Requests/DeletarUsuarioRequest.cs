using MediatR;

namespace a_tarefas_mvc.Domain.Commands
{
    public class DeletarUsuarioRequest : IRequest
    {
        public int Id { get; set; }
    }
}