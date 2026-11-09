using System;

namespace PixelEscape
{
    // Pruebas por consola de las clases del juego.
    internal class Program
    {
        static void Main(string[] args)
        {
            Jugador jugador = new Jugador(0, 0);

            ProbarMovimiento(jugador);
            ProbarAtaqueCazador(jugador);
            ProbarSaltos(jugador);
            ProbarGuardian(jugador);
            ProbarObjetos();
        }

        static string Pos(Personaje p)
        {
            return $"{{X={p.X},Y={p.Y}}}";
        }

        static void ProbarMovimiento(Jugador jugador)
        {
            Console.WriteLine($"posición: {Pos(jugador)}");
            jugador.MoverIzq(); // un paso a la izquierda
            Console.WriteLine($"posición: {Pos(jugador)}");
        }

        static void ProbarAtaqueCazador(Jugador jugador)
        {
            CazadorPixel cazador = new CazadorPixel();
            Console.WriteLine($"Jugador tiene {jugador.Vida} vidas");
            cazador.Atacar(jugador, true);
            Console.WriteLine($"Jugador tiene {jugador.Vida} vidas");

            // Fin del fotograma: el MoverIzq anterior ya no cuenta para el próximo salto.
            jugador.Aterrizar();
        }

        static void ProbarSaltos(Jugador jugador)
        {
            Console.WriteLine("Salto vertical");
            jugador.Saltar();
            SimularVuelo(jugador);

            Console.WriteLine("Salto parabólico hacia la derecha");
            jugador.MoverDer();
            jugador.Saltar();
            SimularVuelo(jugador);

            Console.WriteLine("Salto parabólico hacia la izquierda");
            jugador.MoverIzq();
            jugador.Saltar();
            SimularVuelo(jugador);

            Console.WriteLine($"En el suelo: {jugador.EnElSuelo}");
        }

        static void ProbarGuardian(Jugador jugador)
        {
            GuardianPixel guardian = new GuardianPixel();
            Console.WriteLine($"posición: {Pos(guardian)}");
            guardian.MoverIzq();
            Console.WriteLine($"posición: {Pos(guardian)}");
            guardian.MoverDer();
            Console.WriteLine($"posición: {Pos(guardian)}");

            for (int i = 0; i < 2; i++)
            {
                guardian.Atacar(jugador, true);
                Console.WriteLine($"Jugador tiene {jugador.Vida} vidas");
                Console.WriteLine($"El jugador esta vivo?: {!jugador.EstaMuerto()}");
            }
        }

        static void ProbarObjetos()
        {
            Console.WriteLine("--- Objetos ---");
            Jugador jugador = new Jugador(10, 0);

            new Moneda(10, 0).Recoger(jugador);
            Console.WriteLine($"Puntaje tras la moneda: {jugador.Puntaje}");

            

            Trampa trampa = new Trampa(10, 0, 1);
            Console.WriteLine($"Trampa activada: {trampa.Activar(jugador)}  Vidas: {jugador.Vida}");

            Puerta puerta = new Puerta(50, 0);
            Console.WriteLine($"Puerta abierta sin llave: {puerta.Abrir(jugador)}");
            new Llave(20, 0).Recoger(jugador);
            Console.WriteLine($"Puerta abierta con llave: {puerta.Abrir(jugador)}");

            PuntoControl punto = new PuntoControl(0, 0);
            Console.WriteLine($"Punto de control activo: {punto.Activar(jugador)}");
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
                    Console.WriteLine($"fotograma {fotograma}: {Pos(jugador)}  VelY: {jugador.VelY:0.00}");
                }
            }
            Console.WriteLine($"En el suelo: {jugador.EnElSuelo}");
        }
    }
}
