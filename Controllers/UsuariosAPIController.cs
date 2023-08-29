using Microsoft.AspNetCore.Mvc;
using a_tarefas_mvc.Models;
using AutoMapper;
using a_tarefas_mvc.Domain.Commands.Requests;
using a_tarefas_mvc.Domain.Commands.Responses;
using MediatR;
using a_tarefas_mvc.Domain.Queries;
using a_tarefas_mvc.Domain.Commands;
using a_tarefas_mvc.Dtos;

namespace a_tarefas_mvc.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosAPIController : Controller
    {
        [HttpPost("Criar")]
        public Task<UsuarioResponse> CriarContato([FromServices] IMediator mediator, [FromBody] CriarUsuarioRequest request)
        {
            return mediator.Send(request);
        }

        [HttpGet("Obter")]
        public async Task<IActionResult> ObterUsuarioEmail([FromServices] IMediator mediator, [FromQuery] string email)
        {
            var query = new ObterUsuarioPorEmailRequest { Email = email };
            var usuarioResponse = await mediator.Send(query);

            if (usuarioResponse == null)
            {
                return NotFound();
            }

            return Ok(usuarioResponse);
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodosUsuarios([FromServices] IMediator mediator)
        {
            var query = new ObterTodosUsuariosRequest();
            var usuariosResponse = await mediator.Send(query);

            return Ok(usuariosResponse);
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> AtualizarUsuario([FromServices] IMediator mediator, [FromBody] AtualizarUsuarioRequest request)
        {
            var usuarioResponse = await mediator.Send(request);

            if (usuarioResponse == null)
            {
                return NotFound();
            }

            return Ok(usuarioResponse);
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<IActionResult> DeletarUsuario([FromServices] IMediator mediator, int id)
        {
            var usuario = new DeletarUsuarioRequest { Id = id };
            await mediator.Send(usuario);

            return NoContent();
        }

        [HttpGet("TarefasPorUsuario/{usuarioId}")]
        public async Task<ActionResult<List<TarefasDto>>> BuscarTarefasPorUsuario([FromServices] IMediator mediator, int usuarioId)
        {
            var query = new BuscarTarefasPorUsuarioRequest { UsuarioId = usuarioId };
            var tarefas = await mediator.Send(query);

            return tarefas;
        }
    }
}