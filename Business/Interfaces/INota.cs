using DTO.Request.Materia;
using DTO.Request.Nota;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface INota
    {
        Task<GenericResponse<NotaResponse>> Create(CrearNotaRequest model);
        Task<GenericResponse<NotaResponse>> Update(EditarNotaRequest model);
        Task<GenericResponse<bool>> Delete(int id);
        Task<GenericResponse<NotaResponse>> GetById(int id);
        Task<GenericResponse<IEnumerable<NotaResponse>>> GetAll();
    }
}
