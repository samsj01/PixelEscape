using System;

namespace PixelEscape
{
    internal class Obstaculo
    {
        // Atributos privados
        private int posicionX;
        private int posicionY;
        private int ancho;
        private int alto;
        private string tipo;

        public int PosicionX { get => posicionX; set => posicionX = value; }
        public int PosicionY { get => posicionY; set => posicionY = value; }
        public int Ancho { get => ancho; set => ancho = value; }
        public int Alto { get => alto; set => alto = value; }
        public string Tipo { get => tipo; set => tipo = value; }


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

        
    }
}

