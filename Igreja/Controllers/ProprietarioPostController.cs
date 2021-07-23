

using Igreja.Application.AppplicationService.PostProprietario;
using Igreja.Application.ViewModel;
using Igreja.Core.Util;
using Igreja.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Igreja.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ProprietarioPostController : Controller
    {

        private readonly IPostProprietarioAppService _postProprietarioAppService;

        public ProprietarioPostController(IPostProprietarioAppService postProprietarioAppService)
        {
            _postProprietarioAppService = postProprietarioAppService;
        }

        [HttpPost]
        [Route("cadastro/post")]
        public async Task<IActionResult> CriarPost([FromBody] ProprietarioPostViewModel post)
        {
            await _postProprietarioAppService.CriarPost(post);
            return Ok(post);

        }

        [HttpGet]
        [Route("postsByUser")]
        public async Task<IActionResult> AllPostByProprietario([FromQuery] PagedInfo info)
        {
            return Ok(await _postProprietarioAppService.PostsByByProprietario(info));
        }
    }
}
