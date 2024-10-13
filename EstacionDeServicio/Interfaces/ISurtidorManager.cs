using EstacionDeServicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionDeServicio.Interfaces
{
    public interface ISurtidorManager
    {
        void LiberarSurtidor(int surtidorId, decimal? importeSol = null);
        void BloquearSurtidor(int surtidorId);
        IEnumerable<Surtidor> ObtenerEstadoSurtidores();
        void RegistrarSuministro(int surtidorId, decimal importeFinal);

    }
}
