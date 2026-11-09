using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Windows.Forms;

namespace PixelEscape
{
    internal class ElementoGrafico
    {
        private int x;
        private int y;
        private int ancho;
        private int alto;
        Point ubicacion;
        string nombreRecurso;

        public Point Ubicacion { get => ubicacion; private set => ubicacion = value; }
        protected string NombreRecurso { get => nombreRecurso;}
        public int X { get => x; protected set { x = value; ubicacion = new Point(x, y); } }
        public int Y { get => y; protected set { y = value; ubicacion = new Point(x, y); } }
        public int Ancho { get => ancho; set => ancho = value; }
        public int Alto { get => alto; set => alto = value; }
        public PictureBox Imagen{get;set;}


        public ElementoGrafico(int x, int y, int ancho, int alto, string nombreRecurso)
        {
            this.x = x;
            this.y = y;
            Ancho = ancho;
            Alto = alto;
            Ubicacion = new Point(x, y);
            this.nombreRecurso = nombreRecurso; 
        }

        public ElementoGrafico()
        {
            this.x = 0;
            this.y = 0;
            Ancho = 32;
            Alto = 32;
            Ubicacion = new Point(this.X, this.Y);
            this.nombreRecurso = null;
        }

        public virtual Rectangle GetBounds()
        {
            // Si todavía no hay imagen (p. ej. en consola) se usa la geometría propia.
            if (Imagen != null)
            {
                return Imagen.Bounds;
            }
            return new Rectangle(X, Y, Ancho, Alto);
        }

        public void SetPos(int x, int y)
        {
            this.x = x;
            this.y = y;
            Ubicacion = new Point (x, y);
        }

    }
}
