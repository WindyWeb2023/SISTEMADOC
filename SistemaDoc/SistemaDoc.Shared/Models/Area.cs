using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDoc.Shared.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
       
        public List<Solicitud>? Solicituds { get; set; }
        
    }
}
