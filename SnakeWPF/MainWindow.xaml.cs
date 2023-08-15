using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool _firstTime = true;

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Wenn ich zum ersten Mal aufgerufen werde,
            // soll mein Canvas! dem Canvas in der Global zugewiesen werden.
            if (_firstTime)
            {
                Global.GamingArea = Canvas;
                Global.TextBlockScore = TextBlockScore;
                Global.LoseScreen = LoseScreen;
                _firstTime = false;
            }

            if (e.Key == Key.Enter)
            {
                GameManager.Initialize();
            }

            KeyHistory.Add(e.Key);
            e.Handled = true;
        }
    }
}
