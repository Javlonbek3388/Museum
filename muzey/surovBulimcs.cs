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
    public partial class surovBulimcs : Form
    {
        public surovBulimcs()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label8.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form6 = new Form3();
            this.Hide();
            form6.ShowDialog();
            this.Close();
        }
        public void uploadDataToGridView()
        {
            ControlBulimlar controlBulimlar = new ControlBulimlar();
            dataGridView1.DataSource = controlBulimlar.getDataBulimlar();
            dataGridView1.Columns["id"].Width = 50;
        }

        private void surovBulimcs_Load(object sender, EventArgs e)
        {
            uploadDataToGridView();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            string keyText = textBox7.Text.Trim();
            if (keyText != "")
            {
                ControlBulimlar controlBulimlar = new ControlBulimlar();
                dataGridView1.DataSource = controlBulimlar.searchData(keyText);
                dataGridView1.Columns["id"].Width = 50;
            }
            else
            {
                MessageBox.Show("Qidiruv maydoni bo'sh bo'lmasligi kerak.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keyBulimnomi = textBox1.Text.Trim();
            int keyNarxi=int.Parse(textBox2.Text.Trim()); 
            string keyIshchinomi=textBox3.Text.Trim();

            if (keyBulimnomi != ""|| keyNarxi!=0 || keyIshchinomi!="")
            {
                ControlBulimlar controlBulimlar = new ControlBulimlar();
                dataGridView1.DataSource = controlBulimlar.filtr(keyBulimnomi,keyNarxi,keyIshchinomi);
                dataGridView1.Columns["id"].Width = 50;
            }
            else
            {
                MessageBox.Show("Qidiruv maydoni bo'sh bo'lmasligi kerak.");
            }
        }
    }
}
