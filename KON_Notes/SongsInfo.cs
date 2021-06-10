using Shell32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KON_Notes
{
    public class SongsInfo
    {
        private string fileName;    //1
        private string filePath;
        private string filesize;    //2
        private string artist;      //13
        private string album;       //14
        private Image albumImage;
        private string year;        //15
        private string originName;  //21
        private string duration;     //27
        private string byteRate;    //28

        public string FileName { get => fileName; set => fileName = value; }
        public string FilePath { get => filePath; set => filePath = value; }
        public string Filesize { get => filesize; set => filesize = value; }
        public string Artist { get => artist; set => artist = value; }
        public string Album { get => album; set => album = value; }

        public Image AlbumImage { get => albumImage; set => albumImage = value; }

        public string Year { get => year; set => year = value; }
        public string OriginName { get => originName; set => originName = value; }
        public string Duration { get => duration; set => duration = value; }
        public string ByteRate { get => byteRate; set => byteRate = value; }


        public SongsInfo(string fPath)
        {
            SetSongInfo(fPath);
            SetAlbumArt(fPath);
        }

        private void SetSongInfo(string strPath)
        {
         try
            {
                ShellClass sh = new ShellClass();
                Folder dir = sh.NameSpace(Path.GetDirectoryName(strPath));
                FolderItem item =dir.ParseName(Path.GetFileName(strPath));

                fileName = dir.GetDetailsOf(item, 0);
                if (fileName == string.Empty)
                    fileName = "未知";

                FilePath = strPath;

                filesize = dir.GetDetailsOf(item, 1);
                if (filesize == string.Empty)
                    filesize = "未知";

                artist = dir.GetDetailsOf(item, 13);
                if (artist == string.Empty)
                    artist = "未知";

                album = dir.GetDetailsOf(item, 14);
                if (album == string.Empty)
                    album = "未知";

                year = dir.GetDetailsOf(item, 15);
                if (year == string.Empty)
                    year = "未知";

                OriginName = dir.GetDetailsOf(item, 21);
                if (OriginName == string.Empty)
                    OriginName = "未知";

                duration = dir.GetDetailsOf(item, 27);
                if (duration == string.Empty)
                    duration = "未知";

                byteRate = dir.GetDetailsOf(item, 28);
                if (byteRate == string.Empty)
                    byteRate = "未知";

                //输出0-50位信息
                //for (int i = -1; i < 50; i++)
                //{
                //    string str = dir.GetDetailsOf(item, i);
                //    Console.WriteLine(i + " && " + str);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //获取歌曲封面
        private void SetAlbumArt(string strPath)
        {
            if (strPath != "" && strPath != null)
            {
                TagLib.File file = TagLib.File.Create(strPath);
                if (file.Tag.Pictures.Length > 0)
                {
                    var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                    albumImage = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(100, 100, null, IntPtr.Zero);
                }
                else
                {
                    albumImage = Properties.Resources.DefaultAlbum;
                }
            }
            else
            {
                albumImage = Properties.Resources.DefaultAlbum;
            }
        }
    }
}

