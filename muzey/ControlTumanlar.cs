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
    internal class ControlTumanlar:ConnectDb
    {
        public bool InsertTuman(Tumanlar tuman)
        {
            int e= 0;
            sqlText = "insert into Tuman values ('"+tuman.Nomi+"',"+tuman.ViloyatID+");";
            try
            {
             cmd= new SqlCommand(sqlText, conn);
             e=cmd.ExecuteNonQuery();
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
        public bool updateTuman(Tumanlar tuman)
        {

            int e = 0;
            sqlText = "UPDATE Tuman SET  Nomi='"+tuman.Nomi+"',ViloyatID="+tuman.ViloyatID+" WHERE ID="+tuman.ID+"";
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
            sqlText = "DELETE FROM Tuman WHERE ID="+ID;
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
        public DataTable getDataTumanlar()
        { 
            DataTable dt = new DataTable(); 
            sqlText = "SELECT Tuman.ID,Tuman.Nomi,viloyat.nomi AS viloyat FROM Tuman INNER JOIN viloyat ON Tuman.ViloyatID=viloyat.id;";
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
        public DataTable filtr(string keyTumannomi, string keyViloyatnomi)
        {
            DataTable dt = new DataTable();
            sqlText = "SELECT Tuman.ID,Tuman.Nomi,viloyat.nomi AS viloyat FROM Tuman INNER JOIN viloyat ON Tuman.ViloyatID=viloyat.id WHERE Tuman.Nomi LIKE '" + keyTumannomi + "' and viloyat.nomi LIKE '" + keyViloyatnomi + "'";
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
            sqlText = "SELECT Tuman.ID,Tuman.Nomi,viloyat.nomi AS viloyat FROM Tuman INNER JOIN viloyat ON Tuman.ViloyatID=viloyat.id WHERE Tuman.Nomi LIKE '%"+keyText+"%' OR viloyat.nomi LIKE '%"+keyText+"%'";
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
        public int getIDByName(string Name)
        {
            DataTable dt = getDataTumanlar();  
            int ID = 0; 
           // dt=getDataTumanlar();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Nomi"].ToString() == Name)
                {
                    ID = int.Parse(row["ID"].ToString());
                }
            }
            return ID;
        }
    }
    public class Tumanlar
    {
        public int ID;
        public string Nomi;
        public int ViloyatID;

        public Tumanlar(int ID, string Nomi, int ViloyatID)
        {
            this.ID = ID;
            this.Nomi = Nomi;
            this.ViloyatID = ViloyatID;
        }
        public Tumanlar( string Nomi, int ViloyatID)
        {
            this.Nomi = Nomi;
            this.ViloyatID = ViloyatID;
        }
    }
}
