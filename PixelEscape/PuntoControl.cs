using System;

namespace PixelEscape
{
    

    internal class PuntoControl : ObjetoInteractivo
    {

        // Propiedad que indica si el punto de control está activo

        // Constructor
        public PuntoControl(int posicionX, int posicionY)
        {
            PosicionX = posicionX;
            PosicionY = posicionY;
            Activo = false;
        }

        // Activa el punto de control
        public bool Activar(Jugador escapist)
        {
            Activo = true;
            return Activo;
        }
    }

}