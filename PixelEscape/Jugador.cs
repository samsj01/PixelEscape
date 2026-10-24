using System;
using System.Collections.Generic;
using System.Drawing;
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
        

        public bool EnElSuelo { get; private set; } = true;
        public int Puntaje { get => puntaje; set => puntaje = value; }
        public int VelY { get => velY; set => velY = value; }
        public int FuerzaSalto { get => fuerzaSalto; }

        public Jugador(int x, int y, int w, int h, string name)
            : base(x, y, w, h, null)
        {
            this.X = x;
            this.Y = y;
            this.Vida = 3;
            this.Puntaje = 0;
            this.dano = 1;
        }
        public void Saltar()
        {
            if (EnElSuelo)
            {
                this.SetPos(X, this.Y -= FuerzaSalto * VelY);
                EnElSuelo = false;
            }
        }
        public void Aterrizar()
        {
            if (!EnElSuelo)
            {
                this.SetPos(X,this.Y += this.VelY * gravedad);
                if (this.Y == 0)
                {
                    EnElSuelo = true;
                }
            }

        }
    }
}
