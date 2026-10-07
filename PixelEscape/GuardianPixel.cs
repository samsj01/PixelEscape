using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class GuardianPixel : Personaje
    {
        public GuardianPixel() : base()
        {
            this.X = 50;
            this.Y = 0;
            this.Velocidad = 1;
            this.dano = 1;
        }

    }
}
