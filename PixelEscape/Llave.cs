using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Llave
    {

        //Atributos
        private int posicionX;
        private int posicionY;
        private bool estado;

        //Constructores
        public Llave(int posicionX, int posicionY)
        {
            this.posicionX = posicionX;
            this.posicionY = posicionY;
            this.estado = false;
        }

        //get y set
        public int X { get { return posicionX; } set { posicionX = value; } }
        public int Y { get { return posicionY; } set { posicionY = value; } }
        public bool Recogida { get { return estado; } set { estado = value; } }

        //Métodos(Verbos)

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

        //Recoger la llave
        public void Recoger(Jugador escapist)
        {
            this.estado = true;
        }

        //Consultar si ya fue recogida la llave

        public bool ConsultarLlave()
        {
            return estado;
        }

    }
}
