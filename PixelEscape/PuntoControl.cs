using System;

namespace PixelEscape
{
    

    public class PuntoControl
    {
        // Atributos privados
        private int posicionX;
        private int posicionY;
        private bool activo;

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

        // Propiedad que indica si el punto de control está activo
        public bool Activo
        {
            get
            {
                return activo;
            }
            private set
            {
                activo = value;
            }
        }

        // Constructor
        public PuntoControl(int posicionX, int posicionY)
        {
            PosicionX = posicionX;
            PosicionY = posicionY;
            Activo = false;
        }

        // Activa el punto de control
        public bool Activar()
        {
            Activo = true;
            return Activo;
        }
    }

}