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
    public partial class Form3_add : Form
    {
        public Form3_add()
        {
            InitializeComponent();
            comboBox1.Items.Add("食品饮料");
            comboBox1.Items.Add("服装");
            comboBox1.Items.Add("居住");
            comboBox1.Items.Add("生活用品");
            comboBox1.Items.Add("交通");
            comboBox1.Items.Add("话费网费");
            comboBox1.Items.Add("学习");
            comboBox1.Items.Add("休闲娱乐");
            comboBox1.Items.Add("医疗保健");
            comboBox1.Items.Add("其它");
            comboBox1.SelectedIndex = 0;
        }



        private void Form3_add_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Text = dateTimePicker1.Value.ToString("yyyy年 MM月dd日");
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            int index_number=0;
            if (textBox2.Text == "元"||textBox2.Text=="")
            {
                MessageBox.Show("请输入金额！");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("请输入支出项目！");
            }
            else {
                var ThisSQLiteConnection = new SQLiteConnection(@"DataSource=../Debug/notes.db");
                ThisSQLiteConnection.Open();
                string sql = "select * from account_book order by 流水号 desc ";  //写sql语句
                SQLiteCommand command = new SQLiteCommand(sql, ThisSQLiteConnection);   //创建指令
                SQLiteDataReader rd = command.ExecuteReader();
                bool flag = true;
                while (rd.Read() && flag)
                {
                    index_number =(int) rd["流水号"];
                    flag = false;
                }
                sql = string.Format("insert into account_book values('{0}','{1}','{2}','{3}','{4}','{5}')",index_number+1,textBox1.Text, comboBox1.Text, 
                    textBox3.Text, textBox2.Text, textBox4.Text);
                command = new SQLiteCommand(sql, ThisSQLiteConnection);
                command.ExecuteNonQuery();
                Form3.frm3.fresh();
                this.Close();
            }
                
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = dateTimePicker1.Value.ToString("yyyy年 MM月dd日");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            switch (index)
            {
                case 0:
                    iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Hamburger;
                    break;
                case 1:
                    iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.BlackTie;
                    break;
                case 2:
                    iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.HouseUser;
                    break;
                case 3:
                    iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
                    break;
                case 4:
                    iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Car;
                    break;
                case 5:
                    iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.PhoneVolume;
                    break;
                case 6:
                    iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.PencilRuler;
                    break;
                case 7:
                    iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Gamepad;
                    break;
                case 8:
                    iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Wheelchair;
                    break;
                case 9:
                    iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Spinner;
                    break;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
