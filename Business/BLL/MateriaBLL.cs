using Business.Automapper;
using Business.Interfaces;
using Common.Constants;
using DataAccess.Context;
using DataAccess.Models;
using DTO.Request.Materia;
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
    public class MateriaBLL : IMateria
    {
        private readonly WebserviceContext _db;
        public MateriaBLL(WebserviceContext db)
        {
            _db = db;
        }

        public virtual async Task<GenericResponse<MateriaResponse>> Create(CrearMateriaRequest model)
        {
            try
            {
                var entityExiste = await _db.Set<Materia>().FirstOrDefaultAsync(x => x.Nombre.ToUpper() == model.Nombre.ToUpper());
                if (entityExiste is null)
                {
                    Materia entity = ConvertMapping<CrearMateriaRequest, MateriaResponse, Materia, object>.ConvertToEntity(model);
                    _db.Set<Materia>().Add(entity);
                    await _db.SaveChangesAsync();
                    MateriaResponse modelResponse = ConvertMapping<CrearMateriaRequest, MateriaResponse, Materia, object>.ConvertToResponseModel(entity);
                    if (model is not null) return GenericResponse<MateriaResponse>.ResponseOK(modelResponse);
                    else return GenericResponse<MateriaResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
                else return GenericResponse<MateriaResponse>.ResponseValidation("Ya exite una materia con el nombre ingresado.");                
            }
            catch (Exception ex)
            {
                return GenericResponse<MateriaResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<MateriaResponse>> Update(EditarMateriaRequest model)
        {
            try
            {
                Materia modifiedEntity = ConvertMapping<EditarMateriaRequest, MateriaResponse, Materia, object>.ConvertToEntity(model);
                _db.Entry(modifiedEntity).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                MateriaResponse modelResponse = ConvertMapping<EditarMateriaRequest, MateriaResponse, Materia, object>.ConvertToResponseModel(modifiedEntity);
                if (modelResponse is not null) return GenericResponse<MateriaResponse>.ResponseOK(modelResponse);
                else return GenericResponse<MateriaResponse>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<MateriaResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<bool>> Delete(int id)
        {
            try
            {
                Materia entity = await _db.Set<Materia>().FirstOrDefaultAsync(x => x.Id == id);
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

        public virtual async Task<GenericResponse<MateriaResponse>> GetById(int id)
        {
            try
            {
                Materia entity = await _db.Set<Materia>().FirstOrDefaultAsync(x => x.Id == id);

                if (entity is not null)
                {
                    MateriaResponse modelResponse = ConvertMapping<object, MateriaResponse, Materia, object>.ConvertToResponseModel(entity);
                    return GenericResponse<MateriaResponse>.ResponseOK(modelResponse);
                }
                else return GenericResponse<MateriaResponse>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<MateriaResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<MateriaResponse>>> GetAll()
        {
            try
            {
                List<Materia> entityRecordList = await _db.Set<Materia>().ToListAsync();
                List<MateriaResponse> modelListResponse = ConvertMapping<object, MateriaResponse, Materia, object>.ConvertToResponseModelList(entityRecordList);
                if (modelListResponse.Count() > 0) return GenericResponse<IEnumerable<MateriaResponse>>.ResponseOK(modelListResponse);
                else return GenericResponse<IEnumerable<MateriaResponse>>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<MateriaResponse>>.ResponseError(ex.Message);
            }
        }
    }
}
