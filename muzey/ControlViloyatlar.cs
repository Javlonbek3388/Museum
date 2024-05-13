using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzey
{
    internal class ControlViloyatlar:ConnectDb
    {
      //  public static  DataTable dt=new DataTable();
        public DataTable getDataViloyatlar()
        {
            DataTable dt = new DataTable();
            sqlText = "SELECT*FROM viloyat";
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
            DataTable dt = getDataViloyatlar();
            int ID = 0;
           // dt=getDataViloyatlar();
            foreach (DataRow row in dt.Rows)
            {
                if (row["nomi"].ToString() == name)
                {
                    ID = int.Parse(row["ID"].ToString());
                }
            }
            return ID;
        }
    }
    public class Viloyatlar
    {
        public int id;
        public string nomi;
       
        public Viloyatlar(int id, string nomi)
        {
            this.id = id;
            this.nomi = nomi;
           
        }
        public Viloyatlar(string nomi)
        {
            this.nomi = nomi;
           
        }
    }
}
