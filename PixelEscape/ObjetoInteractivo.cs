

using System;

namespace PixelEscape 
{

    internal abstract class ObjetoInteractivo : ElementoGrafico
    {
        protected bool colision = false;
        private bool activo;

        protected bool Activo { get => activo; set => activo = value; }
    }
}