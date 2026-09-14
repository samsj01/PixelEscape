using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Jugador
    {
        int x;
        int y;
        int vida;
        int puntaje;
        double velocidad;

        public int X { get => x;}
        public int Y { get => y;}
        public int Vida { get => vida;}
        public int Puntaje { get => puntaje;}
        public double Velocidad { get => velocidad;}

        public Jugador()
        {
            this.x = 0;
            this.y = 0;
            this.vida = 3;
            this.puntaje = 0;
            this.velocidad = 5;
        }
    }
}
