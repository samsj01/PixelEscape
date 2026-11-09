using System;

namespace PixelEscape
{
    

    internal class PuntoControl : ObjetoActivable
    {

        // Propiedad que indica si el punto de control está activo

        // Constructor
        public PuntoControl(int posicionX, int posicionY)
        {
            this.X = posicionX;
            this.Y = posicionY;
            Activo = false;
        }

        // Activa el punto de control
        public override bool Activar(Jugador escapist)
        {
            Activo = true;
            return Activo;
        }
    }

}