using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Llave : Coleccionables
    {
        public Llave(int x, int y) : base(x, y)
        {
        }

        // La llave no modifica al jugador: la Puerta consulta su estado Recogido.
        protected override void AplicarEfecto(Jugador jugador)
        {
        }
    }
}
