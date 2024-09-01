using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IReporte
    {
        Task<GenericResponse<IEnumerable<ReporteEstudianteSemestreNotaEstadoResponse>>> ReportEstudianteSemestreNotaEstado(short semestre, int materiaId);
    }
}
