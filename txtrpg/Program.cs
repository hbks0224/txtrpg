using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Media;
using System.Text;
using System.IO;
using WMPLib;



namespace txtrpg
{
    internal class Program
    {


        //public static void bgm() // bgm 재생
        //{
        //    ThreadPool.QueueUserWorkItem(_ =>
        //    {
        //        String root = AppDomain.CurrentDomain.BaseDirectory;

        //        String result = Path.Combine(root, "bgm.mp3");

        //        // Console.WriteLine(result); 
        //        WindowsMediaPlayer player = new WindowsMediaPlayer();
        //        player.settings.setMode("loop", true); // 반복 재생 설정
        //        player.URL = result;  //
        //        //Console.WriteLine(root);

        //        player.controls.play(); // 재생 시작
        //        player.settings.volume = 15; //볼륨 15



        //    });
        //}

        //        public static void Loading() //로딩 바 구현
        //        {
        //            Console.ForegroundColor = ConsoleColor.Green;
        //            String[] Loadingcomment = ["오늘 던전의 수상한 상인이 나타난다는 정보가 있다...", "고블린들이 최근에 무리를 지어 다닌다고 한다.",
        //            "한 모험가가 보물을 찾았지만 돌아오지 못했다.","마법사의 유령이 출몰한다는 소문이 돌고 있다."
        //            ,"\"길이 맞나?\" — 마지막으로 들린 모험가의 말","어떤 용병이 저주받은 검을 들고 들어갔다는 목격담이 있다.",
        //            "최근 몬스터들이 평소보다 더 공격적이라는 보고가 들어왔다."]; // 랜덤 코멘트 목록

        //            Random random_comment = new Random(); // 랜덤 코멘트 변수

        //            int random_comment_index = random_comment.Next(Loadingcomment.Length);
        //            int loading_lv = 50;
        //            dialogue("환영합니다 모험가님!\n\n");
        //            Console.ForegroundColor = ConsoleColor.White;

        //            String Logo = @"
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣄⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⢾⡫⡯⣞⢮⢳⢝⡯⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢯⢓⡛⠬⠍⣛⢯⡳⣽⡪⣞⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                           
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢀⡼⡏⢐⣠⡡⠨⠠⠩⢹⡳⣝⣞⠿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡉⠅⡊⢄⢇⠏⢄⡣⡎⢌⡊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⡥⣂⣳⢒⢔⢻⠡⢈⠘⢸⡡⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡤⣺⢝⡯⣻⡹⣻⣷⢴⡢⣑⣾⣶⡬⡺⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⢝⣾⣿⣿⣷⣝⣵⣿⡻⢟⢛⢷⢫⠳⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣯⢻⢽⣽⣟⣯⡟⡫⡢⢡⢑⠔⢭⣆⡕⡘⣮⣳⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⡪⣯⣻⢞⢭⣻⣯⣑⢌⠢⠢⡑⣑⣥⢑⢌⣪⣾⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡽⡾⣳⢶⢧⢿⣝⣟⢻⢭⡫⡩⢱⢍⢪⢿⢿⢿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⢠⡴⣻⣵⣟⣯⢯⡮⣷⣕⡳⣝⡶⣇⣟⣍⣫⣙⣝⣯⢇⠽⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⣰⡟⣎⡿⣞⢽⡪⣳⢹⢜⣎⣟⣷⡝⣞⢿⣨⢾⣧⢾⡟⡬⡪⡻⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⢰⣟⡼⣟⢽⡸⡵⡫⡮⡳⣕⢵⣪⡮⣻⣜⢝⣯⣦⣷⣷⢿⢧⣷⢨⣲⠀⣠⢤⡤⣤⣀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⣾⢯⣺⢏⣞⣜⢮⡫⣝⢮⢎⢯⡺⣪⢫⡷⣹⣽⢮⣳⣝⣽⣽⣾⣱⡼⡯⣳⡳⣝⢞⠆⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⢹⣵⣝⡧⡧⡳⣕⢽⢼⡮⣫⡺⣜⢮⣳⢯⡳⣽⢯⡺⣪⡳⡳⡝⣞⢮⡫⣞⢞⢮⡻⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠈⢿⣷⡻⣧⡯⡞⣎⣗⢽⢜⢞⢽⣸⡯⡳⣽⢷⢗⣟⢗⡯⣯⢾⡵⡷⣝⢮⡫⡗⠁⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠈⠻⣳⢝⡽⡾⣮⣮⡮⡷⣽⢯⢟⣕⡿⣽⡪⣗⣕⢯⡺⣪⢗⡽⣪⢗⣽⠎⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠮⣞⣮⣪⣞⣞⣮⠾⠛⠳⣽⡪⣏⢗⡵⡳⣝⢮⡳⣝⢮⡳⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠈⠀⠀⠀⠀⠀⠈⠻⢮⣳⢝⣝⢮⣳⣝⣮⣳⢝⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠀⠀⠀⠀⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
        //"; // 스파르타 이미지를 아스키 아트로 변환해서 사용했음
        //            String[] Logo_out = Logo.Split('\n'); // 엔터 간격으로 나눠 배열에 담음

