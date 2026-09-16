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
        int velocidad;
        int  velY = 0; // nuevo
        const int GRAVEDAD = -1; // nuevo
        const int FUERZASALTO = 3; // nuevo 
        const int SUELO = 0;

        public int X { get => x;}
        public int Y { get => y;}
        public int Vida { get => vida;}
        public int Puntaje { get => puntaje;}
        public int Velocidad { get => velocidad; }

        public bool EnElSuelo { get; } = true;

        public Jugador()
        {
            this.x = 0;
            this.y = 0;
            this.vida = 3;
            this.puntaje = 0;
            this.velocidad = 1;
        }

        public void Moverse(ConsoleKey tecla) 
        {
            switch (tecla)
            {
                case ConsoleKey.A:
                    this.x = this.x - 1 - this.velocidad;
                    Console.WriteLine($"{this.x},{this.y}");
                    break;
                case ConsoleKey.D:
                    this.x = this.x + 1 + this.velocidad;
                    Console.WriteLine($"{this.x},{this.y}");
                    break;
                case ConsoleKey.W:
                    Saltar(tecla);
                    break;
                default:
                    break;
            }
        }

        public void Saltar(ConsoleKey tecla)
        {
            if (EnElSuelo)
            {
                
            }
        }
    }
}
