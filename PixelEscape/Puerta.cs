using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Puerta
    {
        //Atributos

        private int posicionX;
        private int posicionY;
        private bool estadoPuerta;

        //Constructores
        public Puerta(int posicionX, int posicionY)
        {
            this.posicionX = posicionX;
            this.posicionY = posicionY;
            this.estadoPuerta = false;
        }

        //gat y set
        public int X { get { return posicionX; } set { posicionX = value; } }
        public int Y { get { return posicionY; } set { posicionY = value; } }
        public bool EstadoPuerta { get => estadoPuerta; set => estadoPuerta = value; }

        public int PosicionX
        {
            get { return posicionX; }
            set
            {
                if (value >= 0)
                {
                    posicionX = value;
                }
            }
        }

        public int PosicionY
        {
            get { return posicionY; }
            set
            {
                if (value >= 0)
                {
                    posicionY = value;
                }
            }
        }




        //Métodos

        //Para abrir la puerta si se tiene la llave
        public void Abrir(Llave llave)
        {
            if (llave.Recogida)
            {
                estadoPuerta = true;
            }

        }

        //Consultar éstado de la puerta
        public bool ConsultarPuerta()
        {
            return estadoPuerta;

        }
    }
}
