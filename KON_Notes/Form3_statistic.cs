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
    public partial class Form3_statistic : Form
    {
        public Form3_statistic()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Text = dateTimePicker1.Value.ToString("yyyy年 MM月dd日");
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = dateTimePicker1.Value.ToString("yyyy年 MM月dd日");
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            double total=0;
            panel1.Controls.Clear();
            var ThisSQLiteConnection = new SQLiteConnection(@"DataSource=../Debug/notes.db");
            ThisSQLiteConnection.Open();
            string sql = "select* FROM account_book where 消费日期 = @t";
            SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);
            command.Parameters.Add(new SQLiteParameter("@t", textBox1.Text));
            SQLiteDataReader rd = command.ExecuteReader();
            int num = 0, y =0;
            while (rd.Read())
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Location =new Point(14, num * 80 + 13);
                label.ForeColor = Color.Gainsboro;
                label.Font = new System.Drawing.Font("华文楷体", 18);
                label.Text = "支出项目:" + rd["收支项目"] + "   支出类别:" + rd["类别"] +
                    "    支出金额:" + rd["金额"].ToString()+"元";
                panel1.Controls.Add(label);
                total += double.Parse(rd["金额"].ToString());
                num++;
                y = num * 80 + 13;
            }
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new Point(14, y);
            label1.ForeColor = Color.Gainsboro;
            label1.Font = new System.Drawing.Font("华文楷体", 18);
            label1.Text = "该日总支出为"+total+"元";
            panel1.Controls.Add(label1);
        }
    }
}
