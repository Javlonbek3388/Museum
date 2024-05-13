using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace muzey
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label4.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label5.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            ControlViloyatlar controlViloyatlar = new ControlViloyatlar();

            DataTable dataTable = controlViloyatlar.getDataViloyatlar();
            foreach (DataRow row in dataTable.Rows)
            {
                comboBox1.Items.Add(row["nomi"].ToString());
            }
            comboBox1.SelectedIndex= 0;
            uploadDataToGridView();
        }
        public void uploadDataToGridView()
        {
            ControlTumanlar controlTumanlar = new ControlTumanlar();
            dataGridView1.DataSource = controlTumanlar.getDataTumanlar();
            dataGridView1.Columns["ID"].Width = 50;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Nomi= textBox2.Text.Trim();
            ControlViloyatlar controlViloyatlar= new ControlViloyatlar();
            int ViloyatID= controlViloyatlar.getIdByName(comboBox1.SelectedItem.ToString());

            if (Nomi != "" && ViloyatID != 0)
            {
                Tumanlar tumanObj=new Tumanlar(Nomi, ViloyatID);
                ControlTumanlar controlTuman=new ControlTumanlar();
                if(controlTuman.InsertTuman(tumanObj))
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
           // MessageBox.Show(ViloyatID.ToString());
        }
        public void clearBoxs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
           // textBox3.Text = "";
            textBox4.Text = "";
            uploadDataToGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Nomi"].FormattedValue.ToString();
                //textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["ViloyatID"].FormattedValue.ToString();
                comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["viloyat"].FormattedValue.ToString().ToLower();   
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int ID = int.Parse(textBox1.Text);
                string Nomi = textBox2.Text;
                ControlViloyatlar controlViloyatlar = new ControlViloyatlar();
                int ViloyatID = controlViloyatlar.getIdByName(comboBox1.SelectedItem.ToString());
                ControlTumanlar controlTumanlar = new ControlTumanlar();
                if (controlTumanlar.updateTuman(new Tumanlar(ID,Nomi,ViloyatID)))
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int ID = int.Parse(textBox1.Text);
                DialogResult dr = MessageBox.Show("Element o'chirilsinmi?", "O'chirish", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ControlTumanlar controlTumanlar = new ControlTumanlar();
                    if (controlTumanlar.deleteData(ID))
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

        private void button5_Click(object sender, EventArgs e)
        {
            clearBoxs();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string keyText = textBox4.Text.Trim();
            if(keyText != "")
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
    }
}
