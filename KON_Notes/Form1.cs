using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace KON_Notes
{
    public partial class Form1 : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 80);
            panelMenu.Controls.Add(leftBorderBtn);
            timer1.Start();
        }
        //靠近桌面隐藏
        int SH;
        int SW;
        int self_SH;
        int self_SW;
        int star_win_flag = 1;//窗口初始化位置标志位,防止隐藏窗口后定时器重新跑窗口函数再次在初始化位置打开
        private void Form1_Load(object sender, EventArgs e)
        {
            //获取显示器屏幕的大小,不包括任务栏、停靠窗口
            SH = Screen.PrimaryScreen.WorkingArea.Height;
            SW = Screen.PrimaryScreen.WorkingArea.Width;
            //获取当前活动窗口高度跟宽度
            self_SH = this.Size.Height;
            self_SW = this.Size.Width;
            if (star_win_flag == 1)
            {
                //设置窗口打开的位置为下方居中
                SetDesktopLocation((SW - self_SW) / 2, (SH - self_SH)/2);
                star_win_flag = 0;
            }
            //============添加窗体所在位置定时检测=================
            TopMost = true; //把窗体设置为最顶层
            System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
            MyTimer.Tick += new EventHandler(StopRectTimer_Tick);
            MyTimer.Interval = 100;
            MyTimer.Enabled = true;
        }
        private struct RGBcolors
        {
            public static Color color1=Color.FromArgb(172,126,241);
            public static Color color2=Color.FromArgb(249,118,176);
            public static Color color3=Color.FromArgb(253,138,114);
        }
        private void ActivateButton(object senderBtn,Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //iconBacktoHome
                iconBacktoHome.IconChar = currentBtn.IconChar;
                iconBacktoHome.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft ;
            }
        }
        private void OpenHomeform(Form childForm )
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesk.Controls.Add(childForm);
            panelDesk.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            BacktoHomeTitle.Text = childForm.Text;
            
        }

        private void ButtonList_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            OpenHomeform(new Form2());
        }

        private void ButtonDollar_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color2);
            OpenHomeform(new Form3());
        }

        private void ButtonMusic_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color3);
            OpenHomeform(new Form4());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconBacktoHome.IconChar = IconChar.Home;
            iconBacktoHome.IconColor = Color.MediumPurple;
            BacktoHomeTitle.Text = "Home";
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
 
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            
        }
        int check_flag = 1; //窗体隐藏标志位，0为不开启隐藏功能，初始默认1
        int win = 0;
        int frmX;
        int frmY;
        private void StopRectTimer_Tick(object sender, EventArgs e)
        {
            // 获取窗体位置
            frmX = this.Location.X;
            frmY = this.Location.Y;

            if (check_flag == 1)
            {
                //获取窗口的边沿与桌面的间距，判断窗口是否靠近边沿里面-1个位置
                if (this.Left <= 0) //获取控件左边沿与桌面左边沿的间距，窗口靠近左边桌面边沿         
                    win = 1;
                else if (this.Top <= 0 && this.Left > 0 && this.Right < SW - 1)////获取控件上边沿与桌面上边沿的间距，窗口靠近顶端桌面边沿 
                    win = 2;
                else if (this.Right >= SW) ////获取控件右边沿与桌面左边沿的间距，窗口靠近右边桌面边沿  
                    win = 3;
                else //窗体没有靠近边沿
                    win = 0;

                /* Cursor.Position获取当前鼠标的位置
                 * Bounds.Contains(Cursor.Position)获取鼠标位置是否在窗口边界里面，在返回ture
                 *如果鼠标在窗体上，则根据停靠位置显示整个窗体
                 *窗体边沿计算是以左边沿为主*/

                if (Bounds.Contains(Cursor.Position))
                {
                    switch (win)
                    {
                        case 1:
                            this.Opacity = 1.0f;    //窗口恢复不透明状态
                                                    //窗体靠近左沿时，鼠标在窗体显示完整窗体 
                            SetDesktopLocation(0, frmY);
                            break;
                        case 2:
                            this.Opacity = 1.0f;    //窗口恢复不透明状态
                                                    //窗体靠近顶部时，鼠标在窗体显示完整窗体  
                            SetDesktopLocation(frmX, 0);
                            break;
                        case 3:
                            this.Opacity = 1.0f;    //窗口恢复不透明状态
                                                    //窗体靠近右沿时，鼠标在窗体显示完整窗体 
                            SetDesktopLocation(SW - self_SW, frmY);
                            break;
                    }
                }

                //如果鼠标离开窗体，则根据停靠位置隐藏窗体（即把窗体显示出桌面以外），但须留出部分窗体边缘以便鼠标选中窗体，这里留7个位置
                else
                {
                    switch (win)
                    {
                        case 1:
                            this.Opacity = 0.2f; //窗口百分之80透明
                                                 //窗体靠近左沿时，鼠标不在窗体时隐藏 
                            SetDesktopLocation(13 - self_SW, frmY);
                            break;
                        case 2:
                            this.Opacity = 0.2f; //窗体靠近顶部时，鼠标不在窗体时隐藏  
                            SetDesktopLocation(frmX, 13 - self_SH);
                            break;
                        case 3:
                            this.Opacity = 0.2f; //窗体靠近右沿时，鼠标不在窗体时隐藏  
                            SetDesktopLocation(SW - 13, frmY);
                            break;
                    }
                }
            }
        }
        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString("HH : mm : ss");
            label2.Text = System.DateTime.Now.ToString("yyyy MMM dd日,ddd");
        }

        
    }

}
