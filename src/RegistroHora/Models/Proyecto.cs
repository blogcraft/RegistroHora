using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroHora.Models
{
    public class Proyecto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        [Display(Name = "Inicio de Proyecto")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaInicio { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        [Display(Name = "Envio a Certificacion")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCertificacion { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        [Display(Name = "Compromiso")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCompromiso { get; set; }

        [Display(Name = "Avance")]
        [Range(0d,100d)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0} %")]
        public decimal PorcAvance { get; set; }

        [DataType(DataType.Text)]
        public string Estado { get; set; }

        [Display(Name = "Finalizado")]
        public bool Concluido { get; set; }

        public virtual ICollection<Registro> Registros { get; set; }

        [Display(Name = "Tipo de Proyecto")]
        public int? TipoProyectoId { get; set; }
        [Display(Name = "Tipo")]
        public virtual TipoProyecto TipoProyecto { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { get; set; }

        public Proyecto()
        {
            FechaInicio = DateTime.Now;
            PorcAvance = 0m;
            Concluido = false;
        }
    }
}
