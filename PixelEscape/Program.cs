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
            
            // posición Predefinida.
            Console.WriteLine($"x,y: {escapist.X},{escapist.Y}");
            //Mover 5 pasos a la izquierda.
            escapist.MoverHorizontal(-5);
            //nueva posición.
            Console.WriteLine($"x,y: {escapist.X},{escapist.Y}");
            
            //Se crea cazador
            CazadorPixel cazador = new CazadorPixel();
            Console.WriteLine($"Jugador tiene {escapist.Vida} vidas");
            //Cazador hiere
            escapist.RecibirDano(cazador.Atacar(escapist));
            Console.WriteLine($"Jugador tiene {escapist.Vida} vidas");


        }
    }
}
