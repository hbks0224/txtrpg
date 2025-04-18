using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txtrpg
{
    internal class Loading
    {

        public static void Loading_intro()
        {
            {
                Console.ForegroundColor = ConsoleColor.Green;
                String[] Loadingcomment = ["오늘 던전의 수상한 상인이 나타난다는 정보가 있다...", "고블린들이 최근에 무리를 지어 다닌다고 한다.",
            "한 모험가가 보물을 찾았지만 돌아오지 못했다.","마법사의 유령이 출몰한다는 소문이 돌고 있다."
            ,"\"길이 맞나?\" — 마지막으로 들린 모험가의 말","어떤 용병이 저주받은 검을 들고 들어갔다는 목격담이 있다.",
            "최근 몬스터들이 평소보다 더 공격적이라는 보고가 들어왔다."]; // 랜덤 코멘트 목록

                Random random_comment = new Random(); // 랜덤 코멘트 변수

                int random_comment_index = random_comment.Next(Loadingcomment.Length);
                int loading_lv = 50;
                Dialogue.Print("환영합니다 모험가님!\n\n");
                Console.ForegroundColor = ConsoleColor.White;

                String Logo = @"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣄⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⢾⡫⡯⣞⢮⢳⢝⡯⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢯⢓⡛⠬⠍⣛⢯⡳⣽⡪⣞⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                           
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢀⡼⡏⢐⣠⡡⠨⠠⠩⢹⡳⣝⣞⠿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡉⠅⡊⢄⢇⠏⢄⡣⡎⢌⡊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⡥⣂⣳⢒⢔⢻⠡⢈⠘⢸⡡⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡤⣺⢝⡯⣻⡹⣻⣷⢴⡢⣑⣾⣶⡬⡺⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⢝⣾⣿⣿⣷⣝⣵⣿⡻⢟⢛⢷⢫⠳⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣯⢻⢽⣽⣟⣯⡟⡫⡢⢡⢑⠔⢭⣆⡕⡘⣮⣳⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⡪⣯⣻⢞⢭⣻⣯⣑⢌⠢⠢⡑⣑⣥⢑⢌⣪⣾⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡽⡾⣳⢶⢧⢿⣝⣟⢻⢭⡫⡩⢱⢍⢪⢿⢿⢿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢠⡴⣻⣵⣟⣯⢯⡮⣷⣕⡳⣝⡶⣇⣟⣍⣫⣙⣝⣯⢇⠽⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣰⡟⣎⡿⣞⢽⡪⣳⢹⢜⣎⣟⣷⡝⣞⢿⣨⢾⣧⢾⡟⡬⡪⡻⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢰⣟⡼⣟⢽⡸⡵⡫⡮⡳⣕⢵⣪⡮⣻⣜⢝⣯⣦⣷⣷⢿⢧⣷⢨⣲⠀⣠⢤⡤⣤⣀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣾⢯⣺⢏⣞⣜⢮⡫⣝⢮⢎⢯⡺⣪⢫⡷⣹⣽⢮⣳⣝⣽⣽⣾⣱⡼⡯⣳⡳⣝⢞⠆⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢹⣵⣝⡧⡧⡳⣕⢽⢼⡮⣫⡺⣜⢮⣳⢯⡳⣽⢯⡺⣪⡳⡳⡝⣞⢮⡫⣞⢞⢮⡻⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠈⢿⣷⡻⣧⡯⡞⣎⣗⢽⢜⢞⢽⣸⡯⡳⣽⢷⢗⣟⢗⡯⣯⢾⡵⡷⣝⢮⡫⡗⠁⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠈⠻⣳⢝⡽⡾⣮⣮⡮⡷⣽⢯⢟⣕⡿⣽⡪⣗⣕⢯⡺⣪⢗⡽⣪⢗⣽⠎⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠮⣞⣮⣪⣞⣞⣮⠾⠛⠳⣽⡪⣏⢗⡵⡳⣝⢮⡳⣝⢮⡳⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠈⠀⠀⠀⠀⠀⠈⠻⢮⣳⢝⣝⢮⣳⣝⣮⣳⢝⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠀⠀⠀⠀⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
"; // 스파르타 이미지를 아스키 아트로 변환해서 사용했음
                String[] Logo_out = Logo.Split('\n'); // 엔터 간격으로 나눠 배열에 담음

                foreach (var line in Logo_out)
                {
                    Console.WriteLine(line);
                    Thread.Sleep(30);
                } // 일정 간격으로 출력

                Console.ForegroundColor = ConsoleColor.Red;

                Dialogue.Print(Loadingcomment[random_comment_index] + "\n\n");
                Console.ForegroundColor = ConsoleColor.Green;


                Console.Write('[');

                for (int i = 0; i < loading_lv + 1; i++) // 100번 반복
                {

                    int persent = (i * 100) / loading_lv;

                    string loading_bar = new string('■', i) + new string('-', loading_lv - i);

                    Console.Write($"\rLoading...[{loading_bar}]{persent}%");
                    Thread.Sleep(10); // 0.01초 간격

                }
                Console.WriteLine();

                Dialogue.Print("로딩완료! 곧 게임을 시작합니다.");


            }

        }
    }
}
