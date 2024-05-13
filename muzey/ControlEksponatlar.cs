using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace muzey
{
    internal class ControlEksponatlar:ConnectDb
    {
       // public static DataTable dt = new DataTable();
        public bool InsertEksponatlar(Eksponatlar eksponat)
        {
            int e = 0;
            sqlText = "INSERT INTO eksponatlar VALUES ('" + eksponat.nomi + "','" + eksponat.kelgan_sanasi + "','" + eksponat.bulim_id + "','" + eksponat.davri+ "','" + eksponat.picture+"');";
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
        public bool updateEksponat(Eksponatlar eksponat)
        {
            int e = 0;
            sqlText = "UPDATE eksponatlar SET nomi='" + eksponat.nomi + "',kelgan_sanasi='" + eksponat.kelgan_sanasi + "',bulim_id='" + eksponat.bulim_id + "',davri='" + eksponat.davri + "',picture='" + eksponat.picture + "' WHERE ID=" + eksponat.id + "";
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
            sqlText = "DELETE FROM eksponatlar WHERE id=" + id;
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
        public DataTable getDataEksponatlar()
        {
            DataTable dt = new DataTable();
            sqlText = " select  eksponatlar.id,eksponatlar.nomi,eksponatlar.kelgan_sanasi,bulim.nomi as bulimi,eksponatlar.davri,eksponatlar.picture from eksponatlar inner join bulim on eksponatlar.bulim_id=bulim.id;";
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
        public DataTable searchDatafull(string keyText)
        {
            DataTable dt = new DataTable();
            sqlText = "select eksponatlar.nomi, eksponatlar.kelgan_sanasi, eksponatlar.davri,bulim.nomi as bulim_nomi,bulim.kirish_vaqti,bulim.chiqish_vaqti,foydalanuvchi.Ism,foydalanuvchi.Familiya, foydalanuvchi.Telefon,foydalanuvchi.Manzil,foydalanuvchi.P_seria,foydalanuvchi.P_raqam,foydalanuvchi.Rol,Tuman.Nomi as tuman_nomi,viloyat.nomi as viloyat_nomi from(((eksponatlar inner join bulim on eksponatlar.bulim_id=bulim.id) inner join foydalanuvchi on bulim.ishchi_id=foydalanuvchi.ID) inner join Tuman on foydalanuvchi.TumanID=Tuman.ID) inner join viloyat on Tuman.ViloyatID=viloyat.id where eksponatlar.nomi like '%" + keyText + "%' or   eksponatlar.kelgan_sanasi like '%" + keyText + "%' or eksponatlar.davri like '%" + keyText + "%' or bulim.nomi like '%" + keyText + "%'or bulim.narxi like '%" + keyText + "%' or bulim.kirish_vaqti like '%" + keyText + "%' or bulim.chiqish_vaqti like '%" + keyText + "%' or foydalanuvchi.Ism like '%" + keyText + "%' or foydalanuvchi.Familiya like '%" + keyText + "%' or foydalanuvchi.Telefon like '%" + keyText + "%' or foydalanuvchi.Manzil like '%" + keyText + "%' or foydalanuvchi.P_seria like '%" + keyText + "%' or foydalanuvchi.P_raqam like '%" + keyText + "%' or foydalanuvchi.Rol like '%" + keyText + "%' or Tuman.Nomi like '%" + keyText + "%' or viloyat.nomi like '%" + keyText + "%'";
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

        public DataTable filtrfull(string knom, string ksana,string kdavr, string kbnomi, string knarx1,string knarx2,string kkvaqt,string kchvaqt,string kism,string kfam,string ktel,string kmanzil, string kseria, string kraqam,string krol, string ktumnomi,string kvilnomi)
        {
            DataTable dt = new DataTable();
            sqlText = "select eksponatlar.nomi, eksponatlar.kelgan_sanasi, eksponatlar.davri,bulim.nomi as bulim_nomi,bulim.narxi,bulim.kirish_vaqti,bulim.chiqish_vaqti,foydalanuvchi.Ism,foydalanuvchi.Familiya, foydalanuvchi.Telefon,foydalanuvchi.Manzil,foydalanuvchi.P_seria,foydalanuvchi.P_raqam,foydalanuvchi.Rol,Tuman.Nomi as tuman_nomi,viloyat.nomi as viloyat_nomi from(((eksponatlar inner join bulim on eksponatlar.bulim_id=bulim.id) inner join foydalanuvchi on bulim.ishchi_id=foydalanuvchi.ID) inner join Tuman on foydalanuvchi.TumanID=Tuman.ID) inner join viloyat on Tuman.ViloyatID=viloyat.id where eksponatlar.nomi like '%"+knom+"%' and eksponatlar.kelgan_sanasi like '%"+ksana+"%' and eksponatlar.davri like '%"+kdavr+"%' and bulim.nomi like '%"+kbnomi+"%' and bulim.narxi between '"+knarx1+"'and '"+knarx+"' and bulim.kirish_vaqti like '%"+kkvaqt+"%' and bulim.chiqish_vaqti like '%"+kchvaqt+"%' and foydalanuvchi.Ism like '%"+kism+"%' and foydalanuvchi.Familiya like '%"+kfam+"%' and foydalanuvchi.Telefon like '%"+ktel+"%' and foydalanuvchi.Manzil like '%"+kmanzil+"%' and foydalanuvchi.P_seria like '%"+kseria+"%' and foydalanuvchi.P_raqam like '%"+kraqam+"%' and foydalanuvchi.Rol like '%"+krol+"%' and Tuman.Nomi like '%"+ktumnomi+"%' and viloyat.nomi like '%"+kvilnomi+"%';";
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
        public DataTable getDataEksponatlarsurov()
        {
            DataTable dt = new DataTable();
            sqlText = " select eksponatlar.nomi, eksponatlar.kelgan_sanasi, eksponatlar.davri,bulim.nomi as bulim_nomi,bulim.narxi,bulim.kirish_vaqti,bulim.chiqish_vaqti,foydalanuvchi.Ism,foydalanuvchi.Familiya, foydalanuvchi.Telefon,foydalanuvchi.Manzil,foydalanuvchi.P_seria,foydalanuvchi.P_raqam,foydalanuvchi.Rol,Tuman.Nomi as tuman_nomi,viloyat.nomi as viloyat_nomi from(((eksponatlar inner join bulim on eksponatlar.bulim_id=bulim.id) inner join foydalanuvchi on bulim.ishchi_id=foydalanuvchi.ID) inner join Tuman on foydalanuvchi.TumanID=Tuman.ID) inner join viloyat on Tuman.ViloyatID=viloyat.id;";
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

        public DataTable filtr(string keyBulim,string keySana)
        {
            DataTable dt = new DataTable();
            sqlText = "select eksponatlar.id, eksponatlar.nomi,eksponatlar.kelgan_sanasi,bulim.nomi as bulimi,eksponatlar.davri,eksponatlar.picture from eksponatlar inner join bulim on eksponatlar.bulim_id=bulim.id where bulim.nomi like '%"+keyBulim+ "%' and eksponatlar.kelgan_sanasi like '%"+keySana+"%';";
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
            sqlText = "select eksponatlar.id, eksponatlar.nomi,eksponatlar.kelgan_sanasi,bulim.nomi as bulimi,eksponatlar.davri,eksponatlar.picture from eksponatlar inner join bulim on eksponatlar.bulim_id=bulim.id where eksponatlar.nomi  like '%"+ keyText + "%'or eksponatlar.kelgan_sanasi  like '%"+ keyText + "%'or bulim.nomi  like '%"+ keyText + "%'or eksponatlar.davri  like '%"+ keyText + "%'or eksponatlar.picture  like '%"+ keyText + "%';";
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
    public class Eksponatlar
    {
        public int id;
        public string nomi;
        public string kelgan_sanasi;
        public int bulim_id;
        public string davri;
        public string picture;
        public Eksponatlar(int id, string nomi,string kelgan_sanasi, int bulim_id, string davri, string picture)
        {
            this.id = id;
            this.nomi = nomi;
            this.kelgan_sanasi=kelgan_sanasi;
            this.bulim_id = bulim_id;
            this.davri = davri;
            this.picture = picture;
        }
        public Eksponatlar( string nomi, string kelgan_sanasi, int bulim_id, string davri, string picture)
        {
            this.nomi = nomi;
            this.kelgan_sanasi = kelgan_sanasi;
            this.bulim_id = bulim_id;
            this.davri = davri;
            this.picture = picture;
        }

    }
}
