using Business.Automapper;
using Business.Interfaces;
using Common.Constants;
using DataAccess.Context;
using DataAccess.Models;
using DTO.Request.Nota;
using DTO.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BLL
{
    public class NotaBLL : INota
    {
        private readonly WebserviceContext _db;
        public NotaBLL(WebserviceContext db)
        {
            _db = db;
        }

        public virtual async Task<GenericResponse<NotaResponse>> Create(CrearNotaRequest model)
        {
            try
            {
                if (model.Nota1 < 1 || model.Nota1 > 5) return GenericResponse<NotaResponse>.ResponseValidation("La Nota debe estar entre 1 y 5");
                bool estudianteExiste = await ConsultarEstudiante(model.EstudianteId);
                bool materiaExiste = await ConsultarMateria (model.MateriaId);
                if (estudianteExiste && materiaExiste)
                {
                    int numeroNotas = await CalcularNumeroNotas(model.EstudianteId, model.MateriaId);
                    if (numeroNotas < 5)
                    {
                        Nota entity = ConvertMapping<CrearNotaRequest, NotaResponse, Nota, object>.ConvertToEntity(model);
                        _db.Set<Nota>().Add(entity);
                        await _db.SaveChangesAsync();
                        NotaResponse modelResponse = ConvertMapping<CrearNotaRequest, NotaResponse, Nota, object>.ConvertToResponseModel(entity);
                        if (model is not null) return GenericResponse<NotaResponse>.ResponseOK(modelResponse);
                        else return GenericResponse<NotaResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                    }
                    else return GenericResponse<NotaResponse>.ResponseValidation("Por favor validar los valores ingresados, ya que estos poseen 5 notas y no se pueden ingresar mas.");
                }
                else return GenericResponse<NotaResponse>.ResponseValidation((!estudianteExiste ? "El EstudianteId no existe. " : "") + (!materiaExiste ? "La MateriaId no existe" : ""));

            }
            catch (Exception ex)
            {
                return GenericResponse<NotaResponse>.ResponseError(ex.Message);
            }
        }

        private async Task<int> CalcularNumeroNotas(int estudianteId, int materiaId)
        {
            int numeroNotas = await _db.Set<Nota>().Where(x => x.EstudianteId == estudianteId && x.MateriaId == materiaId).CountAsync();
            return numeroNotas;
        }

        private async Task<bool> ConsultarEstudiante(int estudianteId)
        {
            return await _db.Set<Estudiante>().Where(x => x.Id == estudianteId).AnyAsync();
        }

        private async Task<bool> ConsultarMateria(int materiaId)
        {
            return await _db.Set<Materia>().Where(x => x.Id == materiaId).AnyAsync();
        }

        public virtual async Task<GenericResponse<NotaResponse>> Update(EditarNotaRequest model)
        {
            try
            {
                Nota modifiedEntity = ConvertMapping<EditarNotaRequest, NotaResponse, Nota, object>.ConvertToEntity(model);
                _db.Entry(modifiedEntity).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                NotaResponse modelResponse = ConvertMapping<EditarNotaRequest, NotaResponse, Nota, object>.ConvertToResponseModel(modifiedEntity);
                if (modelResponse is not null) return GenericResponse<NotaResponse>.ResponseOK(modelResponse);
                else return GenericResponse<NotaResponse>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<NotaResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<bool>> Delete(int id)
        {
            try
            {
                Nota entity = await _db.Set<Nota>().FirstOrDefaultAsync(x => x.Id == id);
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

        public virtual async Task<GenericResponse<NotaResponse>> GetById(int id)
        {
            try
            {
                Nota entity = await _db.Set<Nota>().FirstOrDefaultAsync(x => x.Id == id);

                if (entity is not null)
                {
                    NotaResponse modelResponse = ConvertMapping<object, NotaResponse, Nota, object>.ConvertToResponseModel(entity);
                    return GenericResponse<NotaResponse>.ResponseOK(modelResponse);
                }
                else return GenericResponse<NotaResponse>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<NotaResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<NotaResponse>>> GetAll()
        {
            try
            {
                List<Nota> entityRecordList = await _db.Set<Nota>().ToListAsync();
                List<NotaResponse> modelListResponse = ConvertMapping<object, NotaResponse, Nota, object>.ConvertToResponseModelList(entityRecordList);
                if (modelListResponse.Count() > 0) return GenericResponse<IEnumerable<NotaResponse>>.ResponseOK(modelListResponse);
                else return GenericResponse<IEnumerable<NotaResponse>>.ResponseValidation(ConstansApp.Messages.NoData);
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<NotaResponse>>.ResponseError(ex.Message);
            }
        }
    }
}
