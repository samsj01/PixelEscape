using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEscape
{
    internal class Moneda : Coleccionables
    {
        int valor = 100;
        public int Valor { get => valor; }
        public Moneda(int x, int y, int valor) : base(x, y)
        {
            this.valor = valor;
        }
        public void RecogerMoneda(Jugador jugador)
        {
            if (!Recogido)
            {
                jugador.Puntaje += this.valor;
                Recogido = true;
            }
        }
    }
}
