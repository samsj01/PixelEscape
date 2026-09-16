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

        // 2. Propiedades C# con validaciones
        public int PosicionX
        {
            get { return posicionX; }
            set { posicionX = value < 0 ? 0 : value; } // Impide posiciones X negativas
        }

        public int PosicionY
        {
            get { return posicionY; }
            set { posicionY = value < 0 ? 0 : value; } // Impide posiciones Y negativas
        }

        public double Velocidad
        {
            get { return velocidad; }
            set 
            { 
                // Al ser el Cazador, debe tener una velocidad mayor a los enemigos básicos (mínimo 6.0)
                if (value < 6.0) velocidad = 6.0;
                else velocidad = value; 
            }
        }

        public int Dano
        {
            get { return dano; }
            set { dano = value <= 0 ? 1 : value; } // El daño mínimo siempre es 1
        }

        public double RangoDeteccion
        {
            get { return rangoDeteccion; }
            set { rangoDeteccion = value <= 0 ? 1.0 : value; } // Evita rangos negativos o nulos
        }

        // 3. Constructor explícito que obliga a instanciar en un estado inicial válido
        public CazadorPixel(int xInicial, int yInicial, double velocidadInicial, int danoInicial, double rangoDeteccionInicial)
        {
            PosicionX = xInicial;
            PosicionY = yInicial;
            Velocidad = velocidadInicial;
            Dano = danoInicial;
            RangoDeteccion = rangoDeteccionInicial;
        }

        // 4. Comportamientos y Métodos de interacción

        // Mueve al cazador en los ejes X e Y
        public string Moverse(int deltaX, int deltaY)
        {
            PosicionX += deltaX;
            PosicionY += deltaY;
            return $"Cazador Pixel se movió a la posición ({PosicionX}, {PosicionY}).";
        }

        // Método de interacción: calcula la distancia euclidiana hacia la posición del jugador
        public bool Detectar(Jugador objetivo)
        {
            if (objetivo == null) return false;

            // Calculamos la distancia usando posicionX y posicionY directamente
            int deltaX = PosicionX - objetivo.PosicionActual.X;
            int deltaY = PosicionY - objetivo.PosicionActual.Y;
            double distancia = System.Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return distancia <= RangoDeteccion;
        }

        // Método de interacción: persigue al jugador si está dentro de su rango
        public string Perseguir(Jugador objetivo)
        {
            if (objetivo == null) return "No hay objetivo a perseguir.";

            if (Detectar(objetivo))
            {
                // Acercamiento progresivo en el eje X
                if (PosicionX < objetivo.PosicionActual.X)
                    PosicionX++;
                else if (PosicionX > objetivo.PosicionActual.X)
                    PosicionX--;

                // Acercamiento progresivo en el eje Y
                if (PosicionY < objetivo.PosicionActual.Y)
                    PosicionY++;
                else if (PosicionY > objetivo.PosicionActual.Y)
                    PosicionY--;

                return $"¡Cazador detectó a {objetivo.Nombre}! Persiguiendo hasta ({PosicionX}, {PosicionY}).";
            }

            return "Jugador fuera del rango de detección.";
        }

        // Método de interacción: ataca al jugador si están en las mismas coordenadas
        public bool Atacar(Jugador objetivo)
        {
            if (objetivo == null) return false;

            // Verifica si el cazador y el jugador coinciden en la misma posición (X, Y)
            if (PosicionX == objetivo.PosicionActual.X && PosicionY == objetivo.PosicionActual.Y)
            {
                objetivo.PerderVida(Dano); // Causa daño al jugador a través de su método
                return true;
            }
            return false;
        }

        // Método para consultar el reporte de estado consumiendo sus propiedades
        public string ObtenerReporteEstado()
        {
            return $"[Cazador Pixel] Posición: ({PosicionX}, {PosicionY}) | Velocidad: {Velocidad} | Rango Detección: {RangoDeteccion} | Daño: {Dano}";
        }
    }
}
