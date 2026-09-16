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
        bool estaVivo;

        public int X { get => x; }
        public int Y { get => y; }
        public int Vida { get => vida; set => vida = value; }
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
            this.estaVivo = true;
        }

        public void Moverse(ConsoleKey tecla, Moneda moneda1, Llave llave1,
            CazadorPixel cazador, GuardianPixel guardian, Trampa trampita)
        {
            switch (tecla)
            {
                case ConsoleKey.A:
                    for (int i = 0; i < this.velocidad; i++)
                    {
                        this.x--;
                        Console.Write($"{this.x},{this.y} ");
                        RecogerObjetos(moneda1,llave1);
                        PerderVida(cazador, guardian, trampita);
                    }
                    break;
                case ConsoleKey.D:
                    for (int i = 0; i < this.velocidad; i++)
                    {
                        this.x++;
                        Console.Write($"{this.x},{this.y} ");
                        RecogerObjetos(moneda1,llave1);
                        PerderVida(cazador, guardian, trampita);
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

        public void RecogerObjetos(Moneda moneda1, Llave llave1)
        {
            
            if (this.x == moneda1.X)
            {
                Console.WriteLine("\nRecogiste una moneda");
                moneda1.Recogida = true;
                moneda1.SerRecogida(this);
            }
            if (!llave1.Recogida)
            {
                if (llave1.X == this.X)
                {
                    Console.WriteLine("\nSe ha hagarrado la llave");
                    llave1.Recoger(this);
                }
            }
            
        }

        public void RecogerPW()
        {

        }

        public void PerderVida(CazadorPixel cazador, 
            GuardianPixel guardian, Trampa trampa)
        {
           if((cazador.PosicionX == this.X) && this.Vida >0)
           {
                this.Vida -= cazador.Atacar(this);
                Console.WriteLine($"Te quedan {this.Vida} vidas");
           }else
            {
                Muerte();
            }

            if ((trampa.PosicionX == this.X) && this.Vida > 0)
            {
                this.Vida -= trampa.CausarDano();
                Console.WriteLine($"Te quedan {this.Vida} vidas");
            }
            else
            {
                Muerte();
            }
            if ((guardian.X == this.X) && this.Vida > 0)
            {
                this.Vida -= guardian.Atacar(this);
                Console.WriteLine($"Te quedan {this.Vida} vidas");
            }
            else
            {
                Muerte();
            }
        }
        public void Muerte()
        {
            if(this.Vida == 0)
            {
                Console.WriteLine("Estas Muerto");
                this.estaVivo = false;
            }
            
        }
    }
}
