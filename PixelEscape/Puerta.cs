using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Puerta : ObjetoInteractivo
    {
        //Atributos
        private bool estadoPuerta;

        //Constructores
        public Puerta(int posicionX, int posicionY)
        {
            this.X = posicionX;
            this.Y = posicionY;
            this.estadoPuerta = false;
        }

        public bool EstadoPuerta { get => estadoPuerta; set => estadoPuerta = value; }

        //Métodos

        //Para abrir la puerta si se tiene la llave
        public void Abrir(Llave llave)
        {
            if (llave.Recogido)
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
