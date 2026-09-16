using System;
namespace PixelEscape
{


    internal class Trampa
    {
        // Atributos privados
        private int posicionX;
        private int posicionY;
        private int dano;
        private bool activa;

        // Propiedad para la posición X
        public int PosicionX
        {
            get
            {
                return posicionX;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(PosicionX),
                        "La posición X no puede ser negativa."
                    );
                }

                posicionX = value;
            }
        }

        // Propiedad para la posición Y
        public int PosicionY
        {
            get
            {
                return posicionY;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(PosicionY),
                        "La posición Y no puede ser negativa."
                    );
                }

                posicionY = value;
            }
        }

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

        // Activa la trampa
        public void Activar(Jugador escapist)
        {
            if (escapist.X == this.posicionX)
            {
                Activa = true;
            }
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