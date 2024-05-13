using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace muzey
{
    internal class ControlFoydalanuvchilar:ConnectDb
    {
      //  public static DataTable dt = new DataTable();
        public bool InsertFoydalanuvchi(Foydalanuchilar foydalanuvchi)
        {
            int e = 0;
            sqlText = "INSERT INTO foydalanuvchi VALUES ('"+foydalanuvchi.Ism+"','"+foydalanuvchi.Familiya+"','"+foydalanuvchi.Telefon+"','"+foydalanuvchi.Manzil+"','"+foydalanuvchi.TumanID+"','"+foydalanuvchi.P_seria+"','"+foydalanuvchi.P_raqam+"','"+foydalanuvchi.Logen+"','"+foydalanuvchi.Parol+"','"+foydalanuvchi.Rol+"','"+foydalanuvchi.picture+"');";
            try
            {
                cmd = new SqlCommand(sqlText, conn);
                e= cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if(e == 1)
            {
                return true;
            }
            else
            {
                return false;
            
            }
           
        }
        public bool updateFoydalanuvchi(Foydalanuchilar foydalanuvchi)
        {
            int e = 0;
            sqlText =  "UPDATE foydalanuvchi SET Ism='" + foydalanuvchi.Ism + "',Familiya='" + foydalanuvchi.Familiya + "',Telefon='" + foydalanuvchi.Telefon + "',Manzil='" + foydalanuvchi.Manzil + "',TumanID='" + foydalanuvchi.TumanID+ "',P_seria='" + foydalanuvchi.P_seria + "',P_raqam='" + foydalanuvchi.P_raqam + "',Logen='" + foydalanuvchi.Logen + "',Parol='" + foydalanuvchi.Parol + "',Rol='" + foydalanuvchi.Rol + "',picture='" + foydalanuvchi.picture + "' WHERE ID="+foydalanuvchi.ID+"";
            try
            {
                cmd = new SqlCommand(sqlText, conn);        
                e = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else 
            {  
                return false;
            }
        }
        public bool deleteData(int ID)
        {
            int e = 0;
            sqlText = "DELETE FROM foydalanuvchi WHERE ID=" + ID;
            try
            {
                cmd = new SqlCommand(sqlText, conn);
                e = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable getDataFoydalanuvchilar()
        {
            DataTable dt = new DataTable();
            sqlText = "select foydalanuvchi.ID,foydalanuvchi.Ism,foydalanuvchi.Familiya,foydalanuvchi.Telefon,foydalanuvchi.Manzil,Tuman.Nomi AS Tuman,foydalanuvchi.P_seria,foydalanuvchi.P_raqam,foydalanuvchi.Logen,foydalanuvchi.Parol,foydalanuvchi.Rol,foydalanuvchi.picture from foydalanuvchi inner join Tuman on foydalanuvchi.TumanID=Tuman.ID; ";
            try
            {
                adapter= new SqlDataAdapter(sqlText, conn);
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                 MessageBox.Show(ex.ToString());    
            }
            return dt;
        }
        public DataTable searchData(string keyText)
        {
            DataTable dt = new DataTable();
            sqlText = "select foydalanuvchi.ID,foydalanuvchi.Ism,foydalanuvchi.Familiya,foydalanuvchi.Telefon,foydalanuvchi.Manzil,Tuman.Nomi AS Tuman,foydalanuvchi.P_seria,foydalanuvchi.P_raqam,foydalanuvchi.Logen,foydalanuvchi.Parol,foydalanuvchi.Rol,foydalanuvchi.picture from foydalanuvchi inner join Tuman on foydalanuvchi.TumanID=Tuman.ID where foydalanuvchi.Ism like '%"+ keyText + "%'or foydalanuvchi.Familiya like '%"+ keyText + "%'or foydalanuvchi.Telefon like '%"+ keyText + "%'or foydalanuvchi.Manzil like '%"+ keyText + "%'or Tuman.Nomi like '%"+ keyText + "%'or foydalanuvchi.P_seria like '%"+ keyText + "%'or foydalanuvchi.P_raqam like '%"+ keyText + "%'or foydalanuvchi.Logen like '%"+ keyText + "%'or foydalanuvchi.Parol like '%"+keyText+"%'or foydalanuvchi.Rol like '%"+ keyText + "%'or foydalanuvchi.picture like '%"+ keyText + "%'; ";
            try
            {
                adapter = new SqlDataAdapter(sqlText, conn);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
        public DataTable filtr(string keyIsm, string keyFamiliya)
        {
            DataTable dt = new DataTable();
            sqlText = "select foydalanuvchi.ID,foydalanuvchi.Ism,foydalanuvchi.Familiya,foydalanuvchi.Telefon,foydalanuvchi.Manzil,Tuman.Nomi AS Tuman,foydalanuvchi.P_seria,foydalanuvchi.P_raqam,foydalanuvchi.Logen,foydalanuvchi.Parol,foydalanuvchi.Rol,foydalanuvchi.picture from foydalanuvchi inner join Tuman on foydalanuvchi.TumanID=Tuman.ID where foydalanuvchi.Ism like '%"+keyIsm+"%' and foydalanuvchi.Familiya like '%"+keyFamiliya+"%'";
            try
            {
              //  cmd.Parameters.AddWithValue("@keyText", "%" + keyText + "%");
                adapter = new SqlDataAdapter(sqlText, conn);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
        public int getIdByName(string name)
        {
            DataTable dt = getDataFoydalanuvchilar();
            int id = 0;
           // dt = getDataFoydalanuvchilar();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Ism"].ToString() == name)
                {
                    id = int.Parse(row["id"].ToString());
                }
            }
            return id;
        }
    }
    public class Foydalanuchilar
    {
        public int ID;
        public string Ism;
        public string Familiya;
        public string Telefon;
        public string Manzil;
        public int TumanID;
        public string P_seria;
        public string P_raqam;
        public string Logen;
        public string Parol;
        public string Rol;
        public string picture;
        public Foydalanuchilar (int ID, string Ism, string Familiya, string Telefon, string Manzil,int TumanID, string P_seria,string P_raqam, string Logen, string Parol, string Rol, string picture)
        {
            this.ID = ID;
            this.Ism = Ism; 
            this.Familiya = Familiya;
            this.Telefon = Telefon;
            this.Manzil = Manzil;
            this.TumanID = TumanID;
            this.P_seria = P_seria;
            this.P_raqam = P_raqam;
            this.Logen = Logen;
            this.Parol = Parol;
            this.Rol = Rol;
            this.picture = picture; 
        }
        public Foydalanuchilar( string Ism, string Familiya, string Telefon, string Manzil,int TumanID, string P_seria, string P_raqam, string Logen, string Parol, string Rol, string picture)
        {
           
            this.Ism = Ism;
            this.Familiya = Familiya;
            this.Telefon = Telefon;
            this.Manzil = Manzil;
            this.TumanID = TumanID;
            this.P_seria = P_seria;
            this.P_raqam = P_raqam;
            this.Logen = Logen;
            this.Parol = Parol;
            this.Rol = Rol;
            this.picture = picture;
        }
    }
}
