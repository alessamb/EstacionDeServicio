using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionDeServicio.Models
{
    public class Surtidor
    {
        public int Id { get; set; }
        public EstadoSurtidor Estado { get;  set; }
        public decimal? ImporteSol { get;  set; }

        public Surtidor(int id)
        {
            Id = id;
            Bloquear(); // Estado inicial
        }
        public void Bloquear()
        {
            Estado = EstadoSurtidor.Bloqueado;
            ImporteSol = null;
        }
        public void Liberar(decimal? importeSol = null)
        {
            if (importeSol.HasValue)
            {
                Estado = EstadoSurtidor.Prefijado;
                ImporteSol = importeSol.Value;
            }
            else
            {
                Estado = EstadoSurtidor.Libre;
                ImporteSol = null;
            }
        }


    }
}
