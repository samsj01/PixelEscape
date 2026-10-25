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

            // Fin del fotograma: el MoverIzq anterior ya no cuenta para el próximo salto.
            escapist.Aterrizar();

            // Salto vertical: salta sin moverse a los lados.
            Console.WriteLine("Salto vertical");
            escapist.Saltar();
            SimularVuelo(escapist);

            // Salto parabólico: se mueve a la derecha y salta en el mismo fotograma.
            Console.WriteLine("Salto parabólico hacia la derecha");
            escapist.MoverDer();
            escapist.Saltar();
            SimularVuelo(escapist);

            // Salto parabólico hacia la izquierda.
            Console.WriteLine("Salto parabólico hacia la izquierda");
            escapist.MoverIzq();
            escapist.Saltar();
            SimularVuelo(escapist);


            Console.WriteLine($"En el suelo: {escapist.EnElSuelo}");

            GuardianPixel guardian = new GuardianPixel();
            Console.WriteLine($"posición: {guardian.Ubicacion}");
            guardian.MoverIzq();
            Console.WriteLine($"posición: {guardian.Ubicacion}");
            guardian.MoverDer();
            Console.WriteLine($"posición: {guardian.Ubicacion}");
            escapist.RecibirDano(guardian.Atacar(escapist, true));
            Console.WriteLine($"Jugador tiene {escapist.Vida} vidas");
            Console.WriteLine($"El jugador esta vivo?: {!escapist.EstaMuerto()}");
            escapist.RecibirDano(guardian.Atacar(escapist, true));
            Console.WriteLine($"Jugador tiene {escapist.Vida} vidas");
            Console.WriteLine($"El jugador esta vivo?: {!escapist.EstaMuerto()}");



        }

        // Avanza el salto fotograma a fotograma hasta que el jugador aterriza.
        static void SimularVuelo(Jugador jugador)
        {
            Console.WriteLine($"Parabólico: {jugador.SaltoParabolico}");
            int fotograma = 0;
            while (!jugador.EnElSuelo)
            {
                jugador.Aterrizar();
                fotograma++;
                if (fotograma % 5 == 0 || jugador.EnElSuelo)
                {
                    Console.WriteLine($"fotograma {fotograma}: {jugador.Ubicacion}  VelY: {jugador.VelY:0.00}");
                }
            }
            Console.WriteLine($"En el suelo: {jugador.EnElSuelo}");
        }
    }
}
