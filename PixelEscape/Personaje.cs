using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Personaje
    {
        int x;
        int y;
        int vida;
        int velocidad;
        bool estaVivo;
        protected int dano;
        string direccion;
        bool colision;


        public int X { get => x; protected set => x = value; }
        public int Y { get => y; protected set => y = value; }
        public int Vida { get => vida; set => vida = value;}
        public int Velocidad { get => velocidad; protected set => velocidad = value; }
        public bool EstaVivo { get => estaVivo; set => estaVivo = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public bool Colision { get => colision; set => colision = value; }

        public Personaje()
        {
            this.X = 0;
            this.Y = 0;
            this.vida = 1;
            this.velocidad = 1;
            this.EstaVivo = true;
            this.dano = 1;
            this.Direccion = "Derecha";
        }

        public string MostrarPosicion()
        {
            return $"{this.X},{this.Y}";
        }

        public bool MoverIzq()
        {
            this.X -= 1* velocidad;
            Direccion = "Izquierda";
            return true;
        }

        public bool MoverDer()
        {
            this.X += 1 * velocidad;
            Direccion = "Derecha";
            return true;
        }


        public virtual void RecibirDano(int dano)
        {
            this.Vida -= dano;
            if(this.Vida < 0)
            {
                this.Vida = 0;
            }
            EstaMuerto();
        }

        public bool EstaMuerto() 
        {
            if (this.Vida <= 0)
            {
                EstaVivo = false;
                return EstaVivo;
            }
            EstaVivo = true;
            return EstaVivo;
        }


        public virtual int Atacar(Personaje objetivo)
        {
            if (Colision) 
            { 
                objetivo.RecibirDano(this.dano);
            }
            Colision = false;
            return 0;
        }


    }
}
