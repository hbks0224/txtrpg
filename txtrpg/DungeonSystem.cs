using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txtrpg
{
    internal class DungeonSystem
    {

        public static void Dungeon()
        {

            Console.Clear();
            Dialogue.Print("던전입장");
            Dialogue.Print("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();

            Dialogue.Print("1. 고요한 숲속 동굴 (Silent Forest Cave)   |   방어력 3 이상 권장");
            Dialogue.Print("    숲 깊은 곳에 숨겨진 작은 동굴. 내부는 어둡고 습하지만 위협적인 존재는 거의 없다.\n");
            Dialogue.Print("2. 망자의 지하미궁 (Catacombs of the Dead)   |   방어력 15 이상 권장");
            Dialogue.Print("    죽은 자들의 안식처가 뒤틀려 좀비와 망령들이 배회하는 위험한 미궁.\n");
            Dialogue.Print("3. 심연의 성역(Sanctum of the Abyss)   |   방어력 25 이상 권장");
            Dialogue.Print("    아무도 되돌아오지 못한 깊고 끝없는 어둠의 성역.\n");
            Dialogue.Print("0. 돌아가기");

            Dialogue.Print(">> 원하는 행동을 입력해주세요");

            string dungeonchoice = Console.ReadLine(); // 선택을 담는 변수

            switch (dungeonchoice) // 입력에 따라 실행
            {

                case "1":
                    while (true)
                    {
                        if (GameInfo.Health <= 0)
                        {

                            Dialogue.Print("체력이 부족하여 던전에 입장 할 수 없습니다.");
                            Thread.Sleep(2000);
                            Dungeon();
                        }

                        else
                        {

                            Dialogue.Print("고요한 숲속 동굴 (Silent Forest Cave)로 입장하시겠습니까? (Y/N)");

                            string checkindun = Console.ReadLine(); //던전 입장 확인 변수
                            switch (checkindun)
                            {

                                case "Y":
                                case "y":
                                    Dun1();
                                    break;

                                case "N":
                                case "n":
                                    Dungeon();
                                    break;

                                default:
                                    Dialogue.Print("잘못된 입력입니다. 다시 선택해주세요.");
                                    Thread.Sleep(2000);
                                    break;




                            }

                        }



                    }
                    break;


                case "2":
                    while (true)
                    {


                        if (GameInfo.Health <= 0)
                        {

                            Dialogue.Print("체력이 부족하여 던전에 입장 할 수 없습니다.");
                            Thread.Sleep(2000);
                            Dungeon();
                        }

                        else
                        {

                            Dialogue.Print("망자의 지하미궁 (Catacombs of the Dead)으로 입장하시겠습니까? (Y/N)");

                            string checkindun = Console.ReadLine(); //던전 입장 확인 변수
                            switch (checkindun)
                            {

                                case "Y":
                                case "y":
                                    Dun2();
                                    break;

                                case "N":
                                case "n":
                                    Dungeon();
                                    break;

                                default:
                                    Dialogue.Print("잘못된 입력입니다. 다시 선택해주세요.");
                                    Thread.Sleep(2000);
                                    break;




                            }

                        }



                    }
                    break;


                case "3":
                    while (true)

                    {
                        if (GameInfo.Health <= 0)
                        {

                            Dialogue.Print("체력이 부족하여 던전에 입장 할 수 없습니다.");
                            Thread.Sleep(2000);
                            Dungeon();
                        }

                        else
                        {

                            Dialogue.Print("심연의 성역(Sanctum of the Abyss)으로 입장하시겠습니까? (Y/N)");

                            string checkindun = Console.ReadLine(); //던전 입장 확인 변수
                            switch (checkindun)
                            {

                                case "Y":
                                case "y":
                                    Dun3();
                                    break;

                                case "N":
                                case "n":
                                    Dungeon();
                                    break;

                                default:
                                    Dialogue.Print("잘못된 입력입니다. 다시 선택해주세요.");
                                    Thread.Sleep(2000);
                                    break;




                            }

                        }



                    }
                    break;

                case "0":
                    MainMenu.Display();
                    break;
                default:
                    Dialogue.Print("잘못된 입력입니다. 다시 선택해주세요.");
                    Thread.Sleep(2000);
                    Dungeon();
                    break;



            }


        }

        public static void Dun1() //방어력 3 이상 권장
        {
            Console.Clear();

            for (int i = 0; i < 2; i++) //진행중... 출력
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.Clear();
                    Dialogue.Print("던전 진행중" + new string('.', j)); // 
                    Thread.Sleep(500);
                }

            }

            if (GameInfo.Defense < 3) // 권장 방어력보다 낮을때..
            {
                Random rand = new Random();
                int clearchance = rand.Next(0, 100); // 0부터 99 랜덤 배출

                Random rand2 = new Random(); // 성공시 감소할 랜덤 체력
                int use_health = rand.Next(20 - ((int)GameInfo.Defense - 3), 36 - ((int)GameInfo.Defense - 3)); // 권장 방어력 +- 에 따라 종료시 체력 소모 반영
                //근데 방어력이 겁나 높아서 숫자가 음수가 되면?

                if (use_health < 0)
                {

                    use_health = 0;
                }
                // 체력 소모가 안되게 설정
                Random rand3 = new Random();

                int cleargold = rand.Next((1000 + 1000 * (int)(GameInfo.Attack) / 100), 1000 + 1000 * 2 * (int)(GameInfo.Attack) / 100); //클리어 골드 공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능
                Random rand4 = new Random(); //클리어 경험치

                int clearexp = rand.Next((10 + 10 * (int)(GameInfo.Attack) / 100), 10 + 10 * 2 * (int)(GameInfo.Attack) / 100); //클리어 경험치공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능


                if (clearchance < 40)  // 0~39 (총 40)이므로 40프로
                {
                    string[] failMessages =  // 랜덤 메시지
                    {
                    "던전 도중 함정에 빠졌습니다...",
                    "갑작스러운 몬스터의 습격에 당했습니다!",
                    "길을 잃고 탈출하지 못했습니다...",
                    "바닥이 무너져 버렸습니다!",
                    "덫을 피하지 못해 쓰러졌습니다..."
                    };

                    int index = rand.Next(failMessages.Length);
                    Dialogue.Print(failMessages[index]);
                    Thread.Sleep(1000);
                    Dialogue.Print("던전 공략에 실패했습니다.");
                    Dialogue.Print($"현재 체력이 절반으로 감소했습니다 : {GameInfo.Health} => {GameInfo.Health / 2}");
                    GameInfo.Health = GameInfo.Health / 2;
                    Thread.Sleep(1000);
                    Dungeon();
                }

                else
                {

                    string[] successMessages = new string[]
                    {
                    "당신은 모든 몬스터를 물리쳤습니다!",
                    "보스를 처치하고 귀환했습니다!",
                    "던전 깊은 곳의 보물을 손에 넣었습니다!",
                    "마침내 던전의 비밀을 밝혀냈습니다!",
                    "치열한 전투 끝에 살아남았습니다!"
                    };
                    int index = rand.Next(successMessages.Length);
                    Dialogue.Print(successMessages[index]);
                    Thread.Sleep(1000);
                    Dialogue.Print("던전 공략에 성공했습니다!");
                    Console.WriteLine();
                    Dialogue.Print("결과");
                    if (use_health <= GameInfo.Health)
                    {

                        Dialogue.Print($"체력이 {use_health}만큼 감소합니다 {GameInfo.Health} => {GameInfo.Health - use_health}");
                        GameInfo.Health -= use_health;


                    }
                    else
                    {
                        GameInfo.Health = 0;
                        Dialogue.Print($"체력이 0이 됐습니다...");


                    }

                    Dialogue.Print($"{cleargold} 골드를 획득했습니다 {GameInfo.PlayerGold}G => {GameInfo.PlayerGold + cleargold}G");
                    Dialogue.Print($"{clearexp} 경험치를 획득했습니다 {GameInfo.EXP}% => {GameInfo.EXP + clearexp}%");

                    GameInfo.PlayerGold += cleargold;
                    GameInfo.EXP += clearexp;
                    LevelSystem.LevelUP();


                }



            }

            else
            {
                Random rand = new Random();
                int clearchance = rand.Next(0, 100); // 0부터 99 랜덤 배출

                Random rand2 = new Random(); // 성공시 감소할 랜덤 체력
                int use_health = rand.Next(20 - ((int)GameInfo.Defense - 3), 36 - ((int)GameInfo.Defense - 3)); // 권장 방어력 +- 에 따라 종료시 체력 소모 반영
                //근데 방어력이 겁나 높아서 숫자가 음수가 되면?

                if (use_health < 0)
                {

                    use_health = 0;
                }
                // 체력 소모가 안되게 설정
                Random rand3 = new Random();

                int cleargold = rand.Next((1000 + 1000 * (int)(GameInfo.Attack) / 100), 1000 + 1000 * 2 * (int)(GameInfo.Attack) / 100); //클리어 골드 공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능
                Random rand4 = new Random(); //클리어 경험치

                int clearexp = rand.Next((10 + 10 * (int)(GameInfo.Attack) / 100), 10 + 10 * 2 * (int)(GameInfo.Attack) / 100); //클리어 경험치공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능



                string[] successMessages = new string[]
                    {
                    "당신은 모든 몬스터를 물리쳤습니다!",
                    "보스를 처치하고 귀환했습니다!",
                    "던전 깊은 곳의 보물을 손에 넣었습니다!",
                    "마침내 던전의 비밀을 밝혀냈습니다!",
                    "치열한 전투 끝에 살아남았습니다!"
                    };
                int index = rand.Next(successMessages.Length);
                Dialogue.Print(successMessages[index]);
                Thread.Sleep(1000);
                Dialogue.Print("던전 공략에 성공했습니다!");
                Console.WriteLine();

                Dialogue.Print("결과");
                if (use_health <= GameInfo.Health)
                {

                    Dialogue.Print($"체력이 {use_health}만큼 감소합니다 {GameInfo.Health} => {GameInfo.Health - use_health}");
                    GameInfo.Health -= use_health;


                }
                else
                {
                    GameInfo.Health = 0;
                    Dialogue.Print($"체력이 0이 됐습니다...");


                }

                Dialogue.Print($"{cleargold} 골드를 획득했습니다 {GameInfo.PlayerGold}G => {GameInfo.PlayerGold + cleargold}G");
                Dialogue.Print($"{clearexp} 경험치를 획득했습니다 {GameInfo.EXP}% => {GameInfo.EXP + clearexp}%");

                GameInfo.PlayerGold += cleargold;
                GameInfo.EXP += clearexp;
                LevelSystem.LevelUP();



            }






        }

        public static void Dun2() //방어력 15 이상 권장
        {
            Console.Clear();

            for (int i = 0; i < 2; i++) //진행중... 출력
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.Clear();
                    Dialogue.Print("던전 진행중" + new string('.', j)); // 
                    Thread.Sleep(500);
                }

            }

            if (GameInfo.Defense < 15) // 권장 방어력보다 낮을때..
            {
                Random rand = new Random();
                int clearchance = rand.Next(0, 100); // 0부터 99 랜덤 배출

                Random rand2 = new Random(); // 성공시 감소할 랜덤 체력
                int use_health = rand.Next(20 - ((int)GameInfo.Defense - 15), 36 - ((int)GameInfo.Defense - 15)); // 권장 방어력 +- 에 따라 종료시 체력 소모 반영
                //근데 방어력이 겁나 높아서 숫자가 음수가 되면?

                if (use_health < 0)
                {

                    use_health = 0;
                }
                // 체력 소모가 안되게 설정
                Random rand3 = new Random();

                int cleargold = rand.Next((2000 + 2000 * (int)(GameInfo.Attack) / 100), 2000 + 2000 * 2 * (int)(GameInfo.Attack) / 100); //클리어 골드 공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능
                Random rand4 = new Random(); //클리어 경험치

                int clearexp = rand.Next((20 + 20 * (int)(GameInfo.Attack) / 100), 20 + 20 * 2 * (int)(GameInfo.Attack) / 100); //클리어 경험치공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능


                if (clearchance < 40)  // 0~39 (총 40)이므로 40프로
                {
                    string[] failMessages =  // 랜덤 메시지
                    {
                    "던전 도중 함정에 빠졌습니다...",
                    "갑작스러운 몬스터의 습격에 당했습니다!",
                    "길을 잃고 탈출하지 못했습니다...",
                    "바닥이 무너져 버렸습니다!",
                    "덫을 피하지 못해 쓰러졌습니다..."
                    };

                    int index = rand.Next(failMessages.Length);
                    Dialogue.Print(failMessages[index]);
                    Thread.Sleep(1000);
                    Dialogue.Print("던전 공략에 실패했습니다.");
                    Dialogue.Print($"현재 체력이 절반으로 감소했습니다 : {GameInfo.Health} => {GameInfo.Health / 2}");
                    GameInfo.Health = GameInfo.Health / 2;
                    Thread.Sleep(1000);
                    Dungeon();
                }

                else
                {

                    string[] successMessages = new string[]
                    {
                    "당신은 모든 몬스터를 물리쳤습니다!",
                    "보스를 처치하고 귀환했습니다!",
                    "던전 깊은 곳의 보물을 손에 넣었습니다!",
                    "마침내 던전의 비밀을 밝혀냈습니다!",
                    "치열한 전투 끝에 살아남았습니다!"
                    };
                    int index = rand.Next(successMessages.Length);
                    Dialogue.Print(successMessages[index]);
                    Thread.Sleep(1000);
                    Dialogue.Print("던전 공략에 성공했습니다!");
                    Console.WriteLine();

                    Dialogue.Print("결과");
                    if (use_health <= GameInfo.Health)
                    {

                        Dialogue.Print($"체력이 {use_health}만큼 감소합니다 {GameInfo.Health} => {GameInfo.Health - use_health}");
                        GameInfo.Health -= use_health;


                    }
                    else
                    {
                        GameInfo.Health = 0;
                        Dialogue.Print($"체력이 0이 됐습니다...");


                    }

                    Dialogue.Print($"{cleargold} 골드를 획득했습니다 {GameInfo.PlayerGold}G => {GameInfo.PlayerGold + cleargold}G");
                    Dialogue.Print($"{clearexp} 경험치를 획득했습니다 {GameInfo.EXP}% => {GameInfo.EXP + clearexp}%");

                    GameInfo.PlayerGold += cleargold;
                    GameInfo.EXP += clearexp;
                    LevelSystem.LevelUP();


                }



            }

            else
            {
                Random rand = new Random();
                int clearchance = rand.Next(0, 100); // 0부터 99 랜덤 배출

                Random rand2 = new Random(); // 성공시 감소할 랜덤 체력
                int use_health = rand.Next(20 - ((int)GameInfo.Defense - 15), 36 - ((int)GameInfo.Defense - 15)); // 권장 방어력 +- 에 따라 종료시 체력 소모 반영
                //근데 방어력이 겁나 높아서 숫자가 음수가 되면?

                if (use_health < 0)
                {

                    use_health = 0;
                }
                // 체력 소모가 안되게 설정
                Random rand3 = new Random();

                int cleargold = rand.Next((2000 + 2000 * (int)(GameInfo.Attack) / 100), 2000 + 2000 * 2 * (int)(GameInfo.Attack) / 100); //클리어 골드 공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능
                Random rand4 = new Random(); //클리어 경험치

                int clearexp = rand.Next((20 + 20 * (int)(GameInfo.Attack) / 100), 20 + 20 * 2 * (int)(GameInfo.Attack) / 100); //클리어 경험치공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능



                string[] successMessages = new string[]
                    {
                    "당신은 모든 몬스터를 물리쳤습니다!",
                    "보스를 처치하고 귀환했습니다!",
                    "던전 깊은 곳의 보물을 손에 넣었습니다!",
                    "마침내 던전의 비밀을 밝혀냈습니다!",
                    "치열한 전투 끝에 살아남았습니다!"
                    };
                int index = rand.Next(successMessages.Length);
                Dialogue.Print(successMessages[index]);
                Thread.Sleep(1000);
                Dialogue.Print("던전 공략에 성공했습니다!");
                Console.WriteLine();

                Dialogue.Print("결과");
                if (use_health <= GameInfo.Health)
                {

                    Dialogue.Print($"체력이 {use_health}만큼 감소합니다 {GameInfo.Health} => {GameInfo.Health - use_health}");
                    GameInfo.Health -= use_health;


                }
                else
                {
                    GameInfo.Health = 0;
                    Dialogue.Print($"체력이 0이 됐습니다...");


                }

                Dialogue.Print($"{cleargold} 골드를 획득했습니다 {GameInfo.PlayerGold}G => {GameInfo.PlayerGold + cleargold}G");
                Dialogue.Print($"{clearexp} 경험치를 획득했습니다 {GameInfo.EXP}% => {GameInfo.EXP + clearexp}%");

                GameInfo.PlayerGold += cleargold;
                GameInfo.EXP += clearexp;
                LevelSystem.LevelUP();



            }






        }


        public static void Dun3() //방어력 25 이상 권장
        {
            Console.Clear();

            for (int i = 0; i < 2; i++) //진행중... 출력
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.Clear();
                    Dialogue.Print("던전 진행중" + new string('.', j)); // 
                    Thread.Sleep(500);
                }

            }

            if (GameInfo.Defense < 25) // 권장 방어력보다 낮을때..
            {
                Random rand = new Random();
                int clearchance = rand.Next(0, 100); // 0부터 99 랜덤 배출

                Random rand2 = new Random(); // 성공시 감소할 랜덤 체력
                int use_health = rand.Next(20 - ((int)GameInfo.Defense - 25), 36 - ((int)GameInfo.Defense - 25)); // 권장 방어력 +- 에 따라 종료시 체력 소모 반영
                                                                                                                  //근데 방어력이 겁나 높아서 숫자가 음수가 되면?
                if (use_health < 0)
                {

                    use_health = 0;
                }

                // 체력 소모가 안되게 설정
                Random rand3 = new Random();

                int cleargold = rand.Next((3000 + 3000 * (int)(GameInfo.Attack) / 100), 3000 + 3000 * 2 * (int)(GameInfo.Attack) / 100); //클리어 골드 공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능
                Random rand4 = new Random(); //클리어 경험치

                int clearexp = rand.Next((30 + 30 * (int)(GameInfo.Attack) / 100), 30 + 30 * 2 * (int)(GameInfo.Attack) / 100); //클리어 경험치공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능


                if (clearchance < 40)  // 0~39 (총 40)이므로 40프로
                {
                    string[] failMessages =  // 랜덤 메시지
                    {
                    "던전 도중 함정에 빠졌습니다...",
                    "갑작스러운 몬스터의 습격에 당했습니다!",
                    "길을 잃고 탈출하지 못했습니다...",
                    "바닥이 무너져 버렸습니다!",
                    "덫을 피하지 못해 쓰러졌습니다..."
                    };

                    int index = rand.Next(failMessages.Length);
                    Dialogue.Print(failMessages[index]);
                    Thread.Sleep(1000);
                    Dialogue.Print("던전 공략에 실패했습니다.");
                    Dialogue.Print($"현재 체력이 절반으로 감소했습니다 : {GameInfo.Health} => {GameInfo.Health / 2}");
                    GameInfo.Health = GameInfo.Health / 2;
                    Thread.Sleep(1000);
                    Dungeon();
                }

                else
                {

                    string[] successMessages = new string[]
                    {
                    "당신은 모든 몬스터를 물리쳤습니다!",
                    "보스를 처치하고 귀환했습니다!",
                    "던전 깊은 곳의 보물을 손에 넣었습니다!",
                    "마침내 던전의 비밀을 밝혀냈습니다!",
                    "치열한 전투 끝에 살아남았습니다!"
                    };
                    int index = rand.Next(successMessages.Length);
                    Dialogue.Print(successMessages[index]);
                    Thread.Sleep(1000);
                    Dialogue.Print("던전 공략에 성공했습니다!");
                    Console.WriteLine();

                    Dialogue.Print("결과");
                    if (use_health <= GameInfo.Health)
                    {

                        Dialogue.Print($"체력이 {use_health}만큼 감소합니다 {GameInfo.Health} => {GameInfo.Health - use_health}");
                        GameInfo.Health -= use_health;


                    }
                    else
                    {
                        GameInfo.Health = 0;
                        Dialogue.Print($"체력이 0이 됐습니다...");


                    }

                    Dialogue.Print($"{cleargold} 골드를 획득했습니다 {GameInfo.PlayerGold}G => {GameInfo.PlayerGold + cleargold}G");
                    Dialogue.Print($"{clearexp} 경험치를 획득했습니다 {GameInfo.EXP}% => {GameInfo.EXP + clearexp}%");

                    GameInfo.PlayerGold += cleargold;
                    GameInfo.EXP += clearexp;
                    LevelSystem.LevelUP();


                }



            }

            else
            {
                Random rand = new Random();
                int clearchance = rand.Next(0, 100); // 0부터 99 랜덤 배출

                Random rand2 = new Random(); // 성공시 감소할 랜덤 체력
                int use_health = rand.Next(20 - ((int)GameInfo.Defense - 25), 36 - ((int)GameInfo.Defense - 25)); // 권장 방어력 +- 에 따라 종료시 체력 소모 반영
                //근데 방어력이 겁나 높아서 숫자가 음수가 되면?

                if (use_health < 0)
                {

                    use_health = 0;
                }
                // 체력 소모가 안되게 설정
                Random rand3 = new Random();

                int cleargold = rand.Next((3000 + 3000 * (int)(GameInfo.Attack) / 100), 3000 + 3000 * 2 * (int)(GameInfo.Attack) / 100); //클리어 골드 공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능
                Random rand4 = new Random(); //클리어 경험치

                int clearexp = rand.Next((30 + 30 * (int)(GameInfo.Attack) / 100), 30 + 30 * 2 * (int)(GameInfo.Attack) / 100); //클리어 경험치공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능



                string[] successMessages = new string[]
                    {
                    "당신은 모든 몬스터를 물리쳤습니다!",
                    "보스를 처치하고 귀환했습니다!",
                    "던전 깊은 곳의 보물을 손에 넣었습니다!",
                    "마침내 던전의 비밀을 밝혀냈습니다!",
                    "치열한 전투 끝에 살아남았습니다!"
                    };
                int index = rand.Next(successMessages.Length);
                Dialogue.Print(successMessages[index]);
                Thread.Sleep(1000);
                Dialogue.Print("던전 공략에 성공했습니다!");
                Console.WriteLine();

                Dialogue.Print("결과");
                if (use_health <= GameInfo.Health)
                {

                    Dialogue.Print($"체력이 {use_health}만큼 감소합니다 {GameInfo.Health} => {GameInfo.Health - use_health}");
                    GameInfo.Health -= use_health;


                }
                else
                {
                    GameInfo.Health = 0;
                    Dialogue.Print($"체력이 0이 됐습니다...");


                }

                Dialogue.Print($"{cleargold} 골드를 획득했습니다 {GameInfo.PlayerGold}G => {GameInfo.PlayerGold + cleargold}G");
                Dialogue.Print($"{clearexp} 경험치를 획득했습니다 {GameInfo.EXP}% => {GameInfo.EXP + clearexp}%");

                GameInfo.PlayerGold += cleargold;
                GameInfo.EXP += clearexp;
                LevelSystem.LevelUP();



            }






        }

    }
}
