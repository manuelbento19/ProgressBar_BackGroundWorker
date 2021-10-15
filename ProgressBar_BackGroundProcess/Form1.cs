using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar_BackGroundProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!backgroundWorker1.IsBusy)
            backgroundWorker1.RunWorkerAsync();
            else
            MessageBox.Show("Aguarde enquanto está a ser executado um processo!");
        }
        private void bar_progress()
        {
            for (int i = 0; i <= 100; i++)
            {
                backgroundWorker1.ReportProgress(i);
                Thread.Sleep(50);
                button1.Text = "...";
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bar_progress();
            notifyIcon1.Visible = true;

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = e.ProgressPercentage+ " %";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Terminado!");
            button1.Text = "Iniciar";
            notifyIcon1.ShowBalloonTip(30000,"Estado","Finalizado.",ToolTipIcon.Info);
        }
    }
}
