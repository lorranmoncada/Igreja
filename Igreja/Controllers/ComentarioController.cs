using Igreja.Application.AppplicationService.Comentario;
using Igreja.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[Produces("application/json")]
[Route("api")]
public class ComentarioController : Controller
{
    private readonly IComentarioAppService _comentarioAppService;

    public ComentarioController(IComentarioAppService comentarioAppService)
    {
        _comentarioAppService = comentarioAppService;
    }

    [HttpPost]
    [Route("cadastro/comentario")]
    public async Task<IActionResult> CriarPost([FromBody] ComentarioViewModel comentario)
    {
        await _comentarioAppService.CriarComentario(comentario);
        return Ok();
    }

    [HttpGet]
    [Route("cometarios/{idPost:guid}")]
    public async Task<IActionResult> Comentarios(Guid idPost)
    { 
        return Ok(await _comentarioAppService.Comentarios(idPost));
    }
}