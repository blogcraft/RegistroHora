using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroHora.Models
{
    public class TipoProyecto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
