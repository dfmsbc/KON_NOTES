using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;


namespace KON_Notes
{
    public partial class Form5 : Form
    {
        DateTime remindtime;
        public Form5()
        {
            InitializeComponent();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            remindtime = DateTime.Now;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            remindtime = dateTimePicker1.Value.AddDays(-1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            remindtime = dateTimePicker1.Value.AddHours(-6);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            remindtime = dateTimePicker1.Value.AddHours(-1);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var ThisSQLiteConnection = new SQLiteConnection(@"DataSource=../Debug/notes.db");
            ThisSQLiteConnection.Open();
            string sql = "insert into notes_table (test,ddl,remindtime) values (@t1,@t2,@t3)";
            SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);
            command.Parameters.Add(new SQLiteParameter("@t1", textBox1.Text));
            command.Parameters.Add(new SQLiteParameter("@t2", dateTimePicker1.Value));
            command.Parameters.Add(new SQLiteParameter("@t3", remindtime));
            command.ExecuteNonQuery();
            this.Close();
        }
    }
}
