using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SnakeWPF
{
    // Statisch, weil wir keine Objekte brauchen.
    // Die Klasse managed unser Game. Das heisst sie verwaltet zu, Beispiel die State Machine.
    static class GameManager
    {
        private static int _gameSpeed;
        private static DispatcherTimer _timer;
        private static Snake _playerOne;
        private static Apple _apple;
        private static Level _level;

        public static void Initialize()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += OnTick;
        }

        private static void GameOver() 
        {

        }
        
        private static void SpeedManager(int pDeltaSpeed) 
        {
            if (_gameSpeed + pDeltaSpeed <= 1) 
            {
                _gameSpeed = 1;
            }
            _gameSpeed = _gameSpeed + pDeltaSpeed;
            
            _timer.Interval = new TimeSpan(0, 0, 0, _gameSpeed);
        }

        private static void OnTick(object sender, EventArgs e)
        {

        }
    }
}
