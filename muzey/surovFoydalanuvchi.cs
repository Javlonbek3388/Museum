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
    public partial class surovFoydalanuvchi : Form
    {
        public surovFoydalanuvchi()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
         
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
            ControlFoydalanuvchilar controlFoydalanuvchilar = new ControlFoydalanuvchilar();
            dataGridView1.DataSource = controlFoydalanuvchilar.getDataFoydalanuvchilar();
            dataGridView1.Columns["id"].Width = 50;
            dataGridView1.Columns["picture"].Visible = false;
            dataGridView1.Columns["Logen"].Visible = false;
            dataGridView1.Columns["Parol"].Visible = false;

        }

        private void surovFoydalanuvchi_Load(object sender, EventArgs e)
        {
            //ControlTumanlar controlTumanlar = new ControlTumanlar();

            //DataTable dataTable = controlTumanlar.getDataTumanlar();
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    comboBox2.Items.Add(row["Nomi"].ToString());
            //}

            //// pictureBox1.Image = Image.FromFile("../..Resources/users/" + UserLogin.userPhoto);
            //comboBox1.SelectedIndex = 0;
            //comboBox2.SelectedIndex = 0;
            uploadDataToGridView();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string keyText = textBox7.Text.Trim();
            if (keyText != "")
            {
                ControlFoydalanuvchilar controlFoydalanuvchilar = new ControlFoydalanuvchilar();
                dataGridView1.DataSource = controlFoydalanuvchilar.searchData(keyText);
                dataGridView1.Columns["id"].Width = 50;
                dataGridView1.Columns["picture"].Visible = false;
                dataGridView1.Columns["Logen"].Visible = false;
                dataGridView1.Columns["parol"].Visible = false;
            }
            else
            {
                MessageBox.Show("qidiruv maydoni bo'sh bo'lmasligi kerak.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keyIsm = textBox1.Text.Trim();
            string keyFamiliya= textBox2.Text.Trim();   
            if (keyIsm != "" || keyFamiliya!="")
            {
                if (keyIsm == textBox1.Text&&keyFamiliya==textBox2.Text)
                {
                    ControlFoydalanuvchilar controlFoydalanuvchilar = new ControlFoydalanuvchilar();
                    dataGridView1.DataSource = controlFoydalanuvchilar.filtr(keyIsm, keyFamiliya);
                    dataGridView1.Columns["id"].Width = 50;
                    dataGridView1.Columns["picture"].Visible = false;
                    dataGridView1.Columns["Logen"].Visible = false;
                    dataGridView1.Columns["parol"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Bu obyekt mavjud emas");
                }
            }
            else
            {
                MessageBox.Show("ikkala maydonni to'ldirish shart.");
            }
        }
    }
}