        //            foreach (var line in Logo_out)
        //            {
        //                Console.WriteLine(line);
        //                Thread.Sleep(30);
        //            } // 일정 간격으로 출력

        //            Console.ForegroundColor = ConsoleColor.Red;

        //            dialogue(Loadingcomment[random_comment_index] + "\n\n");
        //            Console.ForegroundColor = ConsoleColor.Green;


        //            Console.Write('[');

        //            for (int i = 0; i < loading_lv + 1; i++) // 100번 반복
        //            {

        //                int persent = (i * 100) / loading_lv;

        //                string loading_bar = new string('■', i) + new string('-', loading_lv - i);

        //                Console.Write($"\rLoading...[{loading_bar}]{persent}%");
        //                Thread.Sleep(10); // 0.01초 간격

        //            }
        //            Console.WriteLine();

        //            dialogue("로딩완료! 곧 게임을 시작합니다.");


        //        }

        //public static void dialogue(string message)
        //{


        //    foreach (char c in message) //따라라락 나오게하자
        //    {
        //        Console.Write(c);
        //        Thread.Sleep(40);
        //    }

        //    Console.WriteLine();
        //}//대화로직
        //public static void Intro_name()
        //{
        //    dialogue("새로운 모험가인가..? \n.\n.\n.\n.\n.\n뭘 그렇게 멍을 때리고 있어? 어이, 너 이름이 뭐야?\n");


        //    while (true)
        //    {
        //        dialogue("'내이름은...'");
        //        dialogue("이름을 입력하세요.");

        //        GameInfo.PlayerName = Console.ReadLine(); //이름 변수
        //        if (string.IsNullOrWhiteSpace(GameInfo.PlayerName)) //이름이 빈칸 일 때
        //        {

        //            dialogue("넌 제대로 된 이름도 없는거냐? (제대로 이름을 말하자)");
        //            continue;
        //        }

        //        String NameCheck; //이름이 맞는지 체크하기위한 변수
        //        dialogue(GameInfo.PlayerName + " 그게 너의 이름이야? (Y/N)");
        //        NameCheck = Console.ReadLine();

        //        if (NameCheck == "Y" || NameCheck == "y")
        //        {

        //            dialogue("크크.." + GameInfo.PlayerName + "이라고? 만나서 반가워, " + GameInfo.PlayerName + "!" + "\n" + "모험을 떠날 준비는 됐나?\n" + "너가 살아서 돌아 올 수 있을지 지켜보겠다구");
        //            break;

        //        }
        //        else if (NameCheck == "N" || NameCheck == "n")
        //        {
        //            dialogue("아니라고? 그럼 진짜 너의 이름은 뭐야?");

        //        }

        //        else
        //        {

        //            dialogue("너는 대답도 제대로 할 줄 모르나 보군? (Y 또는 N만 입력하세요.)");
        //        }

        //    }

        //} //시작하고 이름 정하기


        // public static class GameInfo // 게임에 쓰일 변수들 모음
        //{
        //    public static int PlayerLevel; //캐릭터 레벨
        //    public static string PlayerName; // 캐릭터 이름
        //    public static string PlayerClass; // 캐릭터 직업
        //    public static int Attack; // 캐릭터 공격력
        //    public static int Defense; // 캐릭터 방어력
        //    public static int Health; // 캐릭터 체력
        //    public static int PlayerGold; // 캐릭터 골드
        //}

        //public static void Choose_Class()
        //{
        //    Dialogue.Print(GameInfo.PlayerName + "님 반갑습니다.");
        //    Dialogue.Print(GameInfo.PlayerName + "님, 본격적인 RPG를 시작하기 앞서 몇 가지 질문을 드리겠습니다.\n질문의 대답에 따라 직업이 결정되오니 신중히 대답해주세요!");
        //    int Warrior_point = 0;
        //    int Wizard_point = 0;
        //    int Archer_point = 0;
        //    // 질문에 따라 각 직업의 포인트가 오름 , 포인트가 가장 높은 직업으로 결정 (포켓몬 구조대 참고) 포인트가 같을경우에는 고르게 하자

        //    String[] Questions = { "1. 싸움이 시작되면 당신의 스타일은?", "2. 당신이 선호하는 무기는?", "3. 적이 강해 보일 때 당신은?", "4. 자유시간이 생기면?" , "5. 전투 중에 중요한 건?",
        //    "6. 친구가 위험에 처했다면?","7. 게임할 때 자주 고르는 캐릭터는?","8. 당신이 좋아하는 영화 캐릭터는?","9. 전투에서 중요한 첫 행동은?","10. 팀원으로 있으면 좋은 스타일은?"};

