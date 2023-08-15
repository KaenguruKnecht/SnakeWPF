using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SnakeWPF
{
    internal class Background
    {
        public void Export()
        {
            try
            {
                File.WriteAllText(@"C:\Users\Joshu\source\repos\SnakeWPF\SnakeWPF\Highscores\Highscores.txt", Global.Score.ToString());
                StreamWriter sw = new StreamWriter(@"Scores\Highscore.txt");
                sw.WriteLine(Global.Score.ToString());
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Export Fehler!" + e.Message);
            }
        }

        public void Import()
        {
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\Joshu\source\repos\SnakeWPF\SnakeWPF\Highscores\Highscores.txt");
                Global.Highscore = Convert.ToInt32(sr.ReadLine());
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Import Fehler!" + e.Message);
            }
        }
    }
}
