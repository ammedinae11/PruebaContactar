using DTO.Request.Estudiante;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IEstudiante
    {
        Task<GenericResponse<EstudianteResponse>> Create(CrearEstudianteRequest model);
        Task<GenericResponse<EstudianteResponse>> Update(EditarEstudianteRequest model);
        Task<GenericResponse<bool>> Delete(int id);
        Task<GenericResponse<EstudianteResponse>> GetById(int id);
        Task<GenericResponse<IEnumerable<EstudianteResponse>>> GetAll();
    }
}
