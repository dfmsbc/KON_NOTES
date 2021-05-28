
namespace KON_Notes
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.ButtonMusic = new FontAwesome.Sharp.IconButton();
            this.ButtonDollar = new FontAwesome.Sharp.IconButton();
            this.ButtonList = new FontAwesome.Sharp.IconButton();
            this.panellogo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.BacktoHomeTitle = new System.Windows.Forms.Label();
            this.iconBacktoHome = new FontAwesome.Sharp.IconPictureBox();
            this.panelshadow = new System.Windows.Forms.Panel();
            this.panelDesk = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.panellogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconBacktoHome)).BeginInit();
            this.panelDesk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.ButtonMusic);
            this.panelMenu.Controls.Add(this.ButtonDollar);
            this.panelMenu.Controls.Add(this.ButtonList);
            this.panelMenu.Controls.Add(this.panellogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(190, 587);
            this.panelMenu.TabIndex = 0;
            // 
            // ButtonMusic
            // 
            this.ButtonMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonMusic.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonMusic.FlatAppearance.BorderSize = 0;
            this.ButtonMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMusic.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonMusic.ForeColor = System.Drawing.Color.Gainsboro;
            this.ButtonMusic.IconChar = FontAwesome.Sharp.IconChar.Music;
            this.ButtonMusic.IconColor = System.Drawing.Color.Gainsboro;
            this.ButtonMusic.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ButtonMusic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonMusic.Location = new System.Drawing.Point(0, 338);
            this.ButtonMusic.Name = "ButtonMusic";
            this.ButtonMusic.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ButtonMusic.Size = new System.Drawing.Size(190, 80);
            this.ButtonMusic.TabIndex = 3;
            this.ButtonMusic.Text = "音 乐";
            this.ButtonMusic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonMusic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonMusic.UseVisualStyleBackColor = true;
            this.ButtonMusic.Click += new System.EventHandler(this.ButtonMusic_Click);
            // 
            // ButtonDollar
            // 
            this.ButtonDollar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDollar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonDollar.FlatAppearance.BorderSize = 0;
            this.ButtonDollar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDollar.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonDollar.ForeColor = System.Drawing.Color.Gainsboro;
            this.ButtonDollar.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.ButtonDollar.IconColor = System.Drawing.Color.Gainsboro;
            this.ButtonDollar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ButtonDollar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDollar.Location = new System.Drawing.Point(0, 258);
            this.ButtonDollar.Name = "ButtonDollar";
            this.ButtonDollar.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ButtonDollar.Size = new System.Drawing.Size(190, 80);
            this.ButtonDollar.TabIndex = 2;
            this.ButtonDollar.Text = "记 账 本";
            this.ButtonDollar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDollar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonDollar.UseVisualStyleBackColor = true;
            this.ButtonDollar.Click += new System.EventHandler(this.ButtonDollar_Click);
            // 
            // ButtonList
            // 
            this.ButtonList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonList.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonList.FlatAppearance.BorderSize = 0;
            this.ButtonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonList.ForeColor = System.Drawing.Color.Gainsboro;
            this.ButtonList.IconChar = FontAwesome.Sharp.IconChar.ListUl;
            this.ButtonList.IconColor = System.Drawing.Color.Gainsboro;
            this.ButtonList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ButtonList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonList.Location = new System.Drawing.Point(0, 178);
            this.ButtonList.Name = "ButtonList";
            this.ButtonList.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ButtonList.Size = new System.Drawing.Size(190, 80);
            this.ButtonList.TabIndex = 1;
            this.ButtonList.Text = "记 事 本";
            this.ButtonList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonList.UseVisualStyleBackColor = true;
            this.ButtonList.Click += new System.EventHandler(this.ButtonList_Click);
            // 
            // panellogo
            // 
            this.panellogo.Controls.Add(this.btnHome);
            this.panellogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panellogo.Location = new System.Drawing.Point(0, 0);
            this.panellogo.Name = "panellogo";
            this.panellogo.Size = new System.Drawing.Size(190, 178);
            this.panellogo.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Image = global::KON_Notes.Properties.Resources.diugai_com162037513177341;
            this.btnHome.Location = new System.Drawing.Point(-71, -95);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(329, 347);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTitleBar.Controls.Add(this.iconPictureBox3);
            this.panelTitleBar.Controls.Add(this.iconPictureBox2);
            this.panelTitleBar.Controls.Add(this.iconPictureBox1);
            this.panelTitleBar.Controls.Add(this.BacktoHomeTitle);
            this.panelTitleBar.Controls.Add(this.iconBacktoHome);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(190, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(789, 74);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconPictureBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.iconPictureBox3.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.Location = new System.Drawing.Point(714, 3);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox3.TabIndex = 4;
            this.iconPictureBox3.TabStop = false;
            this.iconPictureBox3.Click += new System.EventHandler(this.iconPictureBox3_Click);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.Location = new System.Drawing.Point(754, 3);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox2.TabIndex = 3;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.Click += new System.EventHandler(this.iconPictureBox2_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.Location = new System.Drawing.Point(675, 3);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 2;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // BacktoHomeTitle
            // 
            this.BacktoHomeTitle.AutoSize = true;
            this.BacktoHomeTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BacktoHomeTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.BacktoHomeTitle.Location = new System.Drawing.Point(61, 35);
            this.BacktoHomeTitle.Name = "BacktoHomeTitle";
            this.BacktoHomeTitle.Size = new System.Drawing.Size(57, 22);
            this.BacktoHomeTitle.TabIndex = 1;
            this.BacktoHomeTitle.Text = "Home";
            // 
            // iconBacktoHome
            // 
            this.iconBacktoHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconBacktoHome.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconBacktoHome.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconBacktoHome.IconColor = System.Drawing.Color.MediumPurple;
            this.iconBacktoHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBacktoHome.IconSize = 49;
            this.iconBacktoHome.Location = new System.Drawing.Point(18, 17);
            this.iconBacktoHome.Name = "iconBacktoHome";
            this.iconBacktoHome.Size = new System.Drawing.Size(49, 49);
            this.iconBacktoHome.TabIndex = 0;
            this.iconBacktoHome.TabStop = false;
            // 
            // panelshadow
            // 
            this.panelshadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelshadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelshadow.Location = new System.Drawing.Point(190, 74);
            this.panelshadow.Name = "panelshadow";
            this.panelshadow.Size = new System.Drawing.Size(789, 9);
            this.panelshadow.TabIndex = 2;
            // 
            // panelDesk
            // 
            this.panelDesk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesk.Controls.Add(this.label2);
            this.panelDesk.Controls.Add(this.label1);
            this.panelDesk.Controls.Add(this.pictureBox1);
            this.panelDesk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesk.Location = new System.Drawing.Point(190, 83);
            this.panelDesk.Name = "panelDesk";
            this.panelDesk.Size = new System.Drawing.Size(789, 504);
            this.panelDesk.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(262, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(306, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::KON_Notes.Properties.Resources.diugai_com162037513177341;
            this.pictureBox1.Location = new System.Drawing.Point(73, -83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(619, 551);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 587);
            this.Controls.Add(this.panelDesk);
            this.Controls.Add(this.panelshadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panellogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconBacktoHome)).EndInit();
            this.panelDesk.ResumeLayout(false);
            this.panelDesk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton ButtonMusic;
        private FontAwesome.Sharp.IconButton ButtonDollar;
        private FontAwesome.Sharp.IconButton ButtonList;
        private System.Windows.Forms.Panel panellogo;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label BacktoHomeTitle;
        private FontAwesome.Sharp.IconPictureBox iconBacktoHome;
        private System.Windows.Forms.Panel panelshadow;
        private System.Windows.Forms.Panel panelDesk;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

