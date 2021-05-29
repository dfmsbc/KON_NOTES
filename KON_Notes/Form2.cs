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
                panel1.Controls.Add(test);
                num++;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            Form5 obj = new Form5();
            obj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 obj = new Form6();
            obj.ShowDialog();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form2_Load(this, null);
        }
    }
}
