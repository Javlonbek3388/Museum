using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace muzey

{
    internal class ConnectDb
    {
       // private string connectionString;
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;
        protected SqlDataAdapter adapter;
        protected string sqlText;
        public ConnectDb()
        {
            string connectionString = "Server=WIN-FAFVTNM7K68\\SQLEXPRESS;Database=muzey;Trusted_Connection=True;";
            try
            {
                this.conn = new SqlConnection(connectionString);
                this.conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
//        public List<Students> getData(int id = 0)
//        {
//            List<Students>  dataList = new List<Students>();
//            if(id == 0)
//            {
//                sqlString = "SELECT * FROM students";
//            }

//            else
//            {
//                sqlString = "SELECT * FROM students WHERE id=" + id;
//            }

//            cmd = new SqlCommand(sqlString, conn);
//            reader = cmd.ExecuteReader();
//            while (reader.Read())
//            {
//                dataList.Add(new Students(
//                    reader.GetInt32(0),
//                    reader.GetString(1),
//                    reader.GetString(2),
//                    reader.GetInt32(3)
//                    ));
//            }
//            return dataList;
//        }
//        public List<Students> getDataWithLike(string key)
//        {
//            List<Students> dataList = new List<Students>();
//            sqlString = "SELECT * FROM students WHERE firstname LIKE '%" + key + "%' OR lastname LIKE '%" + key + "%'";

//            if (int.TryParse(key, out int k))
//            {
//                sqlString += " OR CAST(age AS VARCHAR(50)) LIKE '%" + key + "%'";
//            }

//            cmd = new SqlCommand(sqlString, conn);
//            reader = cmd.ExecuteReader();
//            while (reader.Read())
//            {
//                dataList.Add(new Students(
//                    reader.GetInt32(0),
//                    reader.GetString(1),
//                    reader.GetString(2),
//                    reader.GetInt32(3)
//                    ));
//            }
//            return dataList;
//        }
//        public Boolean insertData(Students student)
//        {
//            sqlString = "INSERT INTO students VALUES('" + student.firstname + "', '" + student.lastname + "', " + student.age + ")";
//            cmd = new SqlCommand(sqlString, conn);
//            int e = cmd.ExecuteNonQuery();
//            if (e == 1)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        public Boolean updateData(Students students)
//        {
//            sqlString = "UPDATE students SET firstname='" + students.firstname + "', lastname='" + students.lastname + "', age=" + students.age + " WHERE id=" + students.id + "";
//            cmd = new SqlCommand(sqlString, conn);
//            int e = cmd.ExecuteNonQuery();
//            if (e == 1)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        public Boolean deleteData(int id)
//        {
//            sqlString = "DELETE students WHERE id=" + id + "";
//            cmd = new SqlCommand(sqlString, conn);
//            int e = cmd.ExecuteNonQuery();
//            if (e == 1)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        ~ConnectDb()
//        {
//            this.conn = null;
//        }
//    }
//    internal class Students
//    {
//        public int id;
//        public string firstname;
//        public string lastname;
//        public int age;
//        public Students(int id, string firstname, string lastname, int age)
//        {
//            this.id = id;
//            this.firstname = firstname;
//            this.lastname = lastname;
//            this.age = age;
//        }
//        public Students(string firstname, string lastname, int age)
//        {
//            this.firstname = firstname;
//            this.lastname = lastname;
//            this.age = age;
//        }
//    }
//}

