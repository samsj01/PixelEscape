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

        public Point Ubicacion { get => ubicacion; set => ubicacion = value; }
        protected string NombreRecurso { get => nombreRecurso;}
        public int X { get => x; protected set => x = value; }
        public int Y { get => y; protected set => x = value; }
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
            Imagen = new PictureBox
            {
                Location = new Point(x, y),
                Size = new Size(ancho, alto),
                //Image = (Image)Properties.Resources.ResourceManager.GetObject(nombre),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            this.nombreRecurso = nombreRecurso; 
        }

        public ElementoGrafico()
        {
            this.x = 0;
            this.y = 0;
            Ancho = 32;
            Alto = 32;
            Ubicacion = new Point(this.X, this.Y);
            Imagen = new PictureBox
            {
                Location = new Point(this.X, this.Y),
                Size = new Size(Ancho, Alto),
                //Image = (Image)Properties.Resources.ResourceManager.GetObject(nombre),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
        }

        public virtual Rectangle GetBounds()
        {
            return Imagen.Bounds;
        }

        public void SetPos(int x, int y)
        {
            this.x = x;
            this.y = y;
            Ubicacion = new Point (x, y);
        }

    }
}
