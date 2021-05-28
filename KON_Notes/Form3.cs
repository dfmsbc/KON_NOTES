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
        public Form3()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
             
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ThisSQLiteConnection = new SQLiteConnection(@"DataSource=Application.StartupPath+'\\notes.db'");
            var Datatable = new DataTable();
            /*var adp = new SQLiteDataAdapter( "select * from Consume",ThisSQLiteConnection);
            adp.Fill(Datatable);
            dataGridView1.DataSource = Datatable;                                             */
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
