using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeural
{
    public class Aleatorio
    {
        private static readonly Random random = new Random();
        private static readonly object synclok = new object();

        public static float Obter()
        {
            lock (synclok)
            {
                return (float)random.NextDouble();
            }
        }

        public static int ObterEntre(int min, int max)
        {
            lock (synclok)
            {
                return random.Next(min, max);
            }
        }
    }
}
