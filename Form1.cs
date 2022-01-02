using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace randomgame
{
    public partial class Form1 : Form
    {
        int obj1;
        int obj2;
        int obj3;
        int ustLevel = 10;
        int altLevel = 5;
        bool basladiMi = false;
        int skor = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
            if(basladiMi)
            {
                pictureBox1.Top += obj1;
                pictureBox2.Top += obj2;
                pictureBox3.Top += obj3;
                int down = 660;
                Random rd = new Random();

                kazandinMi();
                kaybettinMi();

                sepeteCarparsa(rd, 600);
                yereCarparsa(rd);
            }

        }
        void kazandinMi()
        {
            if(skor > 5)
            {
                basladiMi = false;
                button1.Visible = true;
                skor = 0;
                yerleriSifirla();
                MessageBox.Show("Kazandın");
            }
        }

        void yerleriSifirla()
        {
            pictureBox1.Location = new Point(100, 0);
            pictureBox2.Location = new Point(300, 0);
            pictureBox3.Location = new Point(500, 0);
        }
        void kaybettinMi()
        {
            if (skor < -4)
            {
                basladiMi = false;
                button1.Visible = true;
                skor = 0;
                yerleriSifirla();
                MessageBox.Show("Kaybettin"); 
            }
        }
        void yereCarparsa(Random rd)
        {
            if (Math.Abs((pictureBox1.Location.X - pictureBox4.Location.X)) < 50 && Math.Abs((pictureBox1.Location.Y - pictureBox4.Location.Y)) < 50)
            {
                var x1 = rd.Next(600);
                obj1 = rd.Next(altLevel,ustLevel);
                pictureBox1.Location = new Point(x1, 0);
                skor++;
            }
            if (Math.Abs((pictureBox2.Location.X - pictureBox4.Location.X )) < 50 && Math.Abs((pictureBox2.Location.Y - pictureBox4.Location.Y)) < 50)
            {
                var x2 = rd.Next(600);
                obj2 = rd.Next(altLevel,ustLevel);

                pictureBox2.Location = new Point(x2, 0);
                skor++;
            }
            if (Math.Abs((pictureBox3.Location.X - pictureBox4.Location.X)) < 50 && Math.Abs((pictureBox3.Location.Y - pictureBox4.Location.Y)) < 50)
            {
                var x3 = rd.Next(600);
                obj3 = rd.Next(altLevel,ustLevel);

                pictureBox3.Location = new Point(x3, 0);
                skor++;
            }
            label1.Text ="Skor " + skor.ToString();
        }

        void sepeteCarparsa(Random rd, int down)
        {
            if (pictureBox1.Top > down)
            {
                var x1 = rd.Next(600);
                obj1 = rd.Next(altLevel,ustLevel);
                pictureBox1.Location = new Point(x1, 0);
                skor--;
            }
           
            if (pictureBox2.Top > down)
            {
                var x2 = rd.Next(600);
                obj2 = rd.Next(altLevel,ustLevel);

                pictureBox2.Location = new Point(x2, 0);
                skor--;

            }
            if (pictureBox3.Top > down)
            {
                var x3 = rd.Next(600);
                obj3 = rd.Next(altLevel,ustLevel);

                pictureBox3.Location = new Point(x3, 0);
                skor--;

            }
            label1.Text = "Skor " + skor.ToString();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.D)
            {
                pictureBox4.Left += 10;
            }
            else if (keyData == Keys.A)
            {
                pictureBox4.Left -= 10;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!basladiMi)
            {
                button1.Visible = false;
                Random rd = new Random();
                timer1.Start();
                obj1 = rd.Next(altLevel, ustLevel);
                obj2 = rd.Next(altLevel, ustLevel);
                obj3 = rd.Next(altLevel, ustLevel);
                basladiMi = true;
            }
        }
    }
}
