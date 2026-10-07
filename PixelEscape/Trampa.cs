using System;
namespace PixelEscape
{


    internal class Trampa : ObjetoActivable
    {
        // Atributos privados
        private int dano;
        private bool activa;

        // Propiedad para el daño
        public int Dano
        {
            get
            {
                return dano;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Dano),
                        "El daño debe ser mayor que cero."
                    );
                }

                dano = value;
            }
        }

        // Propiedad para saber si la trampa está activa
        public bool Activa
        {
            get
            {
                return activa;
            }
            private set
            {
                activa = value;
            }
        }

        // Constructor
        public Trampa(int posicionX, int posicionY, int dano)
        {
            PosicionX = posicionX;
            PosicionY = posicionY;
            Dano = dano;
            Activa = false;
        }

       // Trampa Activa
        public override bool Activar(Personaje escapista)
        {
            if (escapista.X == this.posicionX)
            {
                Activa = true;
            }

            return Activa;
    
        }

        // Retorna el daño que causa la trampa
        public int CausarDano()
        {
            if (Activa)
            {
                return Dano;
            }

            return 0;
        }
    }
}