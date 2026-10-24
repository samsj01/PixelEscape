using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Coleccionables: ElementoGrafico
    {
        protected bool recogido;
        Random rd = new Random();

        public bool Recogido { get => recogido; set => recogido = value; }

        //constructor
        public Coleccionables(int x, int y)
        {
            this.X = rd.Next();
            this.Y = y;
            this.recogido = false;
        }

        //metodos

        public void Recoger (Personaje jugador)
        {
            if (recogido)
            {
                this.recogido = true;
            }
            recogido= false;
        }  
        
    }

    

    internal class PowerUpVelocidad : Coleccionables
    {
        int duracion;
        public int Duracion { get => duracion; set => duracion = value; }
        public PowerUpVelocidad(int x, int y, int duracion) : base(x, y)
        {
            this.duracion = duracion;
        }
        public void recogerPowerUp(Jugador jugador)
        {
            if (!Recogido)
            {
                jugador.Velocidad = 2;
                Recogido = true;
            }
            recogido = false;
        }
    }

    internal class PowerUpEscudo : Coleccionables
    {
        int duracion;
        public int Duracion { get => duracion; set => duracion = value; }
        public PowerUpEscudo(int x, int y, int duracion) : base(x, y)
        {
            this.duracion = duracion;
        }
        public void RecogerPowerUp(Personaje jugador)
        {
            if (!Recogido)
            {
                jugador.Vida += 1;
                Recogido = true;
            }
            recogido = false;
        }
    }

    
}
