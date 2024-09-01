using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    public partial class Nota
    {
        [Key]
        public int Id { get; set; }
        public int MateriaId { get; set; }
        public int EstudianteId { get; set; }
        [Column("Nota")]
        public decimal Nota1 { get; set; }
        public short Semestre { get; set; }

        [ForeignKey("EstudianteId")]
        [InverseProperty("Nota")]
        public virtual Estudiante Estudiante { get; set; } = null!;
        [ForeignKey("MateriaId")]
        [InverseProperty("Nota")]
        public virtual Materia Materia { get; set; } = null!;
    }
}
