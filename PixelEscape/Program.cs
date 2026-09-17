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

            Console.WriteLine($"x,y: {escapist.X},{escapist.Y}");
            
            escapist.MoverHorizontal(-5);

            Console.WriteLine($"x,y: {escapist.X},{escapist.Y}");

        }
    }
}
