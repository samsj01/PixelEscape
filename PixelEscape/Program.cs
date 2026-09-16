using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jugador escapist = new Jugador();
            Moneda moneda1 = new Moneda();
            Console.WriteLine($"el jugador esta posicionado en {escapist.X},{escapist.Y}");
            Console.WriteLine("Controles: A (Izquierda), D (Derecha), " +
                "W (Saltar), ESC (Salir)\n");
            Console.WriteLine($"moneda en x  es {moneda1.X}");

            while (true)
            {
                // Lectura de teclado no bloqueante para mantener la física corriendo
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Escape)
                        break;

                    escapist.Moverse(teclaInfo.Key, moneda1);
                }
                escapist.AplicarFisica();
                Thread.Sleep(150);
            }

        }
    }
}
