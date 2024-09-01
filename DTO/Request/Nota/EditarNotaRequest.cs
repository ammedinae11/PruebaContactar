using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request.Nota
{
    public class EditarNotaRequest
    {
        [Required(ErrorMessage = "El Id es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El Id debe ser un número positivo.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La MateriaId es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "La MateriaId debe ser un número positivo.")]
        public int MateriaId { get; set; }

        [Required(ErrorMessage = "El EstudianteId es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El EstudianteId debe ser un número positivo.")]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "La Nota es obligatorio.")]
        [Range(1, 5, ErrorMessage = "La Nota debe ser un número positivo y debe estar entre 1 y 5.")]
        public decimal Nota1 { get; set; }

        [Required(ErrorMessage = "El Semestre es obligatorio.")]
        [Range(20181, 29992, ErrorMessage = "El Semestre debe ser un número positivo.")]
        public short Semestre { get; set; }
    }
}
