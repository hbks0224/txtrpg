using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Threading;

using WMPLib;
using static System.Net.WebRequestMethods;


namespace txtrpg
{
    internal class Bgm
    {
        public static void Playbgm() // bgm 재생
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                //String root = AppDomain.CurrentDomain.BaseDirectory;

                // String result = Path.Combine(root, "bgm.mp3");

                // Console.WriteLine(result); 
                WindowsMediaPlayer player = new WindowsMediaPlayer();
                player.settings.setMode("loop", true); // 반복 재생 설정
                player.URL = @"https://hbks0224.github.io/txtrpg/bgm.mp3";  //git에 업로드된 bgm 재생
                //Console.WriteLine(root);

                player.controls.play(); // 재생 시작
                player.settings.volume = 15; //볼륨 15



            });
        }
    }
}
