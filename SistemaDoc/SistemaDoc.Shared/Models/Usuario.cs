using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDoc.Shared.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string Cargo { get; set; } = "";
        public string NombreUsuario { get; set; } = "";
        public string Contrasena { get; set; } = "";
        public string Rol { get; set; } = ""; // o "administrador"
    }
}
