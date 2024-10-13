using EstacionDeServicio.Interfaces;
using EstacionDeServicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionDeServicio.Services
{
    public class Surtidors : ISurtidorManager
    {
        private readonly Dictionary<int, Surtidor> surtidores;
        private readonly IHistorialManager histSuministros;

        public Surtidors(int nroSurtidores, IHistorialManager historial)
        {
            histSuministros = historial;
            surtidores = new Dictionary<int, Surtidor>();
            for (int i = 1; i <= nroSurtidores; i++)
            {
                surtidores.Add(i, new Surtidor(i));
            }
        }

        public bool Validar(int id)
        {
            if (!surtidores.ContainsKey(id))
                throw new ArgumentException("El surtidor no existe.");
            return true;

        }

        public void LiberarSurtidor(int surtidorId, decimal? importeSol = null)
        {
            if (Validar(surtidorId))
                surtidores[surtidorId].Liberar(importeSol);
        }

        public void BloquearSurtidor(int surtidorId)
        {
            if (Validar(surtidorId))
                surtidores[surtidorId].Bloquear();
        }

        public IEnumerable<Surtidor> ObtenerEstadoSurtidores()
        {
            return surtidores.Values;
        }

        public void RegistrarSuministro(int surtidorId, decimal importeFinal)
        {
            if (Validar(surtidorId));

            var surtidor = surtidores[surtidorId];
            if (surtidor.Estado == EstadoSurtidor.Bloqueado)
                throw new InvalidOperationException("El surtidor está bloqueado.");

            if (surtidor.ImporteSol.HasValue && importeFinal > surtidor.ImporteSol.Value)
                throw new InvalidOperationException("El importe a surtir excede el importe solicitado.");

            var suministro = new Suministro(
                surtidorId,
                DateTime.Now,
                surtidor.ImporteSol,
                importeFinal
            );

            histSuministros.AgregarSuministro(suministro);

            // Después del suministro, bloquear el surtidor y eliminar cualquier importe solicitado
            surtidor.Bloquear();
        }
    }
}
