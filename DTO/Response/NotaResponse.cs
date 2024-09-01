using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response
{
    public class NotaResponse
    {
        public int Id { get; set; }
        public int MateriaId { get; set; }
        public int EstudianteId { get; set; }
        public decimal Nota1 { get; set; }
        public short Semestre { get; set; }
    }
}
