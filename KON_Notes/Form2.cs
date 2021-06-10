using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SQLite;




namespace KON_Notes
{
    public partial class Form2 : Form
    {
        int index=1;              //历史任务与任务列表的切换关键字，=1时为列表页面，=0时为历史任务页面
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            var ThisSQLiteConnection = new SQLiteConnection(@"DataSource=../Debug/notes.db");
            ThisSQLiteConnection.Open();
            string sql = "select* FROM notes_table where finish=0 ORDER BY importance DESC , ddl ASC;";
            SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            int num = 0;
            int y = 3;
            while (rd.Read())
            {
                ICONbutton.UserControl1 test= new ICONbutton.UserControl1();
                test.Location = new Point(3, y + num * 60);
                test.Test = rd["test"].ToString();
                test.DDL = (DateTime)rd["ddl"];
                test.Complished = Convert.ToInt32(rd["finish"]);
                test.Importance =Convert.ToInt32(rd["importance"]);
                if (test.DDL <= DateTime.Now)
                {
                    
                }
                panel1.Controls.Add(test);
                num++;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }


        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form2_Load(this, null);
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            if (index == 1)
            {
                iconButton1.Text = "返回任务列表";
                iconButton1.IconChar = FontAwesome.Sharp.IconChar.ListAlt;
                var ThisSQLiteConnection = new SQLiteConnection(@"DataSource=../Debug/notes.db");
                ThisSQLiteConnection.Open();
                string sql = "select* FROM notes_table where finish=1 ORDER BY  ddl DESC;";
                SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);
                SQLiteDataReader rd = command.ExecuteReader();
                int num = 0;
                int y = 3;
                while (rd.Read())
                {
                    ICONbutton.UserControl1 test = new ICONbutton.UserControl1();
                    test.Location = new Point(3, y + num * 60);
                    test.Test = rd["test"].ToString();
                    test.DDL = (DateTime)rd["ddl"];
                    test.Complished = Convert.ToInt32(rd["finish"]);
                    test.Importance = Convert.ToInt32(rd["importance"]);
                    panel1.Controls.Add(test);
                    num++;
                }
                index = 0;
            }
            else if (index == 0)
            {
                Form2_Load(this, null);
                index = 1;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form5 obj = new Form5();
            obj.ShowDialog();
        }
    }
}
