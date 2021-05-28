using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
namespace KON_Notes
{
    class jishiben
    {
        
        /*string MySqlCon = string.Format("data source = {0};pooling=false",Application.StartupPath+"\\notes.db"); 
        public DataTable ExecuteQuery(string sqlStr) //用于查询；其实是相当于提供一个可以传参的函数，到时候写一个sql语句，存在string里，传给这个函数，就会自动执行。
        {
            SQLiteConnection con = new SQLiteConnection(@MySqlCon);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            DataTable dt = new DataTable();
            SQLiteDataAdapter msda = new SQLiteDataAdapter(cmd);
            
                //调用dataAdapter的Fill方法填充dataTable
                msda.Fill(dt);
           
            return dt;
        }

        public int ExecuteUpdate(string sqlStr) //用于增删改;
        {
            SQLiteConnection con = new SQLiteConnection(@MySqlCon);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            int iud = 0;
            iud = cmd.ExecuteNonQuery();
            con.Close();
            return iud;
        }*/
    }
}
