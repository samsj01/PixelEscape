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

        public CazadorPixel(int x, int y, int w, int h, string nombre) :
           base(x, y, w, h, nombre)
        {
            this.Vida = 1;
            this.Velocidad = 2;
            this.EstaVivo = true;
            this.dano = 1;
            this.Direccion = "Derecha";
        }
        public CazadorPixel() : base()
        {
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

        public override int Atacar(Personaje objetivo, bool colision)
        {
            this.Colision = colision;
            if (CalcularDistancia(objetivo) && Colision)
            {
                objetivo.RecibirDano(this.dano);
            }
            return 0;
        }
    }
}
