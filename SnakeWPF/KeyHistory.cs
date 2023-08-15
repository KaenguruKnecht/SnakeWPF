using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnakeWPF
{
    static class KeyHistory
    {
        // Felder
        private static Key _waitingKey = Key.Right;
        private static Key _lastKey = Key.Right;

        public static void Add(Key key)
        {
            if (IsValidDirection(key))
            {
                if (IsNotOppositeDirection(key))
                    _lastKey = key;
            }
            else if (IsFunktionKey(key))
            {
                //if (key == Key.G)
                //    Grid.ToggleGrid();
                if (key == Key.Enter && Global.GameOver)
                    GameManager.Initialize();
            }
        }
            private static bool IsValidDirection(Key value)
            {
                if (value == Key.Left || value == Key.Right || value == Key.Up || value == Key.Down)
                    return true;
                return false;
            }

            private static bool IsFunktionKey(Key value) 
            {
                if (value == Key.G || value == Key.Enter)
                    return true;
                return false;
            }

            private static bool IsNotOppositeDirection(Key value)
            {
                if ((_waitingKey == Key.Left && value == Key.Right) || (_waitingKey == Key.Right && value == Key.Left) || (_waitingKey == Key.Up && value == Key.Down) || (_waitingKey == Key.Down && value == Key.Up))
                {
                    return false;
                }
                return true;
            }

            public static Key GetWaitingKey()
            {
                Key tempKey = _waitingKey;
                _waitingKey = _lastKey;

                return tempKey;
            }
    }
}
