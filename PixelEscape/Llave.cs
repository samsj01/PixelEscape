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

        public void RecogerLlave(Personaje jugador)
        {
            if (!Recogido)
            {
                Recogido = true;
            }
            recogido = false;
        }
    }
}
