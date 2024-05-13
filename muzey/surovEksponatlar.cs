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
    public partial class surovEksponatlar : Form
    {
        public surovEksponatlar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form6 = new Form3();
            this.Hide();
            form6.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label8.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        public void uploadDataToGridView()
        {
            ControlEksponatlar controlEksponatlar = new ControlEksponatlar();
            dataGridView1.DataSource = controlEksponatlar.getDataEksponatlar();
            dataGridView1.Columns["id"].Width = 50;
            dataGridView1.Columns["picture"].Visible = false;
        }

        private void surovEksponatlar_Load(object sender, EventArgs e)
        {
            uploadDataToGridView();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string keyText = textBox7.Text.Trim();
            if (keyText != "")
            {
                ControlEksponatlar controlEksponatlar = new ControlEksponatlar();
                dataGridView1.DataSource = controlEksponatlar.searchData(keyText);
                dataGridView1.Columns["id"].Width = 50;
                dataGridView1.Columns["picture"].Visible = false;
            }
            else
            {
                MessageBox.Show("qidiruv maydoni bo'sh bo'lmasligi kerak.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keyBulim = textBox1.Text.Trim();
            string keySana= textBox2.Text.Trim();
            if (keyBulim != ""||keySana!="")
            {
                ControlEksponatlar controlEksponatlar = new ControlEksponatlar();
                dataGridView1.DataSource = controlEksponatlar.filtr(keyBulim,keySana);
                dataGridView1.Columns["id"].Width = 50;
                dataGridView1.Columns["picture"].Visible = false;
            }
            else
            {
                MessageBox.Show("qidiruv maydoni bo'sh bo'lmasligi kerak.");
            }
        }
    }
}
