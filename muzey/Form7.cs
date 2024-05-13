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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            //pictureBox1.Image = Image.FromFile("../..Resources/users/"+ UserLogin.userPhoto);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nomi = textBox2.Text.Trim();
            int narxi = int.Parse(textBox3.Text.Trim());
            string kirish_vaqti = textBox4.Text.Trim();
            string chiqish_vaqti = textBox5.Text.Trim();
            //ControlBulimlar controlBulimlar = new ControlBulimlar();
            //int ishchi_id =controlBulimlar.getIdByName(comboBox1.SelectedItem.ToString());
            ControlFoydalanuvchilar controlFoydalanuvchilar = new ControlFoydalanuvchilar();
            int ishchi_id =controlFoydalanuvchilar.getIdByName(comboBox1.SelectedItem.ToString());

            if (nomi != "" && narxi != 0 && kirish_vaqti != "" && chiqish_vaqti != "" && ishchi_id != 0)
            {
                Bulimlar bulimObj = new Bulimlar(nomi, narxi, kirish_vaqti, chiqish_vaqti, ishchi_id);
                ControlBulimlar controlBulim = new ControlBulimlar();
                if (controlBulim.InsertBulim(bulimObj))
                {
                    MessageBox.Show("Ma'lumot kiritildi.");
                    clearBoxs();
                }
                else
                {
                    MessageBox.Show("Ma'lumot kiritilmadi.");
                }

            }
            else
            {
                MessageBox.Show("Barcha maydonlar to'ldirilishi shart.");
            }

        }
        public void clearBoxs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedIndex = 0;
            //textBox6.Text = "";
            textBox7.Text = "";
            uploadDataToGridView();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            ControlFoydalanuvchilar controlFoydalanuvchilar = new ControlFoydalanuvchilar();

            DataTable dataTable = controlFoydalanuvchilar.getDataFoydalanuvchilar();

            foreach(DataRow row in dataTable.Rows)
            {
                comboBox1.Items.Add(row["Ism"].ToString());
            }
            comboBox1.SelectedIndex = 0;

            uploadDataToGridView();
        }
        public void uploadDataToGridView()
        {
            ControlBulimlar controlBulimlar = new ControlBulimlar();
            dataGridView1.DataSource = controlBulimlar.getDataBulimlar();
            dataGridView1.Columns["id"].Width = 50;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["nomi"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["narxi"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["kirish_vaqti"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["chiqish_vaqti"].FormattedValue.ToString();
                comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["xodim"].FormattedValue.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id=int.Parse(textBox1.Text);
                string nomi=textBox2.Text;
                int narxi=int.Parse(textBox3.Text);
                string kirish_vaqti=textBox4.Text;
                string chiqish_vaqti=textBox5.Text;
                ControlFoydalanuvchilar controlFoydalanuvchilar = new ControlFoydalanuvchilar();
                int ishchi_id = controlFoydalanuvchilar.getIdByName(comboBox1.SelectedItem.ToString());

                ControlBulimlar controlBulimlar = new ControlBulimlar();
                if (controlBulimlar.updateBulim(new Bulimlar(id,nomi,narxi,kirish_vaqti,chiqish_vaqti,ishchi_id)))
                {
                    MessageBox.Show("Ma'lumot o'zgardi.");
                    clearBoxs();
                }
                else
                {
                    MessageBox.Show("Ma'lumot o'zgarmadi.");
                }

            }
            else
            {
                MessageBox.Show("Element tanlanmagan.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                int id=int .Parse(textBox1.Text);
                DialogResult dr = MessageBox.Show("Element o'chirilsinmi?", "O'chirish", MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                  ControlBulimlar controlBulimlar=new ControlBulimlar();
                    if (controlBulimlar.deleteData(id))
                    {
                        MessageBox.Show("Element o'chirildi.");
                        clearBoxs();
                    }
                    else
                    {
                        MessageBox.Show("Element o'chirilmadi.");
                    }
                }
               
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string keyText= textBox7.Text.Trim();
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

        private void button4_Click(object sender, EventArgs e)
        {
            clearBoxs();
        }
    }
}
