using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Xml.Linq;

namespace muzey
{
    internal class ControlBulimlar:ConnectDb
    {
      //  public static DataTable dt = new DataTable();
        public bool InsertBulim(Bulimlar bulim)
        {
            int e = 0;
            sqlText = "insert into bulim values('"+bulim.nomi+"',"+bulim.narxi+",'"+bulim.kirish_vaqti+"','"+bulim.chiqish_vaqti+"',"+bulim.ishchi_id+");";
            try
            {
                cmd = new SqlCommand(sqlText, conn);
                e = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if(e==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool updateBulim(Bulimlar bulim)
        {
            int e = 0;
            sqlText = "update bulim set nomi='"+bulim.nomi+"',narxi='"+bulim.narxi+"',kirish_vaqti='"+bulim.kirish_vaqti+"',chiqish_vaqti='"+bulim.chiqish_vaqti+"',ishchi_id='"+bulim.ishchi_id+"' where id='"+bulim.id+"'";
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
        public bool deleteData(int id)
        {
            int e = 0;
            sqlText = "delete from bulim where id="+id;
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
        public DataTable getDataBulimlar()
        {
            DataTable dt = new DataTable();
            sqlText = "SELECT bulim.id, bulim.nomi, bulim.narxi, bulim.kirish_vaqti, bulim.chiqish_vaqti,foydalanuvchi.Ism AS xodim FROM bulim INNER JOIN foydalanuvchi ON bulim.ishchi_id=foydalanuvchi.ID;";
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

        public int getIdByName(string name)
        {
            DataTable dt = getDataBulimlar();
            int id = 0;
           // dt = getDataBulimlar();
            foreach (DataRow row in dt.Rows)
            {
                if (row["nomi"].ToString() == name)
                {
                    id = int.Parse(row["id"].ToString());
                }
            }
            return id;
        }
        public DataTable filtr(string keyBulimnomi,int keyNarxi,string keyIshchinomi)
        {

            DataTable dt = new DataTable();
            sqlText = "SELECT bulim.id, bulim.nomi, bulim.narxi, bulim.kirish_vaqti, bulim.chiqish_vaqti,foydalanuvchi.Ism AS xodim FROM bulim INNER JOIN foydalanuvchi ON bulim.ishchi_id=foydalanuvchi.ID where bulim.nomi like '%"+keyBulimnomi+"%' and bulim.narxi <= '"+keyNarxi+"' and foydalanuvchi.Ism like '%"+keyIshchinomi+"%'; ";
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
        public DataTable searchData(string keyText)
        {
            DataTable dt = new DataTable();
            sqlText = "SELECT bulim.id, bulim.nomi, bulim.narxi, bulim.kirish_vaqti, bulim.chiqish_vaqti,foydalanuvchi.Ism AS xodim FROM bulim INNER JOIN foydalanuvchi ON bulim.ishchi_id=foydalanuvchi.ID where bulim.nomi like '%"+keyText+"%' or bulim.kirish_vaqti like '%"+keyText+"%' or bulim.chiqish_vaqti like '%"+keyText+"%' or foydalanuvchi.Ism like '%"+keyText+"%'; ";
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
    }
    public class Bulimlar
    {
        public int id;
        public string nomi;
        public int narxi;
        public string kirish_vaqti;
        public string chiqish_vaqti;
        public int ishchi_id;
        public Bulimlar(int id, string nomi, int narxi, string kirish_vaqti, string chiqish_vaqti, int ishchi_id)
        {
            this.id = id;
            this.nomi = nomi;
            this.narxi = narxi;
            this.kirish_vaqti = kirish_vaqti;
            this.chiqish_vaqti = chiqish_vaqti;
            this.ishchi_id = ishchi_id;
        }
        public Bulimlar( string nomi, int narxi, string kirish_vaqti, string chiqish_vaqti, int ishchi_id)
        {
            this.nomi = nomi;
            this.narxi = narxi;
            this.kirish_vaqti = kirish_vaqti;
            this.chiqish_vaqti = chiqish_vaqti;
            this.ishchi_id = ishchi_id;
        }
    }
}
