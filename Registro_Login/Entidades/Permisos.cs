using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Login.Entidades
{
    public class Permisos
    {
        [Key]
        public int PermisosId { get; set; }
        public string Nombre { get; set; }
        public string DescripcionPermisos { get; set; }
        public int VecesAsignado { get; set; }

        [ForeignKey("PermisosId")]

        public virtual Permisos permiso { get; set; }
    }
}
