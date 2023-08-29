using a_tarefas_mvc.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class ObterEstatisticasUsuariosHandler : IRequestHandler<ObterEstatisticasUsuariosRequest, List<UsuarioEstatisticasDto>>
{
    private readonly Context _context;

    public ObterEstatisticasUsuariosHandler(Context context)
    {
        _context = context;
    }

    public async Task<List<UsuarioEstatisticasDto>> Handle(ObterEstatisticasUsuariosRequest request, CancellationToken cancellationToken)
    {
        var estatisticas = await _context.Tarefas
            .Where(t => t.TarefaFinalizada == true)
            .GroupBy(t => t.UsuarioId)
            .Select(g => new UsuarioEstatisticasDto
            {
                UsuarioId = g.Key,
                Nome = g.FirstOrDefault().Usuario.Nome,
                TotalTarefasFinalizadas = g.Count()
            })
            .OrderByDescending(e => e.TotalTarefasFinalizadas)
            .ToListAsync();

        return estatisticas;
    }

}