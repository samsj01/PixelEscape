using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
    }
}
