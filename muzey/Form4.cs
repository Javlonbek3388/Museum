using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzey
{
    public partial class Form4 : Form
    {
        public string oldPhotoName = "";
        public string oldPhotoPath = "";
        public string newPhotoName = "";
        public Form4()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label13.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ControlTumanlar controlTumanlar = new ControlTumanlar();

            DataTable dataTable = controlTumanlar.getDataTumanlar();
            foreach(DataRow row in dataTable.Rows)
            {
                comboBox2.Items.Add(row["Nomi"].ToString());    
            }

           // pictureBox1.Image = Image.FromFile("../..Resources/users/" + UserLogin.userPhoto);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            uploadDataToGridView();
        }
        public void uploadDataToGridView()
        {
            ControlFoydalanuvchilar controlFoydalanuvchilar= new ControlFoydalanuvchilar();
            dataGridView1.DataSource = controlFoydalanuvchilar.getDataFoydalanuvchilar();
            dataGridView1.Columns["id"].Width = 50;
            dataGridView1.Columns["picture"].Visible = false;
            dataGridView1.Columns["Logen"].Visible = false;
            dataGridView1.Columns["Parol"].Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
             string Ism = textBox2.Text.Trim();
            string Familiya = textBox3.Text.Trim();
            string Telefon = textBox4.Text.Trim();
            string Manzil = textBox5.Text.Trim();
            //   int TumanID = int.Parse(textBox6.Text.Trim());
            ControlTumanlar controlTumanlar = new ControlTumanlar();
            int  TumanID = controlTumanlar.getIDByName(comboBox2.SelectedItem.ToString());
            string P_seria = textBox7.Text.Trim();
            string P_raqam = textBox8.Text.Trim();        
            string Logen = textBox9.Text.Trim();
            string Parol = textBox10.Text.Trim();
            string Rol= comboBox1.SelectedItem.ToString();
            // string picture = "Rasm";
            uploadPhoto();
          //  MessageBox.Show(newPhotoName.ToString());
            if (Ism!=""&&Familiya!=""&&Telefon!=""&&Manzil!="" && TumanID != 0 && P_seria != "" && P_raqam != "" && Logen != "" && Parol != "" && Rol != "" && newPhotoName != "")
            {
                Foydalanuchilar foydalanuvchiObj = new Foydalanuchilar(Ism , Familiya , Telefon , Manzil,TumanID, P_seria, P_raqam, Logen, Parol,Rol,newPhotoName);
                ControlFoydalanuvchilar controlFoydalanuvchi = new ControlFoydalanuvchilar();
                if (controlFoydalanuvchi.InsertFoydalanuvchi(foydalanuvchiObj))
                {
                    MessageBox.Show("Ma'lumot kiritildi");
                    clearBoxs();
                }
                else
                {
                    MessageBox.Show("Ma'lumot kiritilmadi");
                }
            }
            else
            {
                MessageBox.Show("Barcha maydonlar to'ldirilishi zarur");
            } 
        }
        public void uploadPhoto()
        {
            if (oldPhotoPath != "")
            {
                newPhotoName = "user_"; 
                string photoType = oldPhotoName.Substring(oldPhotoName.LastIndexOf('.'));
                newPhotoName += (DateTime.Now.ToUniversalTime() - new DateTime(1997, 1, 1)).TotalSeconds.ToString();
                newPhotoName = newPhotoName.Remove(newPhotoName.IndexOf('.'), 1);
                newPhotoName += photoType;

                File.Copy(oldPhotoPath, @"..\..\Resources\users\"+newPhotoName);
            }
        }
        public void clearBoxs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            // textBox6.Text = "";
           // comboBox2.SelectedIndex = 0;
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox12.Text = "";
            comboBox1.SelectedIndex= 0; 
            // textBox11.Text = "";
            newPhotoName = "";
            oldPhotoName = "";
            oldPhotoPath = "";
            pictureBox2.Image = null;
            uploadDataToGridView();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (pictureBox2 != null)
            {
                openFileDialog.Filter = "(*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp;";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                { 
                    oldPhotoName = openFileDialog.SafeFileName;  
                    oldPhotoPath = openFileDialog.FileName;
                    pictureBox2.Image = Image.FromFile(oldPhotoPath);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int ID= int.Parse(textBox1.Text);
                string picture =pictureBox2.Tag.ToString();
                DialogResult dr = MessageBox.Show("Element o'chirilsinmi?","O'chirish", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ControlFoydalanuvchilar controlFoydalanuvchilar= new ControlFoydalanuvchilar();
                    if (controlFoydalanuvchilar.deleteData(ID))
                    {
                        MessageBox.Show("Element o'chirildi.");
                        try
                        {
                            if (File.Exists(@"..\..\Resources\users\" + picture))
                            {
                                File.Delete(@"..\..\Resources\users\" + picture);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        clearBoxs();
                    }
                    else
                    {
                        MessageBox.Show("Element o'chirilmadi.");
                    }
                }
               
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                textBox1.Text= dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Ism"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Familiya"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Telefon"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Manzil"].FormattedValue.ToString();
                // textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["TumanID"].FormattedValue.ToString();
                comboBox2.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Tuman"].FormattedValue.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["P_seria"].FormattedValue.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["P_raqam"].FormattedValue.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["Logen"].FormattedValue.ToString();
                textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells["Parol"].FormattedValue.ToString();
                  
                comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Rol"].FormattedValue.ToString();


                //pictureBox2.Image = Image.FromFile(@"..\..\Resources\users\" + dataGridView1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString());
                //if (UserLogin.Username != dataGridView1.Rows[e.RowIndex].Cells["Logen"].FormattedValue.ToString())
                //{
                //    pictureBox2.Image = pictureBox1.Image;
                //}
                //else
                //{
                    using (FileStream fs = new FileStream(@"..\..\Resources\users\" + dataGridView1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString(), FileMode.Open))
                    {
                        Image image = Image.FromStream(fs);
                        pictureBox2.Image = image;
                    }
               // }

                pictureBox2.Tag = dataGridView1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int  ID=int.Parse(textBox1.Text);
                string Ism=textBox2.Text;
                string Familiya = textBox3.Text; 
                string Telefon = textBox4.Text;
                string Manzil = textBox5.Text;  
                //  int TumanID = int.Parse(textBox6.Text);
               // string TumanID = comboBox2.SelectedItem.ToString();
                string P_seria = textBox7.Text;
                string P_raqam = textBox8.Text;
                string Logen = textBox9.Text;
                string Parol = textBox10.Text;
                string Rol = comboBox1.SelectedItem.ToString();

                string picture= pictureBox2.Tag.ToString();
                if (oldPhotoName != "")
                {
                    try
                    {
                        if(File.Exists(@"..\..\Resources\users\"+ picture))
                        {
                            File.Delete(@"..\..\Resources\users\" + picture);
                        }
                    }
                    catch(Exception ex) 
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    uploadPhoto();
                    picture = newPhotoName;
                }
              //  string Rol = comboBox1.SelectedItem.ToString();
              //  string Logen=textBox9.Text;
                ControlTumanlar controlTumanlar = new ControlTumanlar();
                int TumanID = controlTumanlar.getIDByName(comboBox2.SelectedItem.ToString());
              //  string Parol= textBox10.Text;

                ControlFoydalanuvchilar controlFoydalanuvchilar = new ControlFoydalanuvchilar();
                if (controlFoydalanuvchilar.updateFoydalanuvchi(new Foydalanuchilar(ID, Ism, Familiya, Telefon,Manzil,TumanID,P_seria,P_raqam,Logen,Parol,Rol,picture)))
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
            string keyText=textBox12.Text.Trim();
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

        private void button4_Click(object sender, EventArgs e)
        {
            clearBoxs();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }
    }
}
