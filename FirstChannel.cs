using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class FirstChannel
    {
        private Random rnd;
        private double p1 = 0.0;
        private double number = 0;

        public static bool IsEmpty { get; set; }
        public int Failure { get; set; }
        public int Released { get; set; }

        public FirstChannel(double p1)
        {
            this.p1 = p1;
            IsEmpty = true;
            rnd = new Random(Guid.NewGuid().GetHashCode());
            Failure = 0;
            Released = 0;
        }
        // 7 var
        public void Action()
        {
            number = rnd.NextDouble();
            if (!IsEmpty)
            {
                if (number < p1)
                {
                    return;
                }
                else
                {
                    if (SecondChannel.IsEmpty)
                    {
                        SecondChannel.IsEmpty = false;
                        IsEmpty = true;
                        return;
                    }
                    if (QueueState.State == 0 || QueueState.State == 1)
                    {
                        QueueState.State++;
                        IsEmpty = true;
                        return;
                    }
                    if (QueueState.State == 2)
                    {
                        Released++;
                        IsEmpty = true;
                        return;
                    }
                }
            }
        }
    }
}
