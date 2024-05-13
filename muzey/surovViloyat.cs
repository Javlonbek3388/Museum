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
    public partial class surovViloyat : Form
    {
        public surovViloyat()
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

        private void surovViloyat_Load(object sender, EventArgs e)
        {
            uploadDataToGridView();
        }
        public void uploadDataToGridView()
        {
            ControlViloyatlar controlViloyatlar = new ControlViloyatlar();
            dataGridView1.DataSource = controlViloyatlar.getDataViloyatlar();
            dataGridView1.Columns["id"].Width = 50;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
