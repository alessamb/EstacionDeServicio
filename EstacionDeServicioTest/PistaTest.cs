using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionDeServicio;
using EstacionDeServicio.Models;

namespace EstacionDeServicioTest
{
    public class PistaTest
    {
        [Fact]
        public void LiberarSurtidorTest()
        {
            var pista = new Pista(1);

            pista.LiberarSurtidor(1);
            var surtidor = pista.ObtenerEstadoSurtidores().First();

            Assert.Equal(EstadoSurtidor.Libre, surtidor.Estado);
            Assert.Null(surtidor.ImporteSol);
        }

        [Fact]
        public void RegistrarSuministroOkTest()
        {

            var pista = new Pista(1);
            pista.LiberarSurtidor(1);

     
            decimal importeFinal = 50m;
            pista.RegistrarSuministro(1, importeFinal);
            var surtidor = pista.ObtenerEstadoSurtidores().First();

        
            Assert.Equal(EstadoSurtidor.Bloqueado, surtidor.Estado);
            Assert.Null(surtidor.ImporteSol);
        }

        [Fact]
        public void RegistrarSuministroMaxTest()
        {

            var pista = new Pista(1);
            decimal prefijo = 100m;
            pista.LiberarSurtidor(1, prefijo);


            decimal importeFinal = 150m;
            var exception = Assert.Throws<InvalidOperationException>(() =>
                pista.RegistrarSuministro(1, importeFinal)
            );

            Assert.Equal("El importe surtido excede el importe prefijado.", exception.Message);
        }

        [Fact]
        public void RegistrarSuministroTest()
        {

            var pista = new Pista(1);
            // El surtidor ya está bloqueado por defecto
            decimal importeFinal = 50m;
            var exception = Assert.Throws<InvalidOperationException>(() =>
                pista.RegistrarSuministro(1, importeFinal)
            );

            Assert.Equal("El surtidor está bloqueado.", exception.Message);
        }

        [Fact]
        public void ObtenerHistorialSuministrosTest()
        {
            var pista = new Pista(2);
            pista.LiberarSurtidor(1);
            pista.RegistrarSuministro(1, 150m);
            pista.LiberarSurtidor(2, 200m);
            pista.RegistrarSuministro(2, 200m);
            pista.LiberarSurtidor(1);
            pista.RegistrarSuministro(1, 200m);

            var historial = pista.ObtenerHistorialSuministros().ToList();
  
            Assert.Equal(3, historial.Count());

            // El suministro de 200€ en surtidor 1 debería ser el primero (más reciente)
            Assert.Equal(200m, historial[0].ImporteFinal);
            Assert.Equal(1, historial[0].Id);

            //// El suministro de 200€ en surtidor 2 debería ser el segundo
            Assert.Equal(200m, historial[1].ImporteFinal);
            Assert.Equal(2, historial[1].Id);

            //// El suministro de 150€ en surtidor 1 debería ser el tercero
            Assert.Equal(150m, historial[2].ImporteFinal);
            Assert.Equal(1, historial[2].Id);
        }


    }
}
