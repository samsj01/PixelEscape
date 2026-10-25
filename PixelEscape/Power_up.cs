using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    // Duplica la jerarquía Coleccionables (PowerUpVelocidad / PowerUpEscudo) y usa un
    // string como tipo, lo que obliga a modificar la clase para cada power-up nuevo.
    [Obsolete("Usar PowerUpVelocidad o PowerUpEscudo (jerarquía Coleccionables).")]
    internal class Power_up
    {
        //Atributos
        private int posicionx;
        private int posiciony;
        private int duracion;
        private string tipo;

        //  constructor
        public Power_up(int posicionx, int posiciony, int duracion, string tipo)
        {
            this.posicionx = posicionx;
            this.posiciony = posiciony;
            this.duracion = duracion;
            this.tipo = tipo;
        }

        //Get y set
        public int X { get { return posicionx; } set { posicionx = value; } }
        public int Y { get { return posiciony; } set { posiciony = value; } }
        public string Tipo { get { return tipo; } set { tipo = value; } }
        public int Duracion { get { return duracion; } set { duracion = value; } }

        public int PosicionX
        {
            get { return posicionx; }
            set
            {
                if (value >= 0)
                {
                    posicionx = value;
                }
            }
        }

        public int PosicionY
        {
            get { return posiciony; }
            set
            {
                if (value >= 0)
                {
                    posiciony = value;
                }
            }
        }

        // Comportamiento para activar o consultar el tipo de power-up
        public string ConsultarTipo()
        {
            return tipo;
        }
        //La duración del power up
        public int ConcultarDuracion
        {
            get { return duracion; }
            set
            {
                if (value > 0) // Validamos que la duración sea positiva 
                {
                    duracion = value;
                }
            }
        }
    }
}
