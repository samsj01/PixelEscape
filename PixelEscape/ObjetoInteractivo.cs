

using System;

namespace PixelEscape 
{

    public abstract class ObjetoInteractivo
    {
        private int posicionX;
        private int posicionY;
        protected bool colision = false;
        private bool activo;

        protected int PosicionX { get => posicionX; set => posicionX = value; }
        protected int PosicionY { get => posicionY; set => posicionY = value; }
        protected bool Activo { get => activo; set => activo = value; }
    }
}