using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeWPF
{
    // Erstellen des Rand Objekts
    internal class Level
    {
        private List<Element> _levelsElements = new List<Element>();

        public void Create()
        {
            List<Element> upper = new List<Element>();
            List<Element> lower = new List<Element>();
            List<Element> left = new List<Element>();
            List<Element> right = new List<Element>();

            for (int i = 0; i < Global.HorizontalElementsCount; i++)
            {
                upper.Add(new Element(Brushes.YellowGreen, false));
                upper[i].X = i * Global.ElementEdgeSize;
                upper[i].Y = 0;
                lower.Add(new Element(Brushes.YellowGreen, false));
                lower[i].X = i * Global.ElementEdgeSize;
                lower[i].Y = (int)Global.HightOfLevel - Global.ElementEdgeSize;
            }
            for (int i = 0; i < Global.VerticalElementsCount; i++)
            {
                left.Add(new Element(Brushes.YellowGreen, false));
                left[i].Y = i * Global.ElementEdgeSize;
                left[i].X = 0;
                right.Add(new Element(Brushes.YellowGreen, false));
                right[i].Y = i * Global.ElementEdgeSize;
                right[i].X = (int)Global.WidthOfLevel - Global.ElementEdgeSize;
            }

            _levelsElements = upper.Concat(lower).Concat(left).Concat(right).ToList();
        }
        public void Show()
        {
            foreach (Element element in _levelsElements)
                element.Show();
        }
        public bool Collision(int pXPosition, int pYPosition)
        {
            foreach (Element elementlevel in _levelsElements)
            {
                if (pXPosition == elementlevel.X && pYPosition == elementlevel.Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
