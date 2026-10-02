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

        public int X { get => x; protected set => x = value; }
        public int Y { get => y; protected set => y = value; }
        public int Vida { get => vida; set => vida = value;}
        public int Velocidad { get => velocidad; protected set => velocidad = value; }
        public bool EstaVivo { get => estaVivo; set => estaVivo = value; }

        public Personaje()
        {
            this.x = 0;
            this.y = 0;
            this.vida = 1;
            this.velocidad = 1;
            this.EstaVivo = true;
            this.dano = 1;
        }

        public string MostrarPosicion()
        {
            return $"{this.X},{this.Y}";
        }

        public virtual bool MoverHorizontal(int pasos)
        {
            this.X += pasos * velocidad;
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

        public virtual bool Atacar(Personaje objetivo)
        {
            if (objetivo.MostrarPosicion() == this.MostrarPosicion()) 
            {
                objetivo.RecibirDano(this.dano);
                return true;
            }
            return false;
        }


    }
    internal class Jugador : Personaje
    {
        int puntaje;
        int velY = 1; // nuevo
        const int GRAVEDAD = 1; // nuevo
        const int FUERZASALTO = 3; // nuevo 
        const int SUELO = 0; // nuevo

        public bool EnElSuelo { get; private set; } = true;
        public int Puntaje { get => puntaje; set => puntaje = value; }
        public int VelY { get => velY; set => velY = value; }

        public int FUERZASALTO1 { get => FUERZASALTO; }

        public Jugador() : base()
        {
            this.X = 0;
            this.Y = 0;
            this.Vida = 3;
            this.Puntaje = 0;
            this.dano = 1;
        }
        public void Saltar()
        {
            if (EnElSuelo)
            {
                this.Y += FUERZASALTO1 * VelY;
                EnElSuelo = false;
            }
        }
        public void Aterrizar()
        {
            if (!EnElSuelo)
            {
                this.Y -= this.VelY * GRAVEDAD;
                if (this.Y == SUELO)
                {
                    EnElSuelo = true;
                }
            }

        }
    }   
}
