using Business.Interfaces;
using DTO.Request.Materia;
using DTO.Request.Nota;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WS.PruebaContactar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly INota _nota;
        public NotaController(INota nota)
        {
            _nota = nota;
        }

        [HttpPost("CreateNota")]
        public async Task<IActionResult> CreateNota([FromBody] CrearNotaRequest request)
        {
            var consumptionResponse = await _nota.Create(request);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpPut("UpdateNota")]
        public async Task<IActionResult> UpdateNota([FromBody] EditarNotaRequest request)
        {
            var consumptionResponse = await _nota.Update(request);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpDelete("DeleteNota")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            var consumptionResponse = await _nota.Delete(id);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpGet("GetNotaById")]
        public async Task<IActionResult> GetNotaById(int id)
        {
            var consumptionResponse = await _nota.GetById(id);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpGet("GetAllNota")]
        public async Task<IActionResult> GetAllNota()
        {
            var consumptionResponse = await _nota.GetAll();
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }
    }
}
