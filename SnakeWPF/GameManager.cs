using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
        private static Apple _redApple { get; set; }
        private static Apple _blueApple { get; set; }
        private static Level _levelOne { get; set; }
        private static Background _background { get; set; }

        // Methoden
        public static void Initialize()
        {

            _timer = new DispatcherTimer();
            _background = new Background();

            _gameSpeed = Global.StartSpeed;
            SpeedManager(0);

            _timer.Tick += OnTick;
            Global.GamingArea.Children.Clear();

            Global.Score = 0;
            Global.TextBlockScore.Text = "Score: " + Convert.ToString(Global.Score);

            _background.Import();
            Global.TextBlockHighscore.Text ="Highscore: " + Convert.ToString(Global.Highscore);

            Global.LoseScreen.Opacity = 0;

            Global.GameOver = false;
            _playerOne = new Snake();
            _redApple = new Apple();

            _levelOne = new Level();
            _levelOne.Create();
            _levelOne.Show();
            _playerOne.Show();
            _timer.Start();

        }

        private static void OnTick(object sender, EventArgs e)
        {
            _playerOne.RemoveFromCanvas();
            _redApple.RemoveFromCanvas();
            _playerOne.Move();
            _redApple.Show();
            _playerOne.Show();

            if (_redApple.Collision(_playerOne.Head_X, _playerOne.Head_Y))
            {
                do
                {
                    _redApple.SetNewPosition();
                }
                while (_levelOne.Collision(_redApple.X, _redApple.Y) || _playerOne.Collision(_redApple.X, _redApple.Y));
                _playerOne.Grow(1);

                Global.Score += 100;
                Global.TextBlockScore.Text = "Score " + Convert.ToString(Global.Score);
                SpeedManager(-5);
            }
            if (_playerOne.Collision(_playerOne.Head_X, _playerOne.Head_Y) || _levelOne.Collision(_playerOne.Head_X, _playerOne.Head_Y))
            {
                _background.Export();
                GameOver();
            }


        }

        private static void GameOver()
        {
            _timer.Stop();
            Global.GameOver = true;
            _playerOne.ClearList();
            Global.LoseScreen.Opacity = 1;
            Initialize();
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
