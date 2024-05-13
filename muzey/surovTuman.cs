using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace muzey
{
    public partial class surovTuman : Form
    {
        public surovTuman()
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
            ControlTumanlar controlTumanlar = new ControlTumanlar();
            dataGridView1.DataSource = controlTumanlar.getDataTumanlar();
            dataGridView1.Columns["ID"].Width = 50;
        }

        private void surovTuman_Load(object sender, EventArgs e)
        {
            uploadDataToGridView();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string keyText = textBox7.Text.Trim();
            if (keyText != "")
            {
                ControlTumanlar controlTumanlar = new ControlTumanlar();
                dataGridView1.DataSource = controlTumanlar.searchData(keyText);
                dataGridView1.Columns["ID"].Width = 50;
            }
            else
            {
                MessageBox.Show("Qidiruv maydoni bo'sh bo'lmasligi kerak.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keyTumannomi = textBox1.Text.Trim();
            string keyViloyatnomi= textBox2.Text.Trim();
            if (keyTumannomi != ""||keyViloyatnomi!="")
            {
                ControlTumanlar controlTumanlar = new ControlTumanlar();
                dataGridView1.DataSource = controlTumanlar.filtr(keyTumannomi,keyViloyatnomi);
                dataGridView1.Columns["ID"].Width = 50;
            }
            else
            {
                MessageBox.Show("ikkala maydon ham to'ldirilishi shart.");
            }
        }
    }
}
