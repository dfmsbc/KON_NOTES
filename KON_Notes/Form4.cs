
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.IO;


namespace KON_Notes
{
    public partial class Form4 : Form
    {
        AxWMPLib.AxWindowsMediaPlayer testAWM = new AxWMPLib.AxWindowsMediaPlayer();
        SongsInfo currPlaySong = new SongsInfo(null);
        SongsInfo currSelectedSong = new SongsInfo(null);       //用于查看详情
        private List<SongsInfo> oringinListSong;            //用于搜索功能
        //随机1，单曲循环2，列表循环3
        public enum PlayMode { Shuffle = 0, SingleLoop, ListLoop };
        public PlayMode currPlayMode = PlayMode.Shuffle;
        private string localSongsFilePath = Application.StartupPath + "\\songListHistory.txt";
        private int[] randomList;           //随机播放序列
        private int randomListIndex = 0;    //序列索引
        private int jumpSongIndex;          //手动选中需要在随机过程中跳过的歌曲
        private List<SongsInfo> localSongsList = new List<SongsInfo>();         //本地音乐List

        public Form4()
        {
            InitializeComponent();
            testAWM.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayer2_PlayStateChange);
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            ReloadStatus();
            //读取播放器列表历史记录
            localSongsList = ReadHistorySongsList(localSongsFilePath);
           

        }

