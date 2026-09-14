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
            Jugador escaper = new Jugador();
            Console.WriteLine($"el jugador esta posicionado en {escaper.X},{escaper.Y}"); 
        }
    }
}
