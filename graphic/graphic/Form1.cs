using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace graphic
{
    public partial class Form1 : Form
    {
        
        public int selected;
        public int d = 50;
        float[] a;
        float k = 0;
        public Form1()
        {
            InitializeComponent();            
            Draw(0);
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox3.Visible = false;
            label4.Visible = false;
            textBox2.Visible = false;
            label5.Visible = false;
        }
    

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = comboBox1.SelectedIndex + 1;
            if(selected == 3)
            {
                label1.Visible = true;
                label5.Visible = false;
                label2.Text = "Введите n";
                textBox1.Text = "Введите n";
                textBox3.Text = "Введите wi";
                label1.Text = "Введите wi через пробел";
                label4.Text = "Введите w0";
                textBox2.Text = "Введите w0";
                textBox1.Visible = true;
                textBox3.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label4.Visible = true;
                textBox2.Visible = true;
            }
            if(selected == 2)
            {
                label4.Text = "Введите A";
                textBox2.Text = "Введите A";
                label2.Text = "Введите w2";
                textBox1.Text = "Введите w2";
                textBox3.Text = "Введите w1";
                label4.Visible = true;
                textBox2.Visible = true;
                textBox1.Visible = true;
                textBox3.Visible = true;
                label1.Visible = true;
                label5.Visible = true;
                label2.Visible = true;
                label1.Visible = false;
            }
            if(selected == 1)
            {
                label1.Text = "Введите ai через пробел";
                label1.Visible = true;
                label5.Visible = false;                
                label2.Text = "Введите n";
                textBox1.Text = "Введите n";
                textBox3.Text = "Введите ai";
                textBox1.Visible = true;
                textBox3.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label4.Visible = false;
                textBox2.Visible = false;
                
            }
        }

        public void Draw(int n)
        {
            pictureBox1.Image = new Bitmap(525, 284);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Pen pen = new Pen(Color.Black, 1);           
            g.DrawLine(pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, 284);
            g.DrawLine(pen, 0, pictureBox1.Height / 2, 525, pictureBox1.Height / 2);
            if (n == 0) return;           
            
            if (n == 1)
            {
                k = float.Parse(textBox1.Text);
                string s = textBox3.Text;
                a = s.Split(' ').Select(float.Parse).ToArray();
                float q = 0F;
                for (int i = 1; i <= 5; i++)
                {
                    g.DrawLine(pen, q, 142 - 5, q, 142 + 5);
                    q += 131F;
                }
                q = 142F;
                while (q <= 284F)
                {
                    g.DrawLine(pen,262 - 5, q, 262 + 5, q);
                    q += 7.1F;
                }
                q = 142F;
                while (q >= 0F)
                {
                    g.DrawLine(pen, 262 - 5, q, 262 + 5, q);
                    q -= 7.1F;
                }
                label3.Text = "цена деления = " + d / 10F;
                pen.Color = Color.Red;
                float xnow = d / 5F * -1;
                float dx = d * (2F / 5F / 525F);
                float yold = 0;
                float ynew = 0;
                for(int i = 0; i<=k; i++)
                {
                    yold += (float)Math.Pow(xnow, k - i) * a[i] * (50F/d/100*142);
                }
                for(int i = 0; i<524; i++)
                {
                    for (int j = 0; j <= k; j++)
                    {
                        ynew += a[j] * (float)Math.Pow(xnow+dx, k - j) * (50F/d/ 100 * 142);
                    }
                    g.DrawLine(pen,i,142-yold,i+1,142-ynew);
                    yold = ynew;
                    ynew = 0;
                    xnow += dx;
                }
            }
            if (n == 2)
            {
                float w1 = float.Parse(textBox3.Text);
                float w2 = float.Parse(textBox1.Text);
                float A = float.Parse(textBox2.Text);
                label3.Text = "цена деления = " + d / 100F;
                float q = 0F;
                for (int i = 1; i <= A*4+1; i++)
                {
                    g.DrawLine(pen, q, 142 - 5, q, 142 + 5);
                    q += 525F/A/4F;
                }
                q = 142F;
                while (q <= 284F)
                {
                    g.DrawLine(pen, 262 - 5, q, 262 + 5, q);
                    q += 525F / A / 4F;
                }
                q = 142F;
                while (q >= 0F)
                {
                    g.DrawLine(pen, 262 - 5, q, 262 + 5, q);
                    q -= 525F / A / 4F;
                }
                pen.Color = Color.Red;
                float xnow = d / 50F * -1*A;
                float dx = d*A/525/25;
                float yold = A*(float)Math.Sin(w1*xnow)*(float)Math.Sin(w2 * xnow)*(50F / d * 262F/A);
                float ynew = 0;
                for (int i = 0; i < 524; i++)
                {
                    ynew = (float)Math.Sin(w1 * (xnow+dx)) * (float)Math.Sin(w2 * (xnow + dx))*(50F / d * 262F);
                    g.DrawLine(pen, i, 142 - yold, i + 1, 142 - ynew);
                    yold = ynew;
                    ynew = 0;
                    xnow += dx;
                }
            }
            if (n == 3)
            {
                float q = 0F;
                for (int i = 1; i <= 13; i++)
                {
                    g.DrawLine(pen, q, 142 - 5, q, 142 + 5);
                    q += 525F / 12F;
                }
                q = 142F;
                while (q <= 284F)
                {
                    g.DrawLine(pen, 262 - 5, q, 262 + 5, q);
                    q += 25F;
                }
                q = 142F;
                while (q >= 0F)
                {
                    g.DrawLine(pen, 262 - 5, q, 262 + 5, q);
                    q -= 25F;
                }
                string s = textBox3.Text;
                a = s.Split(' ').Select(float.Parse).ToArray();
                float k = float.Parse(textBox1.Text);
                float w0 = float.Parse(textBox2.Text);

                label3.Text = "цена деления = " + d / 100F;

                pen.Color = Color.Red;
                float xnow = -3F*d/50F;
                float dx = 3F*d/25F/525F;
                float yold = 0;
                float ynew = 0;
                for (int i = 0; i < k; i++)
                {
                    yold += (float)Math.Sin(w0*xnow+a[i])* (50F / d*50);
                }
                for (int i = 0; i < 524; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        ynew += (float)Math.Sin(w0 * xnow + a[j]) * (50F / d*50);
                    }
                    g.DrawLine(pen, i, 142 - yold, i + 1, 142 - ynew);
                    yold = ynew;
                    ynew = 0;
                    xnow += dx;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите n" && selected==1) return;
            if (textBox1.Text == "Введите n" && selected == 3) return;
            if (textBox1.Text == "Введите w2" && selected == 2) return;
            if (textBox3.Text == "Введите ai" && selected == 1) return;
            if (textBox3.Text == "Введите w1" && selected == 2) return;
            if (textBox3.Text == "Введите wi" && selected == 3) return;
            if (textBox2.Text == "Введите w0" && selected == 3) return;
            if (textBox2.Text == "Введите A" && selected == 2) return;
                       
            label3.Visible = true;
            Draw(selected);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            d = hScrollBar1.Value;
            label3.Visible = true;
            Draw(selected);
        }

       
        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
