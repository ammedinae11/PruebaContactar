using Business.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WS.PruebaContactar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporte _reporte;
        public ReporteController(IReporte reporte)
        {
            _reporte = reporte;
        }

        [HttpGet("ReportEstudianteSemestreNotaEstado")]
        public async Task<IActionResult> ReportEstudianteSemestreNotaEstado(short semestre, int materiaId)
        {
            var consumptionResponse = await _reporte.ReportEstudianteSemestreNotaEstado(semestre, materiaId);
            return consumptionResponse.Codigo == 200 ? Ok(consumptionResponse) : BadRequest(consumptionResponse);
        }
    }
}
