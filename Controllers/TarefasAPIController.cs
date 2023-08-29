using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using a_tarefas_mvc.Models;
using AutoMapper;
using a_tarefas_mvc.Dtos;
using a_tarefas_mvc.Domain.Commands.Responses;
using a_tarefas_mvc.Domain.Commands.Handlers;
using a_tarefas_mvc.Domain.Commands.Requests;
using MediatR;
using a_tarefas_mvc.Domain.Commands;
using a_tarefas_mvc.Domain.Queries;

namespace a_tarefas_mvc.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TarefasAPIController : Controller
    {
        [HttpPost("CriarTarefa")]
        public async Task<ActionResult<TarefaResponse>> CriarTarefa([FromServices] IMediator mediator, [FromBody] CriarTarefaRequest request)
        {
            var tarefaResponse = await mediator.Send(request);

            return CreatedAtAction(nameof(TarefaResponse), new { id = tarefaResponse.Id }, tarefaResponse);
        }

        [HttpGet("ObterTarefaPorId/{tarefaId}")]
        public async Task<ActionResult<TarefaResponse>> ObterTarefaPorId([FromServices] IMediator mediator, int tarefaId)
        {
            var query = new ObterTarefaPorIdRequest { TarefaId = tarefaId };
            var tarefa = await mediator.Send(query);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }

        [HttpGet("ObterTodasAsTarefas")]
        public async Task<ActionResult<List<TarefaResponse>>> ObterTodasAsTarefas([FromServices] IMediator mediator)
        {
            var query = new ObterTodasAsTarefasRequest();
            var tarefas = await mediator.Send(query);

            return tarefas;
        }

        [HttpPut("AtualizarTarefa/{tarefaId}")]
        public async Task<ActionResult<TarefaResponse>> AtualizarTarefa([FromServices] IMediator mediator, int tarefaId, [FromBody] AtualizarTarefaRequest request)
        {
            request.TarefaId = tarefaId;
            var tarefaAtualizada = await mediator.Send(request);

            if (tarefaAtualizada == null)
            {
                return NotFound();
            }

            return tarefaAtualizada;
        }

        [HttpDelete("DeletarTarefa/{tarefaId}")]
        public async Task<ActionResult<bool>> DeletarTarefa([FromServices] IMediator mediator, int tarefaId)
        {
            var tarefa = new DeletarTarefaRequest { TarefaId = tarefaId };
            var deletado = await mediator.Send(tarefa);

            if (!deletado)
            {
                return NotFound();
            }

            return true;
        }
    }
}