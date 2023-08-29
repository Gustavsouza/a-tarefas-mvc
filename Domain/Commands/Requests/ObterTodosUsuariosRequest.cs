using MediatR;
using System.Collections.Generic;
using a_tarefas_mvc.Domain.Commands.Responses;

namespace a_tarefas_mvc.Domain.Queries
{
    public class ObterTodosUsuariosRequest : IRequest<List<UsuarioResponse>>
    {
    }
}