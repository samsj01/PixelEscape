using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    // Contrato mínimo de lo que se puede recoger (ISP/DIP).
    internal interface IRecolectable
    {
        bool Recogido { get; }
        void Recoger(Jugador jugador);
    }

    internal abstract class Coleccionables: ElementoGrafico, IRecolectable
    {
        protected bool recogido;

        public bool Recogido { get => recogido; set => recogido = value; }

        //constructor
        protected Coleccionables(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.recogido = false;
        }

        //metodos

        // Método plantilla: controla que se recoja una sola vez y delega el efecto
        // a cada subclase (OCP: un coleccionable nuevo no obliga a tocar esta clase).
        public void Recoger (Jugador jugador)
        {
            if (recogido)
            {
                return;
            }
            recogido = true;
            AplicarEfecto(jugador);
        }  

        protected abstract void AplicarEfecto(Jugador jugador);
        
    }

    

    // Base común de los power-ups con duración (evita repetir 'duracion' en cada uno).
    internal abstract class PowerUpTemporal : Coleccionables
    {
        int duracion;
        public int Duracion { get => duracion; set => duracion = value; }

        protected PowerUpTemporal(int x, int y, int duracion) : base(x, y)
        {
            this.duracion = duracion;
        }
    }

    internal class PowerUpVelocidad : PowerUpTemporal
    {
        const int VelocidadConPowerUp = 2;

        public PowerUpVelocidad(int x, int y, int duracion) : base(x, y, duracion)
        {
        }

        protected override void AplicarEfecto(Jugador jugador)
        {
            jugador.Velocidad = VelocidadConPowerUp;
        }
    }

    internal class PowerUpEscudo : PowerUpTemporal
    {
        public PowerUpEscudo(int x, int y, int duracion) : base(x, y, duracion)
        {
        }

        protected override void AplicarEfecto(Jugador jugador)
        {
            jugador.Vida += 1;
        }
    }

    
}
