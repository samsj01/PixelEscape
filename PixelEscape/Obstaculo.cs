using System;

namespace PixelEscape
{
    public class Obstaculo
    {
        // Atributos privados
        private int posicionX;
        private int posicionY;
        private int ancho;
        private int alto;
        private string tipo;

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

        // Propiedad para el ancho
        public int Ancho
        {
            get
            {
                return ancho;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Ancho),
                        "El ancho debe ser mayor que cero."
                    );
                }

                ancho = value;
            }
        }

        // Propiedad para el alto
        public int Alto
        {
            get
            {
                return alto;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Alto),
                        "El alto debe ser mayor que cero."
                    );
                }

                alto = value;
            }
        }

        // Propiedad para el tipo de obstáculo
        public string Tipo
        {
            get
            {
                return tipo;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "El tipo de obstáculo no puede estar vacío."
                    );
                }

                tipo = value;
            }
        }

        // Constructor
        public Obstaculo(
            int posicionX,
            int posicionY,
            int ancho,
            int alto,
            string tipo)
        {
            PosicionX = posicionX;
            PosicionY = posicionY;
            Ancho = ancho;
            Alto = alto;
            Tipo = tipo;
        }

        // Indica que el obstáculo limita el movimiento
        public bool BloqueaMovimiento()
        {
            return true;
        }
    }
}

