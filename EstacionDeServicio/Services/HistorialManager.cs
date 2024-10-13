using EstacionDeServicio.Interfaces;
using EstacionDeServicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionDeServicio.Services
{
    public class HistorialManager : IHistorialManager
    {
        private List<Suministro> historial = new List<Suministro>();

        public void AgregarSuministro(Suministro suministro)
        {
            historial.Add(suministro);
        }

        public IEnumerable<Suministro> ObtenerHistorial()
        {
            //ordeno por importe y fecha
            return historial
                .OrderByDescending(s => s.ImporteFinal)
                .ThenByDescending(s => s.FechaHora);
        }
    }
}
