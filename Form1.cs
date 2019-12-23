using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private double p = 0.0;
        private double p1 = 0.0;
        private double p2 = 0.0;
        private readonly int totalTacts = 100000;
        
        private double averageQueueLength = 0;
        private double averageQueueTime = 0;
        private double processed = 0;

        SourceChannel sourceChannel;
        FirstChannel firstChannel;
        QueueState queueState;
        SecondChannel secondChannel;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                p = Convert.ToDouble(tbP.Text);
                p1 = Convert.ToDouble(tbP1.Text);
                p2 = Convert.ToDouble(tbP2.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sourceChannel = new SourceChannel(p);
            firstChannel = new FirstChannel(p1);
            queueState = new QueueState();
            secondChannel = new SecondChannel(p2);

            for (int i = 0; i < totalTacts; i++)
            {
                secondChannel.Action();
                queueState.Action();
                firstChannel.Action();
                sourceChannel.Action();
            }

            AssignValues();
            OutputValues();
        }

        private void OutputValues()
        {
            lblTotal.Text = "Всего тактов: " + totalTacts.ToString();
            lblTotalBandwidth.Text = "Абсолютная пропускная способность: " + Convert.ToString(Math.Round(processed / totalTacts, 4));
            lblAverageQueueLength.Text = "Средняя длина очереди: " + Convert.ToString(Math.Round(averageQueueLength / totalTacts, 4));
            lblAverageQueueTime.Text = "Ср. время пребывания в очереди: " + Convert.ToString(Math.Round(averageQueueTime, 4));
        }

        private void AssignValues()
        {
            averageQueueLength = queueState.QueueTime;
            processed = secondChannel.Processed;
            averageQueueTime = averageQueueLength / processed;
        }

        private void PrintState(int i) //debug
        { // state - private field in SourceChannel
            //Debug.WriteLine(i + ") " + sourceChannel.state + "->" + Convert.ToInt32(!FirstChannel.IsEmpty) + "->" + QueueState.State + "->" + Convert.ToInt32(!SecondChannel.IsEmpty));
            
        }
    }
}
