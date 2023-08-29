using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace a_tarefas_mvc.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório!")]
        [MaxLength(150, ErrorMessage = "O tamanho do Nome não pode exceder 150 caracteres")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [MaxLength(150, ErrorMessage = "O tamanho do Email não pode exceder 150 caracteres")]
        public string? Email { get; set; }
        [DisplayName("Data de Nascimento ")]
        public DateTime DataNascimento { get; set; }

        public ICollection<Tarefa>? Tarefas
        { get; set; }
    }
}