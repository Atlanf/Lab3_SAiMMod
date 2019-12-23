using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class SecondChannel
    {
        Random rnd;

        private double p2 = 0.0;
        private double number = 0;

        public static bool IsEmpty { get; set; }
        public int Failure { get; set; }
        public int Processed { get; set; }

        public SecondChannel(double p2)
        {
            this.p2 = p2;
            rnd = new Random(4242440);
            IsEmpty = true;
            Failure = 0;
            Processed = 0;
        }

        public void Action()
        {
            if ((number = rnd.NextDouble()) < p2)
            {
                return;
            }
            else if (!IsEmpty)
            {
                Processed++;
                IsEmpty = true;
            }
        }
    }
}
