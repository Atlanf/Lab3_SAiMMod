using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class SourceChannel
    {
        private Random rnd;
        private double p = 0.0;

        private double a;

        private int state;

        public int Failure { get; private set; }
        public int Locked { get; private set; }

        public SourceChannel(double p)
        {
            this.p = p;
            rnd = new Random(101);
            state = 0;
            Locked = 0;
            Failure = 0;
        }

        public void Action()
        {
            a = rnd.NextDouble();
            if (FirstChannel.IsEmpty)
            {
                if (state == 1)
                {
                    FirstChannel.IsEmpty = false;
                    state = 0;
                    return;
                }
                if (a < p) 
                {
                    Failure++;
                    return;
                }
                else
                {
                    FirstChannel.IsEmpty = false;
                    return;
                }
            }
            if (!FirstChannel.IsEmpty)
            {
                if (state == 0 && a > p)
                    state = 1;
                Locked++;
            }
        }
    }
}
