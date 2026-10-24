using System;
namespace PixelEscape
{


    internal abstract class Trampa : ObjetoActivable
    {
        // Atributos privados
        private int dano;
        public int Dano { get => dano;}

        // Constructor
        public Trampa(int posicionX, int posicionY, int dano)
        {
            this.X = posicionX;
            this.Y = posicionY;
            this.dano = dano;
            Activo = false;
        }

       // Trampa Activa
        public override bool Activar(Jugador escapista)
        {
            if (escapista.X == this.X)
            {
                Activo = true;
                escapista.RecibirDano(Dano);
                return Activo;
                
            }
            return Activo;
    
        }
    }
}