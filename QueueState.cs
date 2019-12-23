using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class QueueState
    {
        public static int State { get; set; }
        public int Length { get; set; }
        public int QueueTime { get; set; }

        public QueueState()
        {
            State = 0;
            QueueTime = 0;
            Length = 0;
        }

        public void Action()
        {
            if (State > 0)
            {
                QueueTime += State;
            }
            if (State > 0 && SecondChannel.IsEmpty)
            {
                SecondChannel.IsEmpty = false;
                State--;
                return;
            }
        }
    }
}
