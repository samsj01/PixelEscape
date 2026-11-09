using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Jugador : Personaje
    {
        int puntaje;
        double vely = 0;   // velocidad vertical actual del salto (positiva = subiendo)
        double velx = 0;   // velocidad horizontal del salto (negativa = izquierda)
        int gravedad = 3;
        int fuerzaSalto = 3;
        double tiempo;
        double angulo;
        double velSalto;

        // Ángulos de lanzamiento del salto
        const double AnguloVertical = Math.PI / 2;   // 90°: salto recto
        const double AnguloParabolico = Math.PI / 3; // 60°: salto con desplazamiento lateral

        // Estado del salto en curso
        int movimientoHorizontal;  // -1 izquierda, 0 quieto, 1 derecha (solo vale en el fotograma actual)
        bool saltoParabolico;
        int origenX;
        int sueloY;
        double tiempoVuelo;


        public bool EnElSuelo { get; private set; } = true;
        public int Puntaje { get => puntaje; set => puntaje = value; }
        public double VelY { get => vely; set => vely = value; }
        public int FuerzaSalto { get => fuerzaSalto; }
        public double VelSalto { get => velSalto; protected set => velSalto = value; }
        public bool SaltoParabolico { get => saltoParabolico; }

        public Jugador(int x, int y, int w, int h, string name)
            : base(x, y, w, h, name)
        {
            this.Vida = 3;
            this.Puntaje = 0;
            this.dano = 1;
            this.tiempo = 0.25; // Intervalo de tiempo para la simulación (por fotograma)
            this.angulo = 0;
            this.VelSalto = 5; // Velocidad inicial del salto (se multiplica por FuerzaSalto)
        }

        // El desplazamiento horizontal en el aire lo controla el propio salto;
        // en el suelo se mueve normal y se recuerda para decidir el tipo de salto.
        public override bool MoverIzq()
        {
            if (!EnElSuelo)
            {
                return false;
            }
            movimientoHorizontal = -1;
            return base.MoverIzq();
        }

        public override bool MoverDer()
        {
            if (!EnElSuelo)
            {
                return false;
            }
            movimientoHorizontal = 1;
            return base.MoverDer();
        }

        // Inicia el salto. Orden esperado en cada fotograma: MoverIzq/MoverDer -> Saltar -> Aterrizar.
        // - Si en este fotograma se movió a un lado: salto parabólico (60°, avanza hacia ese lado).
        // - Si no se movió: salto vertical (90°, la X no cambia).
        public void Saltar()
        {
            if (!EnElSuelo)
            {
                return;
            }

            saltoParabolico = movimientoHorizontal != 0;
            angulo = saltoParabolico ? AnguloParabolico : AnguloVertical;

            double velInicial = VelSalto * FuerzaSalto;
            velx = saltoParabolico ? velInicial * Math.Cos(angulo) * movimientoHorizontal : 0;
            vely = velInicial * Math.Sin(angulo);

            origenX = X;
            sueloY = Y;
            tiempoVuelo = 0;
            EnElSuelo = false;
        }

        // Avanza un fotograma de la simulación: el jugador sube y baja solo por la gravedad
        // y aterriza cuando vuelve a la altura de la que despegó. Se llama una vez por fotograma.
        //   x(t) = origenX + velx * t
        //   y(t) = sueloY - (v0y * t - 1/2 * gravedad * t^2)     (el eje Y crece hacia abajo)
        public void Aterrizar()
        {
            if (!EnElSuelo)
            {
                double velInicialY = VelSalto * FuerzaSalto * Math.Sin(angulo);
                double duracionVuelo = 2 * velInicialY / gravedad;

                tiempoVuelo += tiempo;
                bool aterriza = tiempoVuelo >= duracionVuelo;
                if (aterriza)
                {
                    tiempoVuelo = duracionVuelo;
                }

                double altura = velInicialY * tiempoVuelo - 0.5 * gravedad * tiempoVuelo * tiempoVuelo;
                int nuevaX = (int)Math.Round(origenX + velx * tiempoVuelo);
                int nuevaY = aterriza ? sueloY : (int)Math.Round(sueloY - altura);
                this.SetPos(nuevaX, nuevaY);

                if (aterriza)
                {
                    EnElSuelo = true;
                    saltoParabolico = false;
                    velx = 0;
                    vely = 0;
                }
                else
                {
                    vely = velInicialY - gravedad * tiempoVuelo;
                }
            }

            // Termina el fotograma: el movimiento lateral solo cuenta para el salto del mismo fotograma.
            movimientoHorizontal = 0;
        }
    }
}
