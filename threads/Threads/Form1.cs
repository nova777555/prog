using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Threads
{
    public partial class Form1 : Form
    {
        Mutex mutex = new Mutex();
        DateTime now = new DateTime();
        string sec, min, hour;
        bool isWorking = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (isWorking)
            {
                timer1.Stop();
                Close();
            }
            else
            {
                timer1.Interval = 100;
                timer1.Start();
                isWorking = true;
                startButton.Text = "Stop!";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StartThreads();
            UpdateTime();
        }

        void UpdateSeconds()
        {
            mutex.WaitOne();
            now = DateTime.Now;
            if (now.Second >= 10)
                sec = now.Second.ToString();
            else
                sec = "0"+ now.Second.ToString();            
            mutex.ReleaseMutex();
        }
        void UpdateMinutes()
        {
            mutex.WaitOne();
            now = DateTime.Now;
            if(now.Minute >= 10)
                min = now.Minute.ToString();
            else
                min = "0" + now.Minute.ToString();            
            mutex.ReleaseMutex();
        }
        void UpdateHours()
        {
            mutex.WaitOne();
            now = DateTime.Now;
            if (now.Hour >= 10)
                hour = now.Hour.ToString();
            else
                hour = "0" + now.Hour.ToString();            
            mutex.ReleaseMutex();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartThreads();
        }

        public void StartThreads()
        {
            Thread Threads = new Thread(UpdateSeconds);
            Thread Threadm = new Thread(UpdateMinutes);
            Thread Threadh = new Thread(UpdateHours);
            Threads.Start();
            Threadm.Start();
            Threadh.Start();
        }
        public void UpdateTime()
        {
            s.Text = sec;
            m.Text = min;
            h.Text = hour;
        }
    }
}
