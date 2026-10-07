using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Jugador : Personaje
    {
        int puntaje;
        int velY = 1;
        int gravedad = 1;
        int fuerzaSalto = 3;
        int suelo = 0;

        public bool EnElSuelo { get; private set; } = true;
        public int Puntaje { get => puntaje; set => puntaje = value; }
        public int VelY { get => velY; set => velY = value; }
        public int FuerzaSalto { get => fuerzaSalto; }

        public Jugador() : base()
        {
            this.X = 0;
            this.Y = 0;
            this.Vida = 3;
            this.Puntaje = 0;
            this.dano = 1;
        }
        public void Saltar()
        {
            if (EnElSuelo)
            {
                this.Y += FuerzaSalto * VelY;
                EnElSuelo = false;
            }
        }
        public void Aterrizar()
        {
            if (!EnElSuelo)
            {
                this.Y -= this.VelY * gravedad;
                if (this.Y == suelo)
                {
                    EnElSuelo = true;
                }
            }

        }
    }
}
