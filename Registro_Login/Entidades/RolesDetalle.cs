using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Login.Entidades
{
    public class RolesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int RolID { get; set; }
        public int PermisosId { get; set; }
        public bool EsAsignado { get; set; }

        public RolesDetalle()
        {
            Id = 0;
            RolID = 0;
            PermisosId = 0;
            EsAsignado = false;
        }

        public RolesDetalle(int id, int rolid, int permisoid, bool asigned)
        {
            Id = id;
            RolID = rolid;
            PermisosId = permisoid;
            EsAsignado = asigned;
        }
    }
}
