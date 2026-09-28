using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class GuardianPixel
    {
        int x;
        int y;
        int vel;
        int daño;
        bool direccion = false;

        public int X { get => x; private set => x = value; }
        public int Y { get => y;}
        public int Vel { get => vel;}
        public int Daño { get => daño; }
        public bool Direccion { get => direccion; private set => direccion = value;}

        public GuardianPixel()
        {
            this.x = 10;
            this.y = 0;
            this.vel = 1;
            this.daño = 1;
        }
        public void Patrullar()
        {
            if(!Direccion)
            {
                //camina de izquierda a derecha
                this.X = this.X + 4 * vel;
                Direccion = true;
            } else
            {
                //camina de derecha a izquierda
                this.X = this.X - 4 * vel;
                Direccion = false;
            }
        }

        public int Atacar(Jugador escapist)
        {
            return Daño;
        }
    }
}
