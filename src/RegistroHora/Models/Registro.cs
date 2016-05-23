using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroHora.Models
{
    public class Registro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0}", ApplyFormatInEditMode = false)]
        public decimal Horas { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

        [Display(Name = "Proyecto")]
        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        public Registro()
        {
            Fecha = DateTime.Now;
        }
    }
}
