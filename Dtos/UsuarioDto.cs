using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace a_tarefas_mvc.Dtos
{
    public class Usuariodto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}