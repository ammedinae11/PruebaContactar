using Business.Automapper;
using Business.Interfaces;
using Common.Constants;
using DataAccess.Context;
using DataAccess.Models;
using DTO.Request.Estudiante;
using DTO.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BLL
{
    public class EstudianteBLL : IEstudiante
    {
        private readonly WebserviceContext _db;
        public EstudianteBLL(WebserviceContext db)
        {
            _db = db;
        }

        public virtual async Task<GenericResponse<EstudianteResponse>> Create(CrearEstudianteRequest model)
        {
            try
            {
                Estudiante entity = ConvertMapping<CrearEstudianteRequest, EstudianteResponse, Estudiante, object>.ConvertToEntity(model);
                _db.Set<Estudiante>().Add(entity);
                await _db.SaveChangesAsync();
                EstudianteResponse modelResponse = ConvertMapping<CrearEstudianteRequest, EstudianteResponse, Estudiante, object>.ConvertToResponseModel(entity);
                if (model is not null) return GenericResponse<EstudianteResponse>.ResponseOK(modelResponse);
                else return GenericResponse<EstudianteResponse>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<EstudianteResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<EstudianteResponse>> Update(EditarEstudianteRequest model)
        {
            try
            {
                Estudiante modifiedEntity = ConvertMapping<EditarEstudianteRequest, EstudianteResponse, Estudiante, object>.ConvertToEntity(model);
                _db.Entry(modifiedEntity).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                EstudianteResponse modelResponse = ConvertMapping<EditarEstudianteRequest, EstudianteResponse, Estudiante, object>.ConvertToResponseModel(modifiedEntity);
                if (modelResponse is not null) return GenericResponse<EstudianteResponse>.ResponseOK(modelResponse);
                else return GenericResponse<EstudianteResponse>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<EstudianteResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<bool>> Delete(int id)
        {
            try
            {
                Estudiante entity = await _db.Set<Estudiante>().FirstOrDefaultAsync(x => x.Id == id);
                if (entity is not null)
                {
                    _db.Entry(entity).State = EntityState.Deleted;
                    await _db.SaveChangesAsync();
                    return GenericResponse<bool>.ResponseOK(true);
                }
                else return GenericResponse<bool>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<bool>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<EstudianteResponse>> GetById(int id)
        {
            try
            {
                Estudiante entity = await _db.Set<Estudiante>().FirstOrDefaultAsync(x => x.Id == id);

                if (entity is not null) 
                {
                    EstudianteResponse modelResponse = ConvertMapping<object, EstudianteResponse, Estudiante, object>.ConvertToResponseModel(entity);                
                    return GenericResponse<EstudianteResponse>.ResponseOK(modelResponse);
                }
                else return GenericResponse<EstudianteResponse>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<EstudianteResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<EstudianteResponse>>> GetAll()
        {
            try
            {
                List<Estudiante> entityRecordList = await _db.Set<Estudiante>().ToListAsync();
                List<EstudianteResponse> modelListResponse = ConvertMapping<object, EstudianteResponse, Estudiante, object>.ConvertToResponseModelList(entityRecordList);
                if (modelListResponse.Count() > 0) return GenericResponse<IEnumerable<EstudianteResponse>>.ResponseOK(modelListResponse);
                else return GenericResponse<IEnumerable<EstudianteResponse>>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<EstudianteResponse>>.ResponseError(ex.Message);
            }
        }
    }
}
