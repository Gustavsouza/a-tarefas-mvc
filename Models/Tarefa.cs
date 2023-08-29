using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a_tarefas_mvc.Models
{
    public class Tarefa
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatório")]
        [MaxLength(100, ErrorMessage = "O tamanho da descrição não pode exceder 100 caracteres")]
        public string Descricao { get; set; }

        public int UsuarioId { get; set; }

        [DisplayName("Data Inicio ")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data Fim ")]
        public DateTime? DataFim { get; set; }

        public Usuario Usuario { get; set; }

        public bool TarefaFinalizada { get; set; }

        public int? TempoSolucao { get; set; }

        [NotMapped]
        [DisplayName("Tempo Restante em dias")]
        public int? TempoRestanteDias
        {
            get
            {
                if (DataFim.HasValue && DataFim.Value > DateTime.Now)
                {
                    TimeSpan Diferenca = DataFim.Value - DateTime.Now;
                    return (int)Diferenca.TotalDays;
                }
                return 0;
            }
        }

        public Tarefa()
        {
            DataInicio = DateTime.Now;
            TarefaFinalizada = false; //
        }
    }
}