using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace ICONbutton
{
    public partial class UserControl1: UserControl
    {
        public static DateTime time;
        public UserControl1()
        {
            InitializeComponent();
        }


        SQLiteConnection ThisSQLiteConnection = new SQLiteConnection(@"DataSource=../Debug/notes.db");
        //自定义控件属性
        [Browsable(true)]
        [Description("该任务的重要性，int型"), Category("自定义属性")]
        public int Importance { get; set; }
        [Description("该任务截止时间，datetime型"), Category("自定义属性")]
        public DateTime DDL { get; set; }
        [Description("该任务的是否完成，int型"), Category("自定义属性"), DefaultValue(0)]
        public int Complished { get; set; }
        [Description("任务名，string型"), Category("自定义属性")]
        public string Test { get; set; }



        private void UserControl1_Load(object sender, EventArgs e)
        {
            label1.Text = Test;
            label2.Text = DDL.ToString("MM月dd日HH:mm");
            if (Importance == 0)
            {
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.StarHalf;
            }
            else
            {
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Star;
            }
            if (DDL <= DateTime.Now)
            {
                label1.ForeColor = Color.Red;
                label2.ForeColor = Color.Red;
            }

        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            ThisSQLiteConnection.Open();                                            //打开链接
            string sql = "DELETE FROM notes_table WHERE test = @tt";                //写sql语句
            SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);   //创建指令
            command.Parameters.Add(new SQLiteParameter("@tt", label1.Text));        //替换关键词
            command.ExecuteNonQuery();                                              //执行指令


            Complished = 1;
            this.Visible = false;

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            
            if (Importance == 1)
            {
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.StarHalf;
                Importance = 0;
            }
            else if(Importance==0)
            {
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Star;
                Importance = 1;
            }
            string sql = "UPDATE notes_table SET importance = @imp WHERE test = @tt";
            SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);
            command.Parameters.Add(new SQLiteParameter("@tt", label1.Text));
            command.Parameters.Add(new SQLiteParameter("@imp", Importance));
            ThisSQLiteConnection.Open();
            command.ExecuteNonQuery();
            ThisSQLiteConnection.Close();
            
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            
            ThisSQLiteConnection.Open();
            if (Complished == 0)
            {
                string sql = "UPDATE notes_table SET finish = 1 WHERE test = @tt";
                SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);
                command.Parameters.Add(new SQLiteParameter("@tt", label1.Text));
                command.ExecuteNonQuery();
                Complished = 1;
            }
            else
            {
                string sql = "UPDATE notes_table SET finish = 0 WHERE test = @tt";
                SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);
                command.Parameters.Add(new SQLiteParameter("@tt", label1.Text));
                command.ExecuteNonQuery();
                Complished = 0;

            }
            this.Visible = false;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Form1 fom = new Form1();
            fom.ShowDialog();
            label2.Text = time.ToString("MM月dd日HH:mm");
            ThisSQLiteConnection.Open();
            string sql = "UPDATE notes_table SET ddl = @time WHERE test = @tt";
            SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);
            command.Parameters.Add(new SQLiteParameter("@time", time));
            command.Parameters.Add(new SQLiteParameter("@tt", label1.Text));
            command.ExecuteNonQuery();
            ThisSQLiteConnection.Close();
        }
    }
}
