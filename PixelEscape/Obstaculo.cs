using System;

namespace PixelEscape
{
    // Ahora es un ElementoGrafico: reutiliza posición, tamaño y GetBounds()
    // en lugar de duplicarlos (DRY/LSP).
    internal class Obstaculo : ElementoGrafico
    {
        // Atributos privados
        private string tipo;

        public int PosicionX { get => X; set => SetPos(value, Y); }
        public int PosicionY { get => Y; set => SetPos(X, value); }
        public string Tipo { get => tipo; set => tipo = value; }


        // Constructor
        public Obstaculo(int posicionX, int posicionY, int ancho, int alto, string tipo) 
            : base(posicionX, posicionY, ancho, alto, null)
        {
            Tipo = tipo;
        }

        
    }
}
