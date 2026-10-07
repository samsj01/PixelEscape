using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class CazadorPixel : Personaje
    {
        double rangoDeteccion;
        public double RangoDeteccion
        {
            get => rangoDeteccion;
            private set => rangoDeteccion = value;
        }
        public CazadorPixel() : base()
        {
            this.X = 30;
            this.Y = 0;
            this.Velocidad = 3;
            this.dano = 1;
            this.RangoDeteccion = 50;
        }

        bool CalcularDistancia(Personaje objetivo)
        {
            double deltaX = this.X - objetivo.X;
            double deltaY = this.Y - objetivo.Y;
            double distancia = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (distancia <= RangoDeteccion)
            {
                return true;
            }
            return false;
        }

        public override int Atacar(Personaje objetivo)
        {
            if (CalcularDistancia(objetivo))
            {
                objetivo.RecibirDano(this.dano);
                return dano;
            }
            return 0;
        }
    }
}
