using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KON_Notes
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string[] paths, files;
        int Startindex = 0;
        string[] FileName, FilePath;
        Boolean playnext = false;

        bool _playing = false;
        public bool isplaying
        {
            get
            {
                return _playing;
            }
            set
            {
                _playing = value;
                if (_playing)
                {
                    axWindowsMediaPlayer2.Ctlcontrols.pause(); bunifuImageButton7.Image = bunifuImageButton11.Image;
                }
                else
                {
                    axWindowsMediaPlayer2.Ctlcontrols.play(); bunifuImageButton7.Image = bunifuImageButton12.Image;
                }
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            Startindex = 0;
            playnext = false;
            StopPlayer();

        }
        public void StopPlayer()
        {
            axWindowsMediaPlayer2.Ctlcontrols.stop();
        }

        public void playfile(int playlistindex)
        {
            if (listBox1.Items.Count <= 0)
            {
                return;
            }
            if (playlistindex < 0)
            {
                return;
            }
            axWindowsMediaPlayer2.settings.autoStart = true;
            axWindowsMediaPlayer2.URL = FilePath[playlistindex];
            axWindowsMediaPlayer2.Ctlcontrols.next();
            axWindowsMediaPlayer2.Ctlcontrols.play();
        }

        private void bunifuSlider1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listBox1.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Startindex = 0;
            playnext = false;
            OpenFileDialog opnFileDlg = new OpenFileDialog();
            opnFileDlg.Multiselect = true;
            opnFileDlg.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,3gp,flv)|*.mp3;*.wav;*.pm4;*.3gp;*.avi;*.mov;*.flv;*.wmv;*.mpg|all files|*.*";
            if (opnFileDlg.ShowDialog() == DialogResult.OK)
            {
                FileName = opnFileDlg.SafeFileNames;
                FilePath = opnFileDlg.FileNames;
                for (int i = 0; i <= FileName.Length - 1; i++)
                {
                    listBox1.Items.Add(FileName[i]);
                }
                Startindex = 0;
                playfile(0);
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            StopPlayer();
        }

        private void bunifuSlider2_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.settings.volume = bunifuSlider2.Value;
            bunifuCustomLabel5.Text = bunifuSlider2.Value.ToString();
        }

        private void axWindowsMediaPlayer2_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            listBox1.BringToFront();
        }
        public EventHandler onActon = null;
        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            isplaying = !isplaying;
            if (onActon != null)
            {
                onActon.Invoke(this, e);
            }
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            if (Startindex == listBox1.Items.Count - 1)
            {
                Startindex = listBox1.Items.Count - 1;
            }
            else if (Startindex < listBox1.Items.Count)
            {
                Startindex = Startindex + 1;
            }
            playfile(Startindex);
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuCustomLabel8.Text = axWindowsMediaPlayer2.Ctlcontrols.currentPositionString;
            bunifuCustomLabel7.Text = axWindowsMediaPlayer2.Ctlcontrols.currentItem.durationString.ToString();
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                bunifuProgressBar1.Value = (int)axWindowsMediaPlayer2.Ctlcontrols.currentPosition;
            }
        }
        
        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.play();
        }

        private void bunifuImageButton12_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.pause();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void 单曲循环_Click(object sender, EventArgs e)
        {

        }

        private void 随机播放_Click(object sender, EventArgs e)
        {

        }



        
        public enum PlayMode { Shuffle = 0, SingleLoop, ListLoop };
        public PlayMode currPlayMode = PlayMode.Shuffle;
        private int[] randomList;          //随机播放序列
        private int randomListIndex = 0;    //序列索引
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (currPlayMode == PlayMode.ListLoop)
                currPlayMode = PlayMode.Shuffle;
            else
                currPlayMode += 1;

            if (currPlayMode == PlayMode.SingleLoop)
                bunifuImageButton1.Image = 单曲循环.Image;
            else if (currPlayMode == PlayMode.ListLoop)
                bunifuImageButton1.Image = 列表循环.Image;
            else
                bunifuImageButton1.Image = 随机播放.Image;
        }


        //获取播放歌曲路径
        private string GetPath()
        {
            int currIndex = listBox1.SelectedIndex;
            if (currPlayMode == PlayMode.ListLoop)       //列表循环
            {
                if (currIndex != listBox1.Items.Count - 1)
                {
                    currIndex += 1;
                }
                else
                    currIndex = 0;
            }
            else if (currPlayMode == PlayMode.SingleLoop)  //单曲循环
            {
                //do nothing
            }
            else                    //随机播放
            {
                if (randomListIndex > randomList.Length - 1)
                {
                    //当局结束
                    StarNewRound();
                }

                

                currIndex = randomList[randomListIndex++];
            }

            listBox1.SelectedIndex = currIndex;
            playfile(currIndex);
            return (FilePath[currIndex]);
        }

        private void StarNewRound()
        {
            //重新生成随机序列
            BuildRandomList(listBox1.Items.Count);
           
        }

        private void BuildRandomList(int songListCount)
        {
            randomListIndex = 0;
            randomList = new int[songListCount];

            //初始化序列
            for (int i = 0; i < songListCount; i++)
            {
                randomList[i] = i;
            }

            //随机序列
            for (int i = songListCount - 1; i >= 0; i--)
            {
                Random r = new Random(Guid.NewGuid().GetHashCode());
                int j = r.Next(0, songListCount - 1);
                swap(randomList, i, j);
            }

             void swap(int[] arr, int a, int b)
            {
                int temp = arr[a];
                arr[a] = arr[b];
                arr[b] = temp;
            }
        }

        private void axWindowsMediaPlayer2_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(axWindowsMediaPlayer2.playState==WMPLib.WMPPlayState.wmppsPlaying)
            {
                bunifuProgressBar1.MaximumValue = (int)axWindowsMediaPlayer2.Ctlcontrols.currentItem.duration;
                timer1.Start();

            }
            else if(axWindowsMediaPlayer2.playState==WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();
                bunifuProgressBar1.Value = 0;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Startindex = listBox1.SelectedIndex;
            playfile(Startindex);
            bunifuCustomLabel6.Text = listBox1.Text;
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            if (Startindex > 0)
            {
                Startindex = Startindex - 1;
            }
            playfile(Startindex);
        }
    }
}
