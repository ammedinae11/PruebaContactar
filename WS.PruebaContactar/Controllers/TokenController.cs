using Business.Interfaces;
using DTO.Request.Token;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WS.PruebaContactar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IToken _token;
        public TokenController(IToken token)
        {
            _token = token;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] TokenRequest request)
        {
            var result = await _token.Token(request);
            if (result.Codigo == 200)
            {
                GenericResponse<TokenResponse> respuestaGenerica = result;
                return Ok(respuestaGenerica);
            }
            return BadRequest(result);
        }
    }
}
