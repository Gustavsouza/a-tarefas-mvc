using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MediatR;
using a_tarefas_mvc.Domain.Commands.Responses;

namespace a_tarefas_mvc.Domain.Commands.Requests
{
    public class CriarUsuarioRequest : IRequest<UsuarioResponse>
    {
        public string Nome { get; }
        public string? Email { get; }
        public DateTime DataNascimento { get; }

        public CriarUsuarioRequest(string nome, string? email, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }
    }
}