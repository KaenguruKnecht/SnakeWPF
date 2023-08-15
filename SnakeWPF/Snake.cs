using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace SnakeWPF
{
    // Erstellen des Schlangen Objekts
    internal class Snake
    {
        // Felder
        private List<Element> _snake = new List<Element>();
        public int Head_X
        {
            get
            {
               return _snake[0].X;
            }
        }
        public int Head_Y
        {
            get
            {
                return _snake[0].Y;
            }
        }
    public Snake()
        {
            Grow(Global.StartLength);
        }
        public void Grow(int numberOfElements)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                _snake.Add(new Element(Brushes.White, false));
                if (_snake.Count <= 1)
                {
                    _snake[0].X = Global.HorizontalElementsCount / 2 * Global.ElementEdgeSize;
                    _snake[0].Y = Global.VerticalElementsCount / 2 * Global.ElementEdgeSize;
                }
                else
                {
                    _snake[_snake.Count - 1].X = -2 / Global.ElementEdgeSize;
                    _snake[_snake.Count - 1].Y = -2 / Global.ElementEdgeSize;
                }
            }
        }
        public void Show()
        {
            foreach (Element element in _snake)
            {
                element.Show();
            }
        }
        public void RemoveFromCanvas()
        {
            foreach (Element element in _snake)
            {
                element.RemoveFromCanvas();
            }
        }
        public void Move()
        {
            // Nimm das letzte Quadrat und setzte es an den Anfang
            Element lastItem = _snake[_snake.Count - 1]; // Schritt 1: das letzte Element speichern
            _snake.RemoveAt(_snake.Count - 1); // Schritt 2: das letzte Element entfernen
            _snake.Insert(0, lastItem); // Schritt 3: das zuletzt entfernte Element an den Anfang hinzufügen
            switch (KeyHistory.GetWaitingKey())
            {
                case Key.Left:
                    _snake[0].X = _snake[1].X - Global.ElementEdgeSize;
                    _snake[0].Y = _snake[1].Y;
                    break;
                case Key.Right:
                    _snake[0].X = _snake[1].X + Global.ElementEdgeSize;
                    _snake[0].Y = _snake[1].Y;
                    break;
                case Key.Up:
                    _snake[0].X = _snake[1].X;
                    _snake[0].Y = _snake[1].Y - Global.ElementEdgeSize;
                    break;
                case Key.Down:
                    _snake[0].X = _snake[1].X;
                    _snake[0].Y = _snake[1].Y + Global.ElementEdgeSize;
                    break;
                default:
                    break;
            }
        }
        public bool Collision(int x_Position, int y_Position)
        {
            for (int i = 1; i < _snake.Count; i++)
            {
                if (Head_X == _snake[i].X && Head_Y == _snake[i].Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void ClearList()
        {
            _snake.Clear();
        }
    }
}
