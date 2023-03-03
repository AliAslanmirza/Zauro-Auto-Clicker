using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Farklı_Pencere_Taslağı.Form1;

//Made by Ali Aslanmirza. All codes and designs It belongs to me.
//Ali Aslanmirza tarafından yapılmıştır. Kodları ve tasarımı tamamen bana aittir.

namespace Farklı_Pencere_Taslağı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point lastpoint;
        [DllImport("user32.dll")]

        static extern void mouse_event(int dwFlags, int dx, int dy, int dwdata, int dwextrainfo);

        
        
        //Mouse Events
        //Mouse olaylarının yönetildiği yer
        public enum mouseeventflags
        {
            LeftDown = 2,
            LeftUp=4,
            RIGHTDOWN = 8,
            RIGHTUP = 10,
        }

        
        
            
        //Leftclick event
        //Sol Click eventi
        public void leftclick(Point p)
        {
            mouse_event((int) (mouseeventflags.LeftDown),p.X,p.Y, 0, 0);
            mouse_event((int)(mouseeventflags.LeftUp), p.X, p.Y, 0, 0);
        }
        //Rightclick event
        //Sağ Click eventi
        public static void Rightclick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(mouseeventflags.RIGHTDOWN), 0, 0, 0, 0);
            mouse_event((int)(mouseeventflags.RIGHTUP), 0, 0, 0, 0);
        }






        bool stop = true;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            stop = (stop) ? false : true;
            timer1.Interval = (int)numericUpDown1.Value;
            timer1.Enabled = true;

            tiklama = 0;
         
            if (!stop) {
                timer1.Start();
                timer2.Start();
            }
            if (stop) 
            { 
                timer1.Stop();
                timer2.Stop();
            }
            
        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            //Zamanlayıcı
            //Timer

            if (textBox2.Text!="0")
            {
                int mins = Convert.ToInt32(textBox2.Text);

                int sure = 60000 * mins;

                await Task.Delay(sure);
                timer1.Stop();
            }

            else { }
           

        }


        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                leftclick(new Point(MousePosition.X, MousePosition.Y));
                int tiklamasinir = Convert.ToInt32(textBox3.Text);

                if (textBox3.Text != "0")
                {
                    if (tiklama >= tiklamasinir)
                    {
                        //Tıklama sınırı
                        //Click Limit
                        timer1.Stop();
                        timer2.Stop();
                    }
                    else
                    {
                        tiklama++;
                    }
                }
            }

            else if (radioButton2.Checked == true)
            {
                Rightclick(MousePosition.X, MousePosition.Y);
                int tiklamasinir = Convert.ToInt32(textBox3.Text);
                //Sağ tık için kodlar
                //Right click codes
                if (textBox3.Text != "0")
                {
                    if (tiklama >= tiklamasinir)
                    {

                        timer1.Stop();
                        timer2.Stop();
                    }
                    else
                    {
                        tiklama++;
                    }
                }
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { this.TopMost = true; }
            else { this.TopMost = false; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {//kısayol komutu
            //shortcut codes
            if (e.KeyCode == Keys.F7)
            {
                timer2.Start();
                timer1.Start();
                tiklama = 0;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        int tiklama = 0;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {
            label13.Visible= true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            label13.Visible = true;
        }
        bool uyarıgoster = true;
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox3.Text = "10";

                if (uyarıgoster == true)
                {
                    MessageBox.Show("This setting is during development stage, please use the recommended settings.", "⚠️Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);

                    uyarıgoster=false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This setting is during development stage, coming soon.", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
