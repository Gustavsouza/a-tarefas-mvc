namespace a_tarefas_mvc.Dtos
{
    public class TarefasDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool TarefaFinalizada { get; set; }

        public int? TempoSolucao { get; set; }

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
    }
}