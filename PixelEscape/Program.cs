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
            Jugador escapist = new Jugador(0, 0, 32, 32, "jugador");
            
            // posición Predefinida.
            Console.WriteLine($"posición: {escapist.Ubicacion}");
            //Mover 5 pasos a la izquierda.
            escapist.MoverIzq();
            //nueva posición.
            Console.WriteLine($"posición: {escapist.Ubicacion}");

            //Se crea cazador
            CazadorPixel cazador = new CazadorPixel();
            Console.WriteLine($"Jugador tiene {escapist.Vida} vidas");
            //Cazador hiere
            escapist.RecibirDano(cazador.Atacar(escapist, true));
            Console.WriteLine($"Jugador tiene {escapist.Vida} vidas");

            // Salto
            escapist.Saltar();
            Console.WriteLine("Salto");
            Console.WriteLine($"x,y: {escapist.X},{escapist.Y}");
            Console.WriteLine($"En el suelo: {escapist.EnElSuelo}");

            //Aterrizaje
            Console.WriteLine("Aterrizando");
            for(int i = 0; i < escapist.FuerzaSalto; i++)
            {
                escapist.Aterrizar();
                Console.WriteLine($"posición: {escapist.Ubicacion}");
            }

            Console.WriteLine($"En el suelo: {escapist.EnElSuelo}");

            GuardianPixel guardian = new GuardianPixel();
            Console.WriteLine($"posición: {guardian.Ubicacion}");
            guardian.MoverIzq();
            Console.WriteLine($"posición: {guardian.Ubicacion}");
            guardian.MoverDer();
            Console.WriteLine($"posición: {guardian.Ubicacion}");
            escapist.RecibirDano(guardian.Atacar(escapist, true));
            Console.WriteLine($"Jugador tiene {escapist.Vida} vidas");
            Console.WriteLine($"El jugador esta vivo?: {escapist.EstaMuerto()}");
            escapist.RecibirDano(guardian.Atacar(escapist, true));
            Console.WriteLine($"Jugador tiene {escapist.Vida} vidas");
            Console.WriteLine($"El jugador esta vivo?: {escapist.EstaMuerto()}");



        }
    }
}
