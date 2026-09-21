using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Jugador
    {
        int x;
        int y;
        int vida;
        int puntaje;
        int velocidad;
        int velY = 1; // nuevo
        const int GRAVEDAD = 1; // nuevo
        const int FUERZASALTO = 3; // nuevo 
        const int SUELO = 0; // nuevo
        bool estaVivo;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Vida { get => vida; set => vida = value;}
        public int Velocidad { get => velocidad; }

        public bool EnElSuelo { get; private set; } = true;
        public int Puntaje { get => puntaje; set => puntaje = value; }
        public int VelY { get => velY; set => velY = value; }

        public int FUERZASALTO1 { get => FUERZASALTO; }

        public Jugador()
        {
            this.x = 0;
            this.y = 0;
            this.vida = 3;
            this.Puntaje = 0;
            this.velocidad = 2;
            this.estaVivo = true;
        }

        public bool MoverHorizontal(int pasos)
        {
            this.X += pasos * velocidad;
            return true;
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
                if(this.Y == SUELO)
                {
                    EnElSuelo = true;
                }
            }
            
        }
        public void RecibirDano(int dano)
        {
            this.Vida -= dano;
            if(this.Vida < 0)
            {
                this.Vida = 0;
            }
        }

        
    }
}
