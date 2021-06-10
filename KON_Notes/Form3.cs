using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace KON_Notes
{
    public partial class Form3 : Form
    {
        public static Form3 frm3;
        public Form3()
        {
            InitializeComponent();
            frm3 = this;
        }





        private void Form1_Load(object sender, EventArgs e)
        {
            fresh();

        }
        public void fresh()
        {
            double total = 0;
            var ThisSQLiteConnection = new SQLiteConnection(@"DataSource=../Debug/notes.db");
            ThisSQLiteConnection.Open();
            string sql = "select * from account_book order by 流水号 desc ";  //写sql语句
            SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);   //创建指令
            SQLiteDataReader rd = command.ExecuteReader();
            int flag = 3;
            while (rd.Read() && flag>0)
            {
                if (flag == 3)
                    label2.Text = rd["消费日期"].ToString() + "支出了" + rd["金额"].ToString() + "元 用于" + rd["收支项目"];
                if(flag==2)
                    label3.Text = rd["消费日期"].ToString() + "支出了" + rd["金额"].ToString() + "元 用于" + rd["收支项目"];
                if (flag ==1)
                    label4.Text = rd["消费日期"].ToString() + "支出了" + rd["金额"].ToString() + "元 用于" + rd["收支项目"];
                flag--;
            }
            sql = "select * from account_book where 消费日期=@t";
            command = new SQLiteCommand(sql, ThisSQLiteConnection);
            command.Parameters.Add(new SQLiteParameter("@t", DateTime.Now.ToString("yyyy年 MM月dd日")));
            rd = command.ExecuteReader();
            while (rd.Read())
            {
                total +=double.Parse( rd["金额"].ToString());
            }
            label1.Text = "今日总支出: " + total + " 元";
        }
        private void OpenHomeform(Form childForm)
        {

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();

        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenHomeform(new Form3_add());

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            OpenHomeform(new Form3_statistic());
        }
    }
}
