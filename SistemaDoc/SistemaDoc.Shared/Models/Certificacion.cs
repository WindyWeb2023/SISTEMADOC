using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDoc.Shared.Models
{
    public class Certificacion
    {
        public int Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Referencia { get; set; } = null!;
        public int IdSolicitud { get; set; }
        [ForeignKey("IdSolicitud")]
        public Solicitud? Solicitud { get; set; }

    }
}
