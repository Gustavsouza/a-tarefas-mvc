﻿namespace a_tarefas_mvc.Domain.Commands.Responses
{
    public class TarefaResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

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