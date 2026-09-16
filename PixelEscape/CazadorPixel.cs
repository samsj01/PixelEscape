namespace PixelEscape
{
    public class CazadorPixel
    {
        // 1. Atributos privados (Encapsulamiento estricto)
        private int posicionX;
        private int posicionY;
        private double velocidad;
        private int dano;
        private double rangoDeteccion;

        public int PosicionX { get => posicionX;}
        public int PosicionY { get => posicionY;}
        public double Velocidad { get => velocidad; set => velocidad = value; }
        public int Dano { get => dano;}
        public double RangoDeteccion { get => rangoDeteccion;}


        public CazadorPixel()
        {
            this.posicionX = 30;
            this.posicionY = 0;
            this.velocidad = 3;
            this.dano = 1;
            this.rangoDeteccion = 2;
        }
    }
}
        
