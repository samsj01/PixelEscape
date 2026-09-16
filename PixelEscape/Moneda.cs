using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Moneda
    {
        int x;
        int y;
        int valor;
        bool recogida; // nuevo
        public int X { get => x; }
        public int Y { get => x; }
        public int Valor { get => valor; }
        public bool Recogida { get; set; } = false;
        Random rd = new Random(); // nuevo

        public Moneda()
        {
            this.x = rd.Next(1, 15);
            this.y = 0;
            this.valor = 100;
        }

        public void SerRecogida(Jugador jugador)
        {
            if (Recogida)
            {
                jugador.Puntaje += this.valor;
                Console.WriteLine($"Puntaje Nuevo : {jugador.Puntaje}");
                this.x = rd.Next(0, 15);
            }
            this.Recogida = false;
        }


    }
}
