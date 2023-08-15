using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SnakeWPF
{
    // Statisch, weil wir keine Objekte brauchen.
    // Die Klasse managed unser Game. Das heisst sie verwaltet zu, Beispiel die State Machine.
    static class GameManager
    {
        private static int _gameSpeed { get; set; }
        private static DispatcherTimer _timer { get; set; }
        private static Snake _playerOne { get; set; }
        private static Apple _apple { get; set; }
        private static Level _levelOne { get; set; }

        public static void Initialize()
        {

            _timer = new DispatcherTimer();

            _gameSpeed = Global.StartSpeed;
            SpeedManager(0);

            _timer.Tick += OnTick;
            Global.GamingArea.Children.Clear();

            Global.Score = 0;
            Global.TextBlockScore.Text = "Score: " + Convert.ToString(Global.Score);

            Global.LoseScreen.Opacity = 0;

            Global.GameOver = false;
            _playerOne = new Snake();
            _apple = new Apple();

            _levelOne = new Level();
            _levelOne.Create();
            _levelOne.Show();
            _timer.Start();
        }

        private static void OnTick(object sender, EventArgs e)
        {
            _playerOne.RemoveFromCanvas();
            _apple.RemoveFromCanvas();
            _playerOne.Move();

            if (_apple.Collision(_playerOne.Head_X, _playerOne.Head_Y))
            {
                do
                {
                    _apple.SetNewPosition();
                }
                while (_levelOne.Collision(_apple.X, _apple.Y));
                _playerOne.Grow(1);

                Global.Score += 100;
                Global.TextBlockScore.Text = "Score " + Convert.ToString(Global.Score);
                SpeedManager(-5);
            }

            if (_playerOne.Collision(_playerOne.Head_X, _playerOne.Head_Y) || _levelOne.Collision(_playerOne.Head_X, _playerOne.Head_Y))
                    GameOver();

            _apple.Show();
            _playerOne.Show();
        }

        private static void GameOver()
        {
            _timer.Stop();
            Global.GameOver = true;
            _playerOne.ClearList();
            Global.LoseScreen.Opacity = 1;
        }

        private static void SpeedManager(int pDeltaSpeed)
        {
            if (_gameSpeed + pDeltaSpeed <= 1)
                _gameSpeed = 1;
            _gameSpeed = _gameSpeed + pDeltaSpeed;

            _timer.Interval = new TimeSpan(0, 0, 0, 0, _gameSpeed);
        }
    }
}
