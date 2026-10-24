using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Personaje: ElementoGrafico
    {
        int vida;
        int velocidad;
        bool estaVivo;
        protected int dano;
        string direccion;
        bool colision;


        
        public int Vida { get => vida; set => vida = value;}
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public bool EstaVivo { get => estaVivo; set => estaVivo = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public bool Colision { get => colision; set => colision = value; }

        public Personaje(int x, int y, int w, int h, string nombre) :
           base( x, y, w, h, nombre)
        {
            this.vida = 1;
            this.velocidad = 1;
            this.EstaVivo = true;
            this.dano = 1;
            this.Direccion = "Derecha";
        }
        public Personaje() 
        {
            this.vida = 1;
            this.velocidad = 1;
            this.EstaVivo = true;
            this.dano = 1;
            this.Direccion = "Derecha";
        }

        public bool MoverIzq()
        {
            this.SetPos(this.X -= 1 * velocidad, Y);
            Direccion = "Izquierda";
            return true;
        }

        public bool MoverDer()
        {
            this.SetPos(this.X += 1 * velocidad, Y);
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


        public virtual int Atacar(Personaje objetivo, bool colision)
        {
            this.Colision = colision;
            if (Colision) 
            { 
                objetivo.RecibirDano(this.dano);
                return 0;
            }
            Colision = false;
            return 0;
        }


    }
}
