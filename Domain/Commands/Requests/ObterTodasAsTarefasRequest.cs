using MediatR;
using System.Collections.Generic;
using a_tarefas_mvc.Domain.Commands.Responses;

namespace a_tarefas_mvc.Domain.Queries
{
    public class ObterTodasAsTarefasRequest : IRequest<List<TarefaResponse>>
    {
    }
}