using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeWPF
{
    // Erstellen des Apfel Objektes
    internal class Apple
    {
        // Felder
        static Random rnd = new Random();
        Element design = new Element(Brushes.Red, true);

        public int X { get; set; }
        public int Y { get; set; }

        public Apple()
        {
            SetNewPosition();
        }

        public void SetNewPosition()
        {
            X = rnd.Next(1, Global.HorizontalElementsCount - 1) * Global.ElementEdgeSize;
            Y = rnd.Next(1, Global.VerticalElementsCount - 1) * Global.ElementEdgeSize;
            design.X = X;
            design.Y = Y;
        }

        public void Show()
        {
            design.Show();
        }

        public void RemoveFromCanvas() 
        {
            design.RemoveFromCanvas();
        }

        public bool Collision(int x_Position, int y_Position)
        {
            if (x_Position == this.X && y_Position == this.Y)
                return true;
            return false;
        }
    }
}
