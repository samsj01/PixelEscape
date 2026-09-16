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
            Trampa trampita = new Trampa(17,0,1);
            Power_up pw = new Power_up(3,0,10,"Escudo");
            GuardianPixel enemigo1 = new GuardianPixel();
            CazadorPixel cazador = new CazadorPixel(); 
            Llave llave1 = new Llave(20,0);
            Jugador escapist = new Jugador();
            Moneda moneda1 = new Moneda();
            Console.WriteLine($"el jugador esta posicionado en {escapist.X},{escapist.Y}");
            Console.WriteLine("Controles: A (Izquierda), D (Derecha), " +
                "W (Saltar), ESC (Salir)\n");

            while (true)
            {
                // Lectura de teclado no bloqueante para mantener la física corriendo
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Escape)
                        break;

                    escapist.Moverse(teclaInfo.Key, moneda1, llave1, 
                        cazador,enemigo1,trampita);
                }
                escapist.AplicarFisica();
                Thread.Sleep(150);
            }
            Console.Clear();
            Console.WriteLine("GuardianPixel Patrullando");
            while (true)
            {
                enemigo1.Patrullar();
            }

        }
    }
}
