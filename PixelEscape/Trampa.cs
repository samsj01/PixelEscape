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
            PosicionX = posicionX;
            PosicionY = posicionY;
            this.dano = dano;
            Activo = false;
        }

       // Trampa Activa
        public override bool Activar(Jugador escapista)
        {
            if (escapista.X == this.PosicionX)
            {
                Activo = true;
                return Activo;
            }
            return Activo;
    
        }

        // Retorna el daño que causa la trampa
        public int CausarDano()
        {
            if (Activo)
            {
                return Dano;
            }

            return 0;
        }
    }
}