        private void AddSongsToListView(List<SongsInfo> songList)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (SongsInfo song in songList)
            {
                string[] songAry = new string[6];
                int currCount = listView1.Items.Count + 1;
                if (currCount < 10)
                    songAry[0] = "0" + currCount;
                else
                    songAry[0] = "" + currCount;

                songAry[1] = song.FileName;
                songAry[2] = song.Artist;
                songAry[3] = song.Album;
                songAry[4] = song.Duration;
                songAry[5] = song.Filesize;


                ListViewItem lvItem = new ListViewItem(songAry);
                lvItem.SubItems.Add(song.FilePath);
                listView1.Items.Add(lvItem);

                WMPLib.IWMPMedia media =axWindowsMediaPlayer2.newMedia(song.FilePath);
                axWindowsMediaPlayer2.currentPlaylist.appendItem(media);
            }
            listView1.EndUpdate();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listView1.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnFileDlg = new OpenFileDialog();
            opnFileDlg.Multiselect = true;
            opnFileDlg.InitialDirectory = @"..\Debug\music_list";
            opnFileDlg.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,3gp,flv)|*.mp3;*.wav;*.pm4;*.3gp;*.avi;*.mov;*.flv;*.wmv;*.mpg|all files|*.*";
            if (opnFileDlg.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < opnFileDlg.FileNames.Length; i++)
                {
                    string filePath = opnFileDlg.FileNames[i];
                    //判断播放列表中是否已经存在，否则跳过添加
                    if (!IsExistInList(filePath))
                    {
                        localSongsList.Add(new SongsInfo(filePath));
                    }

                }
            }
            //用于更新列表序列（在歌曲查找中会用到）
            AddSongsToListView(localSongsList);
            SaveSongsListHistory(localSongsFilePath, localSongsList);

            UpdataOringinSongList();
        }

        private void ReloadStatus()
        {


            //设置封面pictureBox的默认图片
            pictureBox1.Image = Properties.Resources.DefaultAlbum;
            bunifuCustomLabel6.Text = "          歌曲名";
            bunifuCustomLabel7.Text = "00:00";
            bunifuCustomLabel8.Text = "00:00";
            tsslCurrentPlayState.Text = "  就绪";
            bunifuSlider2.Value = bunifuSlider2.MaximumValue / 2;
            bunifuSlider1.Value = 0;
            //如果没有选中播放列表，默认选中第一项
            if (listView1.Items.Count > 0 && listView1.SelectedItems.Count == 0)
            {
                listView1.Items[0].Selected = true;//设定选中            
                listView1.Items[0].EnsureVisible();//保证可见
                listView1.Items[0].Focused = true;
            }

        }
        private bool IsExistInList(string path)
        {
            for (int i = 0; i < localSongsList.Count; i++)
            {
                if (path == localSongsList[i].FilePath)
                    return true;
            }
            return false;
        }
        

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.stop();
        }

        private void bunifuSlider2_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.settings.volume = bunifuSlider2.Value;
            bunifuCustomLabel5.Text = bunifuSlider2.Value.ToString();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            AddSongsToListView(localSongsList);
            SaveSongsListHistory(localSongsFilePath, localSongsList);

            UpdataOringinSongList();
            listView1.BringToFront();
        }

        //播放

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState.ToString() == "wmppsPlaying")       //播放->暂停
            {
                axWindowsMediaPlayer2.Ctlcontrols.pause();
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
                //改变任务栏播放按钮图标
                return;
            }
            else if (axWindowsMediaPlayer2.playState.ToString() == "wmppsPaused")    //暂停->播放
            {
                axWindowsMediaPlayer2.Ctlcontrols.play();
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;

                return;
            }

            //双击播放列表
            if (listView1.SelectedItems.Count > 0)         //双击播放列表控制
            {
                Play(listView1.SelectedItems[0].Index);
            }
            else
                MessageBox.Show("请选择要播放的曲目");
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先添加曲目至目录");
            }
            int currIndex = listView1.SelectedItems[0].Index;
            if (currIndex < listView1.Items.Count - 1)
            {
                axWindowsMediaPlayer2.Ctlcontrols.stop();
                currIndex += 1;
            }
            else
            {
                axWindowsMediaPlayer2.Ctlcontrols.stop();
                currIndex = 0;
            }

            Play(currIndex);
        }


        private void Play(int index)
        {
            //设置被播放音乐项的状态
            listView1.Items[index].Focused = true;
            listView1.Items[index].EnsureVisible();
            listView1.Items[index].Selected = true;
            if (axWindowsMediaPlayer2.playState.ToString() == "wmppsPlaying")       //播放->其他状态
            {
                axWindowsMediaPlayer2.Ctlcontrols.pause();
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
                //改变任务栏按钮图标

                return;
            }
            if (axWindowsMediaPlayer2.playState.ToString() != "wmppsPaused")      //更改播放路径并播放
            {
                //重新生成随机播放序列
                BuildRandomList(listView1.Items.Count);
                jumpSongIndex = index;
                currPlaySong = new SongsInfo(listView1.SelectedItems[0].SubItems[6].Text);
                axWindowsMediaPlayer2.URL = currPlaySong.FilePath;
                axWindowsMediaPlayer2.Ctlcontrols.play();
                return;
            }
            else                            //暂停->播放
                axWindowsMediaPlayer2.Ctlcontrols.play();

            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string currPlayTime = null;
            currPlayTime = axWindowsMediaPlayer2.Ctlcontrols.currentPositionString;
            bunifuCustomLabel8.Text = currPlayTime;
            bunifuCustomLabel7.Text = currPlaySong.Duration.Remove(0, 3);
            //设置进度条位置
            bunifuSlider1.Value = (int)axWindowsMediaPlayer2.Ctlcontrols.currentPosition;
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
            int currIndex = listView1.SelectedItems[0].Index;
            if (currPlayMode == PlayMode.ListLoop)       //列表循环
            {
                if (currIndex != listView1.Items.Count - 1)
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

                //匹配到需要跳过的歌曲
                if (randomList[randomListIndex] == jumpSongIndex)
                {
                    if (randomListIndex == randomList.Length - 1)
                    {
                        //当局结束
                        StarNewRound();
                    }
                    else
                        randomListIndex++;
                }

                currIndex = randomList[randomListIndex++];
            }
            listView1.Items[currIndex].Selected = true;//设定选中            
            listView1.Items[currIndex].EnsureVisible();//保证可见
            listView1.Items[currIndex].Focused = true;
            currPlaySong = new SongsInfo(listView1.SelectedItems[0].SubItems[6].Text);

            return currPlaySong.FilePath;
        }

        private void StarNewRound()
        {
            //重新生成随机序列
            BuildRandomList(listView1.Items.Count);
            jumpSongIndex = -1;

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
            switch (e.newState)
            {
                case 0:    // Stopped
                    tsslCurrentPlayState.Text = "未知状态";
                    break;
                case 1:    // Stopped
                    tsslCurrentPlayState.Text = "停止";

                    timer1.Stop();
                    ReloadStatus();
                    break;

                case 2:    // Paused
                    tsslCurrentPlayState.Text = "暂停";

                    timer1.Stop();
                    break;

                case 3:    // Playing
                    tsslCurrentPlayState.Text = "正在播放";

                    timer1.Start();
                    bunifuCustomLabel6.Text = currPlaySong.FileName;
                    pictureBox1.Image = currPlaySong.AlbumImage;
                    bunifuSlider1.MaximumValue = (int)axWindowsMediaPlayer2.currentMedia.duration;
                    int currIndex = listView1.SelectedItems[0].Index;
                    listView1.SelectedItems.Clear();
                    listView1.Items[currIndex].Selected = true;    //设定选中            
                    listView1.Items[currIndex].EnsureVisible();    //保证可见
                    listView1.Items[currIndex].Focused = true;
                    listView1.Select();

                    break;
                case 4:    // ScanForward
                    tsslCurrentPlayState.Text = "ScanForward";
                    break;

                case 5:    // ScanReverse
                    tsslCurrentPlayState.Text = "ScanReverse";
                    break;
                case 6:    // Buffering
                    tsslCurrentPlayState.Text = "正在缓冲";
                    break;

                case 7:    // Waiting
                    tsslCurrentPlayState.Text = "Waiting";
                    break;

                case 8:    // MediaEnded
                    tsslCurrentPlayState.Text = "MediaEnded";

                    break;

                case 9:    // Transitioning
                    tsslCurrentPlayState.Text = "正在连接";
                    break;

                case 10:   // Ready
                    tsslCurrentPlayState.Text = "准备就绪";
                    break;

                case 11:   // Reconnecting
                    tsslCurrentPlayState.Text = "Reconnecting";
                    break;

                case 12:   // Last
                    tsslCurrentPlayState.Text = "Last";
                    break;
                default:
                    tsslCurrentPlayState.Text = ("Unknown State: " + e.newState.ToString());
                    break;
            }
            //Console.WriteLine(tsslCurrentPlayState.Text);

            //播放完毕后的操作
            if (axWindowsMediaPlayer2.playState.ToString() == "wmppsMediaEnded")
            {
                
                //播放路径的获取与播放模式有关，在下一个小节里贴代码
                string path = GetPath();
                WMPLib.IWMPMedia media = axWindowsMediaPlayer2.newMedia(path);
                axWindowsMediaPlayer2.currentPlaylist.appendItem(media);
            }
        }



        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("请先添加曲目至目录");
                return;
            }

            int currIndex = listView1.SelectedItems[0].Index;
            if (currIndex > 0)
            {
                axWindowsMediaPlayer2.Ctlcontrols.stop();
                currIndex -= 1;
            }
            else
            {
                axWindowsMediaPlayer2.Ctlcontrols.stop();
                currIndex = listView1.Items.Count - 1;
            }

            listView1.Items[currIndex].Focused = true;
            listView1.Items[currIndex].EnsureVisible();
            listView1.Items[currIndex].Selected = true;

            Play(currIndex);
        }
        //进度条滑动
        private void bunifuSlider2_Scroll(object sender, ScrollEventArgs e)
        {
            axWindowsMediaPlayer2.settings.volume =this.bunifuSlider2.Value;
        }

        private void bunifuSlider1_Scroll(object sender, ScrollEventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.currentPosition = (double)this.bunifuSlider1.Value;
        }



        private void SaveSongsListHistory(string savePath, List<SongsInfo> songsList)
        {
            string saveString = "";
            for (int i = 0; i < songsList.Count; i++)
            {
                saveString += songsList[i].FilePath + "};{";
            }
            File.WriteAllText(savePath, saveString);
        }
        private List<SongsInfo> ReadHistorySongsList(string filePath)
        {
            List<SongsInfo> resSongList = new List<SongsInfo>();
            string readString = "";
            if (File.Exists(filePath))
            {
                readString = File.ReadAllText(filePath);
                if (readString != "")
                {
                    string[] arr = readString.Split(new string[] { "};{" }, StringSplitOptions.None);
                    foreach (string path in arr)
                    {
                        if (path != null && path != "" && File.Exists(path))
                        {
                            resSongList.Add(new SongsInfo(path));
                        }
                    }
                }
            }
            else
                File.Create(filePath);

            return resSongList;
        }
        private void UpdataOringinSongList()
        {
            oringinListSong = new List<SongsInfo>();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                oringinListSong.Add(new SongsInfo(listView1.Items[i].SubItems[6].Text));
            }
        }

        private void bunifuSlider1_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.currentPosition = (double)this.bunifuSlider1.Value;
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            int index = e.ColumnIndex;

            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(27, 27, 25)), e.Bounds);
            TextRenderer.DrawText(e.Graphics, listView1.Columns[index].Text, new Font("微软雅黑", 9, FontStyle.Regular), e.Bounds, Color.Gray, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            Pen pen = new Pen(Color.FromArgb(34, 35, 39), 2);
            Point p = new Point(e.Bounds.Left - 1, e.Bounds.Top + 1);
            Size s = new Size(e.Bounds.Width, e.Bounds.Height - 2);
            Rectangle r = new Rectangle(p, s);
            e.Graphics.DrawRectangle(pen, r);
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Console.WriteLine("selectedCount:" + listView1.SelectedItems.Count);
            if (e.ItemIndex == -1)
            {
                return;
            }

            if (e.ItemIndex % 2 == 0)
            {
                e.SubItem.BackColor = Color.FromArgb(27, 29, 32);
                e.DrawBackground();
            }

            if (e.ColumnIndex == 1)
            {
                e.SubItem.ForeColor = Color.White;
            }
            else
            {
                e.SubItem.ForeColor = Color.Gray;
            }

            if ((e.ItemState & ListViewItemStates.Selected) == ListViewItemStates.Selected)
            {
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(46, 47, 51)), e.Bounds);
                }
            }

            if (!string.IsNullOrEmpty(e.SubItem.Text))
            {
                this.DrawText(e, e.Graphics, e.Bounds, 2);
            }
        }
        private void DrawText(DrawListViewSubItemEventArgs e, Graphics g, Rectangle r, int paddingLeft)
        {
            TextFormatFlags flags = GetFormatFlags(e.Header.TextAlign);

            r.X += 1 + paddingLeft;//重绘图标时，文本右移
            TextRenderer.DrawText(
                g,
                e.SubItem.Text,
                e.SubItem.Font,
                r,
                e.SubItem.ForeColor,
                flags);
        }
        private TextFormatFlags GetFormatFlags(HorizontalAlignment align)
        {
            TextFormatFlags flags =
                    TextFormatFlags.EndEllipsis |
                    TextFormatFlags.VerticalCenter;

            switch (align)
            {
                case HorizontalAlignment.Center:
                    flags |= TextFormatFlags.HorizontalCenter;
                    break;
                case HorizontalAlignment.Right:
                    flags |= TextFormatFlags.Right;
                    break;
                case HorizontalAlignment.Left:
                    flags |= TextFormatFlags.Left;
                    break;
            }

            return flags;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine(listView1.SelectedItems[0].Index);

            int currIndex = listView1.SelectedItems[0].Index;
            string songFilePath = listView1.Items[currIndex].SubItems[6].Text;
            if (currPlaySong.FilePath == songFilePath)
            {
                //选中歌曲为正在播放的歌曲
                if (axWindowsMediaPlayer2.playState.ToString() == "wmppsPlaying")
                {
                    axWindowsMediaPlayer2.Ctlcontrols.pause();
                    iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
                }
                else if (axWindowsMediaPlayer2.playState.ToString() == "wmppsPaused")
                {
                    axWindowsMediaPlayer2.Ctlcontrols.play();
                    iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
                }
            }
            else
            {
                //选中的为其他歌曲
                BuildRandomList(listView1.Items.Count);
                jumpSongIndex = currIndex;
                currPlaySong = new SongsInfo(songFilePath);
                axWindowsMediaPlayer2.URL = songFilePath;
                axWindowsMediaPlayer2.Ctlcontrols.play();
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
            }
            listView1.Items[currIndex].Focused = true;
        }

    }
}
