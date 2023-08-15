using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SnakeWPF
{
    // Statisch, weil wir keine Objekte brauchen.
    // Die Klasse verwaltet und veröffentlicht alle Eigenschaften und Konstanten unseres Spiels. So dass alle
    // anderen Klassen immer darauf zugreifen können.
    static class Global
    {
        public static Canvas GamingArea { get; set; }
        public static TextBlock TextBlockScore { get; set; }
        public static TextBlock LoseScreen { get; set; }

        public static int Score { get; set; }
        public static bool GameOver { get; set; }

        public const int ElementEdgeSize = 20; // Feldergröße
        public const int StartLength = 4; // Schlangenlänge bei Begin
        public const int StartSpeed = 200; // ms
        public static int HightOfLevel { 
            get { return Convert.ToInt32(GamingArea.ActualHeight); }
            private set { }
        }
        public static int WidthOfLevel
        {
            get { return Convert.ToInt32(GamingArea.ActualWidth); }
            private set { }
        }

        public static int HorizontalElementsCount {
            get
            { 
                return Convert.ToInt32(GamingArea.ActualWidth) / ElementEdgeSize;
            }
            private set { }
        }
        public static int VerticalElementsCount {
            get
            {
                return Convert.ToInt32(GamingArea.ActualHeight) / ElementEdgeSize;
            }
            private set { }
        }
        static Global()
        {
            GameOver = true;
        }
    }
}
