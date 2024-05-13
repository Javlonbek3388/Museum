using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzey
{
    internal class UserLogin : ConnectDb
    {
       // private string sqlText;// qo'shildi hghfgfgcvbnvcn
        public static string Username = string.Empty;
        public static string Password = string.Empty;
        public static string userPhoto = string.Empty;
        public static bool isLogin = false;

        public UserLogin(string userN, string userP) 
        {
            userN.Trim();
            userP.Trim();
            if(!isLogin)
            {
                sqlText="SELECT*FROM foydalanuvchi WHERE Logen='"+userN+"'AND Parol='"+userP+"'";
                try
                {
                    cmd = new SqlCommand(sqlText, conn);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Username = userN;
                        Password = userP;
                        isLogin = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }    
            }
        
        }


    }
}
