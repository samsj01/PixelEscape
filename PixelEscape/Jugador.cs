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
        int velY = 0; // nuevo
        const int GRAVEDAD = -1; // nuevo
        const int FUERZASALTO = 3; // nuevo 
        const int SUELO = 0; // nuevo

        public int X { get => x; }
        public int Y { get => y; }
        public int Vida { get => vida; }
        public int Velocidad { get => velocidad; }

        public bool EnElSuelo { get; private set; } = true;
        public int Puntaje { get => puntaje; set => puntaje = value; }

        public Jugador()
        {
            this.x = 0;
            this.y = 0;
            this.vida = 3;
            this.Puntaje = 0;
            this.velocidad = 2;
        }

        public void Moverse(ConsoleKey tecla, Moneda moneda1)
        {
            switch (tecla)
            {
                case ConsoleKey.A:
                    for (int i = 0; i < this.velocidad; i++)
                    {
                        this.x--;
                        Console.WriteLine($"{this.x},{this.y}");
                        RecogerObjetos(moneda1);
                    }
                    break;
                case ConsoleKey.D:
                    for (int i = 0; i < this.velocidad; i++)
                    {
                        this.x++;
                        Console.WriteLine($"{this.x},{this.y}");
                        RecogerObjetos(moneda1);
                    }
                    break;
                case ConsoleKey.W:
                    Saltar(tecla);
                    break;
                case ConsoleKey.Spacebar:
                    Atacar();
                    break;
                default:
                    break;
            }
        }

        public void Saltar(ConsoleKey tecla)
        {
            if (EnElSuelo)
            {
                this.velY = FUERZASALTO;
                EnElSuelo = false;
                Console.WriteLine($"{this.x},{this.y}");

            }
        }
        public void AplicarFisica()
        {
            if (!EnElSuelo)
            {
                y += velY;
                velY += GRAVEDAD;

                if (Y <= SUELO)
                {
                    y = SUELO;
                    velY = 0;
                    EnElSuelo = true;
                    Console.WriteLine($"(Aterrizaje) Posición: ({X}, {Y})");
                }
                else
                {
                    Console.WriteLine($"(En Aire) Posición: ({X}, {Y})");
                }
            }
        }

        public void Atacar()
        {
            Console.WriteLine("ATAQUE");
        }

        public void RecogerObjetos(Moneda moneda1)
        {
            if (this.x == moneda1.X)
            {
                Console.WriteLine("Recogiste una moneda");
                moneda1.Recogida = true;
                moneda1.SerRecogida(this);
            }
        }
    }
}
