using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    public partial class Materia
    {
        public Materia()
        {
            Nota = new HashSet<Nota>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [StringLength(500)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("Materia")]
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
