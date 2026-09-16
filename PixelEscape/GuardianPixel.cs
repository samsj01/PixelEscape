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
        bool direccion;

        public int X { get => x;}
        public int Y { get => y;}
        public int Vel { get => vel;}
        public int Daño { get => daño; }
        public bool Direccion { get; set; } = false;

        public GuardianPixel()
        {
            this.x = 10;
            this.y = 0;
            this.vel = 1;
            this.daño = 1;
        }
        public void Patrullar()
        {
            for (int i = 0; i < 6; i++)
            {
                this.x = this.x + 1 * vel;
                Console.Write($"{this.x},{this.y} ");
                Direccion = true;
                Thread.Sleep(150);
            }
            Console.WriteLine("\n");
            for (int i = 0; i < 6; i++)
            {
                this.x = this.x - 1 * vel;
                Console.Write($"{this.x},{this.y} ");
                Direccion = false;
                Thread.Sleep(150);
            }
            Console.WriteLine("\n");
        }

        public int Atacar(Jugador escapist)
        {
            Console.WriteLine("ATAQUE");
            return daño;
        }
    }
}
