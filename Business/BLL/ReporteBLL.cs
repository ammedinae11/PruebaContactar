using Business.Automapper;
using Business.Interfaces;
using Common.Constants;
using DataAccess.Context;
using DataAccess.Models;
using DTO.Request.Materia;
using DTO.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BLL
{
    public class ReporteBLL : IReporte
    {
        private readonly WebserviceContext _db;
        public ReporteBLL(WebserviceContext db)
        {
            _db = db;
        }

        public virtual async Task<GenericResponse<IEnumerable<ReporteEstudianteSemestreNotaEstadoResponse>>> ReportEstudianteSemestreNotaEstado(short semestre, int materiaId)
        {
            try
            {
                var entityRecordList = await _db.Set<Nota>().Where(x => x.Semestre.Equals(semestre) && x.MateriaId.Equals(materiaId))
                                .Select(x => new ReporteEstudianteSemestreNotaEstadoResponse
                                {
                                    Estudiante = x.Estudiante.Nombre,
                                    Semestre = x.Semestre,
                                    Materia = x.Materia.Nombre,
                                    NotaPromedio = (_db.Notas.Where(z => z.Semestre.Equals(x.Semestre) && z.MateriaId.Equals(x.MateriaId) && z.EstudianteId.Equals(x.EstudianteId)).Sum(z => z.Nota1)) / 5,
                                    Estado = ((_db.Notas.Where(y => y.Semestre.Equals(x.Semestre) && y.MateriaId.Equals(x.MateriaId) && y.EstudianteId.Equals(x.EstudianteId)).Sum(y => y.Nota1)) / 5) < 3 ? "NO APROBADO" : "APROBADO"
                                }).Distinct().ToListAsync();

                List<ReporteEstudianteSemestreNotaEstadoResponse> modelListResponse = ConvertMapping<object, ReporteEstudianteSemestreNotaEstadoResponse, Nota, object>.ConvertListResponseModelToResponseModel(entityRecordList);
                if (modelListResponse.Count() > 0) return GenericResponse<IEnumerable<ReporteEstudianteSemestreNotaEstadoResponse>>.ResponseOK(modelListResponse);
                else return GenericResponse<IEnumerable<ReporteEstudianteSemestreNotaEstadoResponse>>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<ReporteEstudianteSemestreNotaEstadoResponse>>.ResponseError(ex.Message);
            }
        }
    }
}
