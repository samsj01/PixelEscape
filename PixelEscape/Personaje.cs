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
            this.X = 0;
            this.Y = 0;
            this.vida = 1;
            this.velocidad = 1;
            this.EstaVivo = true;
            this.dano = 1;
        }

        public string MostrarPosicion()
        {
            return $"{this.X},{this.Y}";
        }

        public virtual bool Moverse(int pasos)
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

        public virtual int Atacar(Personaje objetivo)
        {
            return dano;
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
    
    internal class CazadorPixel : Personaje
    {
        double rangoDeteccion;
        public double RangoDeteccion { get => rangoDeteccion; 
            private set => rangoDeteccion = value; }
        public CazadorPixel() : base()
        {
            this.X = 30;
            this.Y = 0;
            this.Velocidad = 3;
            this.dano = 1;
            this.RangoDeteccion = 2;
        }

        bool CalcularDistancia() 
        {
            double distancia = Math.Sqrt(Math.Pow(this.X - 0, 2) + Math.Pow(this.Y - 0, 2));
            if (distancia <= this.RangoDeteccion)
            {
                return true;
            }
            return false;
        }

        public override int Atacar(Personaje objetivo)
        {
            if (CalcularDistancia() && objetivo.MostrarPosicion() == this.MostrarPosicion())
            {
                objetivo.RecibirDano(this.dano);
                return dano;
            }
            return 0;
        }
    }
    internal class GuardianPixel : Personaje 
    {
        bool direccion = false; // false = izquierda, true = derecha
        public GuardianPixel() : base()
        {
            this.X = 50;
            this.Y = 0;
            this.Velocidad = 1;
            this.dano = 1;
        }

        public bool Direccion { get => direccion; set => direccion = value; }

        public override bool Moverse(int pasos)
        {
            if (pasos >= 0)
            {
                if (!Direccion)
                {
                    for (int i = 0; i < pasos; i++)
                    {
                        //camina de izquierda a derecha
                        this.X = this.X + 1 * Velocidad;
                    }
                    Direccion = true;//pasa a caminar de derecha a izquierda
                }
                else
                {
                    for (int i = 0; i < pasos; i++)
                    {
                        //camina de derecha a izquierda
                        this.X = this.X - 1 * Velocidad;
                    }
                    Direccion = false; //pasa a caminar de izquierda a derecha
                }
                return true;
            }
            return false;
        }
    }
}
