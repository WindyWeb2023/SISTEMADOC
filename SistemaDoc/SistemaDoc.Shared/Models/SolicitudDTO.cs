using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDoc.Shared.Models
{
    public class SolicitudDTO
    {
        public int Id { get; set; }
        public string NombreSolicitante { get; set; } = null!;

        public string Referencia { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
        public string Observaciones { get; set; } = null!;
        public string Estado { get; set; } = "Pendiente";
        public string NombreArea { get; set; } = null!;
        public string NombreCategoria { get; set; } = null!;
        public string CargoUsuario { get; set; } = null!;
    }
}
