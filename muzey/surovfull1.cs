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
    public partial class surovfull1 : Form
    {
        public surovfull1()
        {
            InitializeComponent();
        }

        private void surovfull1_Load(object sender, EventArgs e)
        {
            uploadDataToGridView();
        }
        public void uploadDataToGridView()
        {
            ControlEksponatlar controlEksponatlar = new ControlEksponatlar();
            dataGridView1.DataSource = controlEksponatlar.getDataEksponatlarsurov();
         //   dataGridView1.Columns["id"].Width = 50;
          //  dataGridView1.Columns["picture"].Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            label7.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label8.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string keyText = textBox7.Text.Trim();
            if (keyText != "")
            {
                ControlEksponatlar controlEksponatlar = new ControlEksponatlar();
                dataGridView1.DataSource = controlEksponatlar.searchDatafull(keyText);
              //  dataGridView1.Columns["id"].Width = 50;
               // dataGridView1.Columns["picture"].Visible = false;
            }
            else
            {
                MessageBox.Show("qidiruv maydoni bo'sh bo'lmasligi kerak.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string knom = textBox1.Text.Trim();
            string ksana = textBox2.Text.Trim();
            string kdavr = textBox3.Text.Trim();
            string kbnomi = textBox4.Text.Trim();
            string knarx1=textBox9.Text.Trim();
            string knarx2 = textBox18.Text.Trim();
            string kkvaqt = textBox8.Text.Trim();
            string kchvaqt = textBox6.Text.Trim();
            string kism = textBox5.Text.Trim();
            string kfam = textBox13.Text.Trim();
            string ktel = textBox12.Text.Trim();
            string kmanzil = textBox11.Text.Trim();
            string kseria = textBox10.Text.Trim();
            string kraqam = textBox17.Text.Trim();
            string krol = textBox16.Text.Trim();
            string ktumnomi = textBox15.Text.Trim();
            string kvilnomi=textBox14.Text.Trim();
            if (knom != "" || ksana != "" || kdavr != "" || kbnomi != "" || knarx1 != ""|| knarx2!=""||kkvaqt != "" ||kchvaqt != "" ||kism != "" ||kfam != "" ||ktel != "" ||kmanzil != "" ||kseria != "" ||kraqam != "" ||krol != "" ||ktumnomi != "" ||kvilnomi != "")
            {
                ControlEksponatlar controlEksponatlar = new ControlEksponatlar();
                dataGridView1.DataSource = controlEksponatlar.filtrfull(knom, ksana, kdavr, kbnomi, knarx1,knarx2, kkvaqt, kchvaqt, kism, kfam, ktel, kmanzil, kseria, kraqam, krol, ktumnomi, kvilnomi) ;
               
            }
            else
            {
                MessageBox.Show("qidiruv maydoni bo'sh bo'lmasligi kerak.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            uploadDataToGridView();
        }
    }
}
