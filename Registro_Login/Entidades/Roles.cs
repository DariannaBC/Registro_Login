using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Login.Entidades
{
    public class Roles
    {
        [Key]
        public int RolID { get; set; }
        public string DescripcionRol { get; set; }
        public bool EsActivo { get; set; }
        public DateTime FechaCreacion { get; set; }

        [ForeignKey("RolID")]
        public virtual List<RolesDetalle> Detalle { get; set; }

        public Roles()
        {
            RolID = 0;
            DescripcionRol = string.Empty;
            EsActivo = false;
            FechaCreacion = DateTime.Now;
            Detalle = new List<RolesDetalle>();
        }
    }
}
