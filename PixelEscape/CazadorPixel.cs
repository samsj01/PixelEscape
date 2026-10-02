namespace PixelEscape
{
    internal class CazadorPixel
    {
        // 1. Atributos privados (Encapsulamiento estricto)
        private int posicionX;
        private int posicionY;
        private double velocidad;
        private int dano;
        private double rangoDeteccion;

        public int PosicionX { get => posicionX; private set => posicionX = value;}
        public int PosicionY { get => posicionY; private set => posicionY = value; }
        public double Velocidad { get => velocidad;  set => velocidad = value; }
        public int Dano { get => dano; private set => dano = value; }
        public double RangoDeteccion { get => rangoDeteccion; 
            private set => rangoDeteccion = value; }


        public CazadorPixel()
        {
            this.PosicionX = 30;
            this.PosicionY = 0;
            this.Velocidad = 3;
            this.Dano = 1;
            this.RangoDeteccion = 2;
        }

        public int Atacar(Personaje escapist)
        {
            return dano;
        }
    }
}
        
