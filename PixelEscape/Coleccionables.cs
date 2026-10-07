using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Coleccionables
    {
        //atributos
        int x;
        int y;
        protected bool recogido;
        Random rd = new Random();

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public bool Recogido { get => recogido; set => recogido = value; }

        //constructor
        public Coleccionables(int x, int y)
        {
            this.x = rd.Next();
            this.y = y;
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
        public void recogerPowerUp(Personaje jugador)
        {
            if (!Recogido)
            {
                Jugador.velocidad +=2 ;
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
