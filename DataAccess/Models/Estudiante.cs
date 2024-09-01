using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    [Table("Estudiante")]
    public partial class Estudiante
    {
        public Estudiante()
        {
            Nota = new HashSet<Nota>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;

        [InverseProperty("Estudiante")]
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
