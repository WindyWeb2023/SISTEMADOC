using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDoc.Shared.Models
{
    public class Solicitud
    {
        public int Id { get; set; }
        public string NombreSolicitante { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
        public string Observaciones { get; set; } = null!;
        public string Estado { get; set; } = "Pendiente"; // Estado por defecto
    }
}
