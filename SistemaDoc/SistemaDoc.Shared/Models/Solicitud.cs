using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDoc.Shared.Models
{
    public class Solicitud
    {
        public int Id { get; set; }
        public string NombreSolicitante { get; set; } = null!;
        public string Referencia { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
        public string Observaciones { get; set; } = null!;
        public string Estado { get; set; } = "Pendiente"; // Estado por defecto
        public int IdArea { get; set; }
        [ForeignKey("IdArea")]
        public Area? Area { get; set; }
        public int IdUsuario { get; set; } = 1;
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public Categoria? Categoria { get; set; }
        public List<Certificacion>? Certificacions { get; set; }
    }
}
