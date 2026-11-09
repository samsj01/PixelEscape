using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    // Interfaces de rol pequeñas (ISP): cada cliente depende solo de lo que usa.
    internal interface IMovible
    {
        bool MoverIzq();
        bool MoverDer();
    }

    internal interface IDanable
    {
        void RecibirDano(int dano);
        bool EstaMuerto();
    }

    internal interface IAtacante
    {
        int Atacar(Personaje objetivo, bool colision);
    }

    internal abstract class Personaje: ElementoGrafico, IMovible, IDanable, IAtacante
    {
        int vida;
        int velocidad;
        bool estaVivo;
        protected int dano;
        int direccion;
        bool colision;


        
        public int Vida { get => vida; set => vida = value;}
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public bool EstaVivo { get => estaVivo; set => estaVivo = value; }
        public int Direccion { get => direccion; set => direccion = value; }
        public bool Colision { get => colision; set => colision = value; }

        public Personaje(int x, int y, int w, int h, string nombre) :
           base( x, y, w, h, nombre)
        {
            this.vida = 1;
            this.velocidad = 1;
            this.EstaVivo = true;
            this.dano = 1;
            this.Direccion = 1;
        }
        public Personaje() 
        {
            this.vida = 1;
            this.velocidad = 1;
            this.EstaVivo = true;
            this.dano = 1;
            this.Direccion = 1;
        }

        // Devuelve true si el personaje se movió. Las subclases pueden restringirlo (OCP/LSP).
        public virtual bool MoverIzq()
        {
            this.SetPos(this.X - velocidad, Y);
            Direccion = -1;
            return true;
        }

        public virtual bool MoverDer()
        {
            this.SetPos(this.X + velocidad, Y);
            Direccion = 1;
            return true;
        }


        public virtual void RecibirDano(int dano)
        {
            this.Vida -= dano;
            if(this.Vida < 0)
            {
                this.Vida = 0;
            }
            ActualizarEstado();
        }

        // Actualiza EstaVivo según la vida actual.
        void ActualizarEstado()
        {
            EstaVivo = this.Vida > 0;
        }

        // Devuelve true cuando el personaje ya no tiene vida.
        public bool EstaMuerto() 
        {
            ActualizarEstado();
            return !EstaVivo;
        }


        // Plantilla del ataque: las subclases cambian solo la condición (PuedeAtacar),
        // sin reescribir el método completo.
        public virtual int Atacar(Personaje objetivo, bool colision)
        {
            this.Colision = colision;
            if (PuedeAtacar(objetivo)) 
            { 
                objetivo.RecibirDano(this.dano);
            }
            return 0;
        }

        protected virtual bool PuedeAtacar(Personaje objetivo)
        {
            return Colision;
        }


    }
}
