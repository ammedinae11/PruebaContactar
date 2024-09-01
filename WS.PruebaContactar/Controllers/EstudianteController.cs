using Business.Interfaces;
using DTO.Request.Estudiante;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WS.PruebaContactar.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudiante _estudiante;
        public EstudianteController(IEstudiante estudiante)
        {
            _estudiante = estudiante;
        }

        [HttpPost("CreateEstudiante")]
        public async Task<IActionResult> CreateEstudiante([FromBody] CrearEstudianteRequest request)
        {
            var consumptionResponse = await _estudiante.Create(request);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpPut("UpdateEstudiante")]
        public async Task<IActionResult> UpdateEstudiante([FromBody] EditarEstudianteRequest request)
        {
            var consumptionResponse = await _estudiante.Update(request);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpDelete("DeleteEstudiante")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var consumptionResponse = await _estudiante.Delete(id);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpGet("GetEstudianteById")]
        public async Task<IActionResult> GetEstudianteById(int id)
        {
            var consumptionResponse = await _estudiante.GetById(id);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }

        [HttpGet("GetAllEstudiante")]
        public async Task<IActionResult> GetAllEstudiante()
        {
            var consumptionResponse = await _estudiante.GetAll();
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }
    }
}
