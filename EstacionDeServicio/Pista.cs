using EstacionDeServicio.Interfaces;
using EstacionDeServicio.Models;
using EstacionDeServicio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionDeServicio
{
    public class Pista
    {
        private readonly ISurtidorManager _surtidor;
        private readonly IHistorialManager _historial;

        public Pista(int cantidadSurtidores)
        {
            _historial = new HistorialManager();
            _surtidor = new Surtidors(cantidadSurtidores, _historial);
        }

        public void LiberarSurtidor(int surtidorId, decimal? importeSol = null)
        {
            _surtidor.LiberarSurtidor(surtidorId, importeSol);
        }

        public void BloquearSurtidor(int surtidorId)
        {
            _surtidor.BloquearSurtidor(surtidorId);
        }

        public IEnumerable<Surtidor> ObtenerEstadoSurtidores()
        {
            return _surtidor.ObtenerEstadoSurtidores();
        }

        public IEnumerable<Suministro> ObtenerHistorialSuministros()
        {
            return _historial.ObtenerHistorial();
        }

        public void RegistrarSuministro(int surtidorId, decimal importeFinal)
        {
            _surtidor.RegistrarSuministro(surtidorId, importeFinal);
        }
    }
}
