using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionDeServicio.Models
{
    public class Suministro
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal? ImporteSol { get; set; }
        public decimal ImporteFinal { get; set; }

        public Suministro(int surtidorId, DateTime fechaHora, decimal? importeSol, decimal importeFinal)
        {
            Id = surtidorId;
            FechaHora = fechaHora;
            ImporteSol = importeSol;
            ImporteFinal = importeFinal;
        }
    }
}
