using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeWPF
{
    // Alle erstellten Objekte sind Elemente (Äpfel, Wände...)
    internal class Element
    {
        private Rectangle _square = new Rectangle();
        private SolidColorBrush _color;
        private bool _round;

        public int X { get; set; }
        public int Y { get; set; }

        public Element()
        {
            _color = Brushes.White;
            _round = false;
            Design();
        }
        public Element(SolidColorBrush pColor, bool pRound)
        {
            _color = pColor;
            _round = pRound;
            Design();
        }
        private void Design()
        {
            _square.Width = Global.ElementEdgeSize;
            _square.Height = Global.ElementEdgeSize;
            _square.Fill = _color;

            if (_round )
            {
                _square.RadiusX = Global.ElementEdgeSize / 2;
                _square.RadiusY = Global.ElementEdgeSize / 2;
            }
        }
        public void Show()
        {
         // Die Position undseres Quadrates festlegen
            Canvas.SetLeft(_square, X);
            Canvas.SetTop(_square, Y);

         // Das Quadrat anzeigen
            Global.GamingArea.Children.Add(_square);
        }
        public void RemoveFromCanvas()
        {
            Global.GamingArea.Children.Remove(_square);
        }
    }
}
