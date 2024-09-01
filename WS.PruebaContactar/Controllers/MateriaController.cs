using Business.Interfaces;
using DTO.Request.Estudiante;
using DTO.Request.Materia;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WS.PruebaContactar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateria _materia;
        public MateriaController(IMateria materia)
        {
            _materia = materia;
        }

        [HttpPost("CreateMateria")]
        public async Task<IActionResult> CreateMateria([FromBody] CrearMateriaRequest request)
        {
            var consumptionResponse = await _materia.Create(request);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpPut("UpdateMateria")]
        public async Task<IActionResult> UpdateMateria([FromBody] EditarMateriaRequest request)
        {
            var consumptionResponse = await _materia.Update(request);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpDelete("DeleteMateria")]
        public async Task<IActionResult> DeleteMateria(int id)
        {
            var consumptionResponse = await _materia.Delete(id);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpGet("GetMateriaById")]
        public async Task<IActionResult> GetMateriaById(int id)
        {
            var consumptionResponse = await _materia.GetById(id);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpGet("GetAllMateria")]
        public async Task<IActionResult> GetAllMateria()
        {
            var consumptionResponse = await _materia.GetAll();
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }
    }
}
