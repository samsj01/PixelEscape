using System;

namespace PixelEscape
{
    

    internal class PuntoControl : ObjetoInteractivo
    {

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
        public override bool Activar(Personaje escapist)
        {
            Activo = true;
            return Activo;
        }
    }

}