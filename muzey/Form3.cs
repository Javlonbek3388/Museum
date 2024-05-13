using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzey
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form8 form4 = new Form8();
            this.Hide();
            form4.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.ShowDialog();
            this.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Hide();
            form6.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form7 form6 = new Form7();
            this.Hide();
            form6.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label8.Text = DateTime.Now.ToString("HH:mm:ss");
            //pictureBox1.Image = Image.FromFile("../..Resources/users/"+ UserLogin.userPhoto);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor=Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
           // .ForeColor = Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
          //  label3.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Red;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label8.Text = DateTime.Now.ToString("HH:mm:ss");
           // pictureBox1.Image = Image.FromFile("../../Resources/users/" + UserLogin.userPhoto);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         //   pictureBox1.Image = Image.FromFile("../../Resources/users/" + UserLogin.userPhoto);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            form5.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form1 form2 = new Form1();
            //this.Hide();
            //form2.ShowDialog();
            //this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            surovBulimcs f = new surovBulimcs();
            this.Hide();
            f.ShowDialog();
            this.Close();   

        }

        private void label13_Click(object sender, EventArgs e)
        {
            surovFoydalanuvchi f=new surovFoydalanuvchi();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void label14_MouseHover(object sender, EventArgs e)
        {
            label14.ForeColor = Color.Red;
        }

        private void label13_MouseHover(object sender, EventArgs e)
        {
            label13.ForeColor = Color.Red;
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {

            label12.ForeColor = Color.Red;
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Red;
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            label10.ForeColor = Color.Red;
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            label14.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            label13.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            label12.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            surovEksponatlar f = new surovEksponatlar();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            surovViloyat f = new surovViloyat();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            surovTuman f = new surovTuman();    
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            surovfull1 f = new surovfull1();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void label16_MouseHover(object sender, EventArgs e)
        {
            label16.ForeColor = Color.Red;
        }

        private void label16_MouseLeave(object sender, EventArgs e)
        {
            label16.ForeColor = Color.FromArgb(65, 105, 225);
        }
    }
}
