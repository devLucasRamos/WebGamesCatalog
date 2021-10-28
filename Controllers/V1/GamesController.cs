using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGamesCatalog.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class GamesController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<object>>> Obter()
        {
            return Ok();
        }
        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<List<object>>> ObterByGuid(Guid idJogo)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<object>> InserirJogo(object jogo)
        {
            return Ok();
        }
        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo,object jogo)
        {
            return Ok();
        }
        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarPrecoJogo(Guid idJogo, double preco)
        {
            return Ok();
        }
        [HttpDelete("{idJogo:guid}")]
        public async Task<AcceptedResult> ApagarJogo(Guid idJogo)
        {
            return Ok();
        }
    }
}
