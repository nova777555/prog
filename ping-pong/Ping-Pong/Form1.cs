using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ping_Pong
{
    public partial class Form1 : Form
    {
        const int RocketHeight = 70;
        const int RocketWidth = 10;
        const int radius = 10;
        const int RocketSpeed = 10;
        const int ballSpeedXStart = 10;

        Rectangle RPlayer = Rectangle.Empty;
        Rectangle LPlayer = Rectangle.Empty;
        Rectangle ball = Rectangle.Empty;
        Bitmap bm;
        Graphics g;
        Random random = new Random();

        int player1X = 0;
        int player1Y = 0;
        int player2X = 0;
        int player2Y = 0;
        int ballX = 0;
        int ballY = 0;
        int ballSpeedX = ballSpeedXStart;
        int ballSpeedY = 0;

        int tick = 0;
        bool start = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            bm = new Bitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm);

            player1X = pic.Width - RocketWidth;
            player1Y = pic.Height / 2 - RocketHeight / 2;
            player2X = 0;
            player2Y = pic.Height / 2 - RocketHeight / 2;
            ballX = pic.Width / 2 - radius;
            ballY = pic.Height / 2 - radius;
            ballSpeedY = random.Next(-5, 5);
            ballSpeedY = (Math.Abs(ballSpeedY) + 10) * Math.Sign(ballSpeedY);



            RPlayer = new Rectangle(player1X,player1Y, RocketWidth, RocketHeight);
            LPlayer = new Rectangle(player2X, player2Y, RocketWidth, RocketHeight);
            ball = new Rectangle(ballX, ballY, radius * 2, radius * 2);
            g.FillRectangle(Brushes.Black, RPlayer);
            g.FillRectangle(Brushes.Black, LPlayer);
            g.FillEllipse(Brushes.Red, ball);
            pic.Image = bm;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int key = e.KeyValue;
            if(key == 38)
            {
                if (player1Y - RocketSpeed >= 0)
                    player1Y -= RocketSpeed;
            }
            if (key == 40)
            {
                if (player1Y + RocketSpeed <=pic.Height-RocketHeight)
                    player1Y += RocketSpeed;
            }
            if (key == 87)
            {
                if (player2Y - RocketSpeed >= 0)
                    player2Y -= RocketSpeed;
            }
            if (key == 83)
            {
                if (player2Y + RocketSpeed <= pic.Height - RocketHeight)
                    player2Y += RocketSpeed;
            }
            if(key == 13 && start)
            {
                StartText.Visible = false;
                timer1.Enabled = true;
                start = false;
            }
        }       

        private void timer1_Tick(object sender, EventArgs e)
        { 
            tick++;            
            if (tick % 20 == 0) ballSpeedX = (Math.Abs(ballSpeedX) + 1) * Math.Sign(ballSpeedX);

            LPlayer.Y = player2Y;
            RPlayer.Y = player1Y;

            ballX += ballSpeedX;
            ballY += ballSpeedY;

            if (ballX <= RocketWidth && ballY > player2Y && ballY < player2Y + RocketHeight) ballSpeedX *= -1; else
            if (ballX >= pic.Width - RocketWidth - radius * 2 && ballY > player1Y && ballY < player1Y + RocketHeight) ballSpeedX *= -1; else
            if (ballY < 0 || ballY + 2 * radius > pic.Height) ballSpeedY *= -1; else
            if (ballX + 2 * radius > pic.Width)
            {
                LScore.Text = (int.Parse(LScore.Text) + 1).ToString();
                player1X = pic.Width - RocketWidth;
                player1Y = pic.Height / 2 - RocketHeight / 2;
                player2X = 0;
                player2Y = pic.Height / 2 - RocketHeight / 2;
                ballX = pic.Width / 2 - radius;
                ballY = pic.Height / 2 - radius;
                ballSpeedY = random.Next(-5, 5);
                ballSpeedY = (Math.Abs(ballSpeedY) + 10) * Math.Sign(ballSpeedY);
                tick = 0;
                ballSpeedX = ballSpeedXStart;
            } else
            if (ballX < 0)
            {
                RScore.Text = (int.Parse(RScore.Text) + 1).ToString();
                player1X = pic.Width - RocketWidth;
                player1Y = pic.Height / 2 - RocketHeight / 2;
                player2X = 0;
                player2Y = pic.Height / 2 - RocketHeight / 2;
                ballX = pic.Width / 2 - radius;
                ballY = pic.Height / 2 - radius;
                ballSpeedY = random.Next(-5, 5);
                ballSpeedY = (Math.Abs(ballSpeedY) + 10) * Math.Sign(ballSpeedY);
                tick = 0;
                ballSpeedX = ballSpeedXStart;
            }

            ball.X = ballX;
            ball.Y = ballY;

            g.Clear(Color.White);
            g.FillRectangle(Brushes.Black, RPlayer);
            g.FillRectangle(Brushes.Black, LPlayer);
            g.FillEllipse(Brushes.Red, ball);

            pic.Image = bm;
        }
    }
}