        //    // 10개의 질문, 각각 3개의 선택지를 가진 2차원 배열
        //    string[,] Answers = {
        //    { "(1) 앞장서서 돌진한다!", "(2) 뒤에서 마법으로 지원한다.", "(3) 멀리서 상황을 보며 활을 겨눈다." },
        //    { "(1) 커다란 검이나 도끼", "(2) 지팡이나 책", "(3) 활이나 단검" },
        //    { "(1) 정면 돌파", "(2) 약점을 분석하고 대응", "(3) 기습 후 도망 준비" },
        //    { "(1) 운동! 몸을 단련한다", "(2) 연구나 독서", "(3) 자연 속에서 휴식" },
        //    { "(1) 강한 힘과 방어력", "(2) 전략과 마법의 조합", "(3) 기동성과 정확한 타격" },
        //    { "(1) 곧바로 구하러 간다!", "(2) 침착하게 상황을 판단", "(3) 숨어서 기회를 본다" },
        //    { "(1) 탱커, 전투형", "(2) 법사, 서포터", "(3) 원거리 딜러" },
        //    { "(1) 토르, 캡틴 아메리카", "(2) 닥터 스트레인지, 해리포터", "(3) 레고라스, 호크아이" },
        //    { "(1) 돌진해서 먼저 맞붙기", "(2) 상태 이상이나 버프/디버프 마법", "(3) 적의 위치 파악과 원거리 견제" },
        //    { "(1) 앞에서 막아주는 단단한 사람", "(2) 다양한 마법으로 지원해주는 사람", "(3) 조용히 뒤에서 적을 처리해주는 사람" }
        //    };

        //    //질문 시작
        //    for (int i = 0; i < Questions.Length; i++)
        //    {
        //        Dialogue.Print(Questions[i]);
        //        for (int j = 0; j < 3; j++)
        //        {
        //            Dialogue.Print(Answers[i, j]);
        //        }

        //        int choice = 0;
        //        while (true)
        //        {
        //            Dialogue.Print("당신의 선택은? (1~3): ");
        //            string input = Console.ReadLine();
        //            if (int.TryParse(input, out choice) && choice >= 1 && choice <= 3)
        //                break;
        //            Dialogue.Print("잘못된 입력입니다. 1~3 중에서 골라주세요.");
        //        }

        //        if (choice == 1)
        //        {

        //            Warrior_point++;
        //        }
        //        else if (choice == 2)
        //        {

        //            Wizard_point++;
        //        }
        //        else if (choice == 3)
        //        {


        //            Archer_point++;
        //        }


        //    }

        //    // 최종 포인트 비교
        //    string job = "";
        //    if (Warrior_point > Wizard_point && Warrior_point > Archer_point)
        //        job = "전사";
        //    else if (Wizard_point > Warrior_point && Wizard_point > Archer_point)
        //        job = "마법사";
        //    else if (Archer_point > Warrior_point && Archer_point > Wizard_point)
        //        job = "궁수";

        //    else if(Warrior_point == Wizard_point)
        //    {
        //        Dialogue.Print("\n두 직업이 동일한 성향을 보입니다. 당신의 선택은?");
        //        Dialogue.Print("1. 전사\n2. 마법사\n");
        //        while (true){

        //                string input = Console.ReadLine();
        //            if (input == "1")
        //            {
        //                job = "전사";
        //                break;
        //            }
        //            else if (input == "2")
        //            {
        //                job = "마법사";
        //                break;
        //            }
        //            else
        //            {
        //                Dialogue.Print("잘못된 입력입니다.\n1또는 2를 입력해주세요");

        //            }



        //            }
        //    }
        //    else if (Warrior_point == Archer_point)
        //    {
        //        Dialogue.Print("\n두 직업이 동일한 성향을 보입니다. 당신의 선택은?");
        //        Dialogue.Print("1. 전사\n2. 궁수\n");
        //        while (true)
        //        {

        //            string input = Console.ReadLine();
        //            if (input == "1")
        //            {
        //                job = "전사";
        //                break;
        //            }
        //            else if (input == "2")
        //            {
        //                job = "궁수";
        //                break;
        //            }
        //            else
        //            {
        //                Dialogue.Print("잘못된 입력입니다.\n1또는 2를 입력해주세요");

        //            }



        //        }
        //    }

        //    else if (Archer_point == Wizard_point)
        //    {
        //        Dialogue.Print("\n두 직업이 동일한 성향을 보입니다. 당신의 선택은?");
        //        Dialogue.Print("1. 궁수\n2. 마법사\n");
        //        while (true)
        //        {

        //            string input = Console.ReadLine();
        //            if (input == "1")
        //            {
        //                job = "궁수";
        //                break;
        //            }
        //            else if (input == "2")
        //            {
        //                job = "마법사";
        //                break;
        //            }
        //            else
        //            {
        //                Dialogue.Print("잘못된 입력입니다.\n1또는 2를 입력해주세요");

        //            }



        //        }
        //    }


        //    Dialogue.Print("당신의 직업은 " + job + "입니다!");
        //}

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8; // 콘솔 인코딩 설정


            Item.Make();

            Bgm.Playbgm();

            Loading.Loading_intro();
            
            Thread.Sleep(3000);// 로딩 완료후 딜레이 설정

            Console.Clear(); // 새로운 화면

            Intro.name(); // 이름 정하기
            Thread.Sleep(3000);
            Console.Clear();
            Intro.Choose_Class();//직업 정하기
            MainMenu.Display();// 메인 메뉴
            Console.ReadKey();


        }
    }
}
