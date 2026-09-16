namespace PixelEscape
{
    public class CazadorPixel
    {
        private Posicion posicion;
        private double velocidad;
        private int dano;
        private double rangoDeteccion;

        // Propiedades encapsuladas con validación
        public Posicion PosicionActual
        {
            get { return posicion; }
            set { posicion = value ?? new Posicion(0, 0); }
        }

        public double Velocidad
        {
            get { return velocidad; }
            set 
            { 
                // Debe ser más rápido que el Guardián (mínimo 6.0)
                if (value < 6.0) velocidad = 6.0;
                else velocidad = value; 
            }
        }

        public int Dano
        {
            get { return dano; }
            set { dano = value <= 0 ? 1 : value; }
        }

        public double RangoDeteccion
        {
            get { return rangoDeteccion; }
            set { rangoDeteccion = value <= 0 ? 5.0 : value; } // Rango mínimo de detección
        }

        // Constructor explícito
        public CazadorPixel(Posicion posicionInicial, double velocidadInicial, int danoInicial, double rangoDeteccionInicial)
        {
            private Posicionx;
	        private Posiciony;
            Velocidad = velocidadInicial;
            Dano = danoInicial;
            RangoDeteccion = rangoDeteccionInicial;
        }

        // Comportamientos
        public string Moverse(int deltaX, int deltaY)
        {
            PosicionActual.X += deltaX;
            PosicionActual.Y += deltaY;
            return $"Cazador Pixel se movió a {PosicionActual.ObtenerCoordenadas()}";
        }

        // Método de interacción: Detectar al jugador según la distancia
        public bool Detectar(Jugador objetivo)
        {
            if (objetivo == null) return false;
            double distancia = PosicionActual.CalcularDistancia(objetivo.PosicionActual);
            return distancia <= RangoDeteccion;
        }

        // Método de interacción: Perseguir al jugador acercándose a sus coordenadas
        public string Perseguir(Jugador objetivo)
        {
            if (objetivo == null) return "No hay objetivo para perseguir.";

            if (Detectar(objetivo))
            {
                // Acercarse en el eje X
                if (PosicionActual.X < objetivo.PosicionActual.X)
                    PosicionActual.X += 1;
                else if (PosicionActual.X > objetivo.PosicionActual.X)
                    PosicionActual.X -= 1;

                // Acercarse en el eje Y
                if (PosicionActual.Y < objetivo.PosicionActual.Y)
                    PosicionActual.Y += 1;
                else if (PosicionActual.Y > objetivo.PosicionActual.Y)
                    PosicionActual.Y -= 1;

                return $"¡Cazador ha detectado a {objetivo.Nombre}! Persiguiendo a posición {PosicionActual.ObtenerCoordenadas()}";
            }

            return "Jugador fuera del rango de detección.";
        }

        // Método de interacción: Atacar al jugador
        public bool Atacar(Jugador objetivo)
        {
            if (objetivo == null) return false;

            // Si está en la misma casilla que el jugador
            if (PosicionActual.X == objetivo.PosicionActual.X && PosicionActual.Y == objetivo.PosicionActual.Y)
            {
                objetivo.PerderVida(Dano);
                return true;
            }
            return false;
        }

        public string ObtenerReporteEstado()
        {
            return $"[Cazador Pixel] Posición: {PosicionActual.ObtenerCoordenadas()} | Velocidad: {Velocidad} | Rango Detección: {RangoDeteccion} | Daño: {Dano}";
        }
    }
}
