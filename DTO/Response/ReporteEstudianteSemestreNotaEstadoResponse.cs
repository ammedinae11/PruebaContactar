using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response
{
    public class ReporteEstudianteSemestreNotaEstadoResponse
    {
        public string Estudiante { get; set; }
        public short Semestre { get; set; }
        public string Materia { get; set; }
        public decimal NotaPromedio { get; set; }
        public string Estado { get; set; }
    }
}
