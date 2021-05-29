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
            string sql = "select * from notes_table where finish=0";
            SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            int num = 0;
            int y = 3;
            while (rd.Read())
            {
                ICONbutton.UserControl1 test= new ICONbutton.UserControl1();
                test.Location = new Point(3, y + num * 60);
                test.Test = rd["case"].ToString();
                test.DDL = (DateTime)rd["ddl"];
                panel1.Controls.Add(test);
                num++;
            }


        }

       /* private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            dataGridView1.RowHeadersWidth - 4,
            e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  "任务"+(e.RowIndex + 1).ToString(),
                   dataGridView1.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }*/



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
    }
}
