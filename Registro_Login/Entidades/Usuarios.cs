using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Login.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Clave { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public string DescripcionRol { get; set; }
        public string Alias { get; set; }
        public bool Activo { get; set; }
    }
}