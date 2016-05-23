using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroHora.Models
{
    public class Cliente: object
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Número de Horas")]
        public decimal NumHoras { get; set; }

        [Required]
        [Display(Name = "Tipo de Horas")]
        public string TipoHoras { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
