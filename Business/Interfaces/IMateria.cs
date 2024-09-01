using DTO.Request.Estudiante;
using DTO.Request.Materia;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMateria
    {
        Task<GenericResponse<MateriaResponse>> Create(CrearMateriaRequest model);
        Task<GenericResponse<MateriaResponse>> Update(EditarMateriaRequest model);
        Task<GenericResponse<bool>> Delete(int id);
        Task<GenericResponse<MateriaResponse>> GetById(int id);
        Task<GenericResponse<IEnumerable<MateriaResponse>>> GetAll();
    }
}
