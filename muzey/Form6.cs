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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            uploadDataToGridView();
        }
        public void uploadDataToGridView()
        {
            ControlViloyatlar controlViloyatlar = new ControlViloyatlar();
            dataGridView1.DataSource = controlViloyatlar.getDataViloyatlar();
            dataGridView1.Columns["id"].Width = 50;
        }
    }
}
