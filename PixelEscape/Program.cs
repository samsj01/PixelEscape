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
            Console.WriteLine($"el jugador esta posicionado en {escapist.X},{escapist.Y}");
            Console.WriteLine($"El jugador tiene {escapist.Vida} vidas");

            while (true)
            {
                // Lectura de teclado no bloqueante para mantener la física corriendo
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Escape)
                        break;

                    escapist.Moverse(teclaInfo.Key);
                }

                // Actualizar la física en cada iteración
                escapist.AplicarFisica();

                // Pausa corta (FPS/ritmo del juego)
                Thread.Sleep(150);
            }

        }
    }
}
