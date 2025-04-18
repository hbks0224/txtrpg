using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace txtrpg
{
    internal class MainMenu
    {

        public static void Display() //메인메뉴
        {
            string displaychoice; // 선택 숫자를 담는 변수명
            Console.Clear(); // 화면 깨끗하게
            Console.OutputEncoding = Encoding.UTF8; // 이모지, 한글 깨짐 방지

            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║        🏰 스파르타 마을에 오신 걸 환영합니다! 🏰   ║");
            Console.WriteLine("╠════════════════════════════════════════════════════╣");
            Console.WriteLine("║ 이곳에서 던전에 들어가기 전 활동을 할 수 있습니다. ║");
            Console.WriteLine("╠════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                    ║");
            Console.WriteLine("║   [1] 상태 보기     [2] 인벤토리     [3] 상점      ║");
            Console.WriteLine("║                                                    ║");
            Console.WriteLine("║   [4] 휴식하기      [5] 던전입장                   ║");
            Console.WriteLine("║                                                    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝\n");
            Dialogue.Print(">> 원하는 행동을 입력해주세요");


            displaychoice = Console.ReadLine();

            switch (displaychoice) // 입력에 따라 실행
            {

                case "1":
                    Show_Status();
                    break;
                case "2":
                    Show_Inventory();
                    break;

                case "3":
                    Show_Shop();
                    break;
                case "4":
                    Rest();
                    break;
                case "5":
                    DungeonSystem.Dungeon();
                    break;

                default:
                    Dialogue.Print("잘못된 입력입니다. 다시 선택해주세요.");
                    Thread.Sleep(2000);
                    Display();
                    break;



            }
        }

        public static void Show_Status() // 상태창
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Thread.Sleep(40);
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Thread.Sleep(40);

            Console.WriteLine("Lv. ({0})", GameInfo.PlayerLevel.ToString("D2")); // 레벨이 1이면 1이 출력이 아니라 01로 출력되게 
            Console.WriteLine("경험치 {0}%",GameInfo.EXP);
            Thread.Sleep(40);

            Console.WriteLine("{0} ({1})", GameInfo.PlayerName, GameInfo.PlayerClass);
            Thread.Sleep(40);

            Console.WriteLine("공격력 {0}", GameInfo.Attack);
            Thread.Sleep(40);

            Console.WriteLine("방어력 {0}", GameInfo.Defense);
            Thread.Sleep(40);

            Console.WriteLine("체 력 {0}", GameInfo.Health);
            Thread.Sleep(40);

            Console.WriteLine("Gold {0} G\n", GameInfo.PlayerGold);
            Thread.Sleep(40);



            Dialogue.Print("0. 나가기\n");
            Dialogue.Print("원하는 행동을 입력해주세요\n");
            Dialogue.Print(">>");
            string Status_choice = Console.ReadLine();

            switch (Status_choice)
            {
                case "0":

                    Display();
                    break;

                default:
                    Dialogue.Print("잘못된 입력입니다. 다시 선택해주세요.");
                    Thread.Sleep(2000);
                    Show_Status();
                    break;






            }




        }

        public static void Show_Inventory() //인벤
        {
            Console.Clear();
            Dialogue.Print("인벤토리");
            Dialogue.Print("보유 중인 아이템을 관리할 수 있습니다.\n");
            Dialogue.Print("[아이템 목록]\n");




            if (GameInfo.inventory.Count == 0)
            {

                Dialogue.Print("인벤토리에 아이템이 없습니다.\n");

            }
            else
            {
                int i = 1;

                foreach (Item item in GameInfo.inventory)
                {
                    string equippedMark = item.IsEquipped ? "[E]" : "   ";
                    Dialogue.Print($"-{i}{equippedMark}{item.Item_name} | {item.Getstat()} | {item.Item_info}");
                    i++;
                }

            }


            string inventory_choice;
            Dialogue.Print("1. 장착 관리");
            Dialogue.Print("0. 나가기\n");
            Dialogue.Print(">> 원하는 행동을 입력해주세요");
            inventory_choice = Console.ReadLine();


            switch (inventory_choice)

            {
                case "1": // 인벤토리에 아무것도 없는데 1 선택시
                    if (GameInfo.inventory == null || GameInfo.inventory.Count == 0)
                    {
                        Console.Clear();

                        Dialogue.Print("보유 중인 아이템이 없습니다.");

                        Thread.Sleep(2000);


                        Show_Inventory();


                    }
                    else // 인벤토리에 뭔가가 있을때 1 선택시
                    {
                        Console.Clear();
                        Dialogue.Print("인벤토리 - 장착 관리");
                        Dialogue.Print("보유 중인 아이템을 관리할 수 있습니다.\n");
                        Dialogue.Print("[아이템 목록]\n");
                        int i = 1;

                        foreach (Item item in GameInfo.inventory)
                        {
                            string equippedMark = item.IsEquipped ? "[E]" : "   ";
                            Dialogue.Print($"-{i}{equippedMark}{item.Item_name} | {item.Getstat()} | {item.Item_info}");
                            i++;
                        }
                        Dialogue.Print($"장착을 원하거나 장착 해제를 원하는 장비의 번호를 입력해주세요. (1 ~ {i - 1})\n");
                        Dialogue.Print("0. 나가기\n");
                        Dialogue.Print(">> 원하는 행동을 입력해주세요");
                        string Equip_Item = Console.ReadLine();

                        if (Equip_Item == "0")
                        {
                            Show_Inventory();

                        }

                        else if (int.TryParse(Equip_Item, out int selectnum)) // 아이템 장착/해제 로직
                        {
                            if (selectnum >= 1 && selectnum <= GameInfo.inventory.Count)

                            {
                                Item selectedItem = GameInfo.inventory[selectnum - 1]; // 입력받은 숫자 -1 번의 리스트 인덱스 저장

                                if (selectedItem.IsEquipped) //아이템이 장착됐다면 장착해제
                                {


                                    selectedItem.Unequip();
                                    Thread.Sleep(500);
                                    Show_Inventory();


                                }
                                else //장착 안됐으면 장착
                                {

                                    selectedItem.Equip();
                                    Thread.Sleep(500);
                                    Show_Inventory();
                                }

                            }


                            else
                            {

                                Dialogue.Print("잘못 입력하셨습니다. 다시 입력해주세요.");
                                Thread.Sleep(2000);
                                Show_Inventory();

                            }
                        }




                    }

                    break;

                case "0": // 돌아가기

                    Display();
                    break;

                default:
                    Dialogue.Print("잘못된 입력입니다. 다시 선택해주세요.");
                    Thread.Sleep(2000);
                    Show_Inventory();
                    break;

            }


            //if (GameInfo.inventory == null && inventory_choice == "1")
            //{
            //    Dialogue.Print("보유 중인 아이템이 없습니다.");

            //    Show_Inventory();

            //}
            //else if (inventory_choice == "0")
            //{
            //    Display();
            //}




        }

        public static void Show_Shop() //상점
        {
            Console.Clear();
            Dialogue.Print("상점\n필요한 아이템을 얻을 수 있는 상점입니다.");
            Dialogue.Print($"[보유 골드]\n{GameInfo.PlayerGold}G");
            Dialogue.Print("[소지중인 아이템 목록]");
            if (GameInfo.inventory.Count == 0)
            {

                Dialogue.Print("인벤토리에 아이템이 없습니다.\n");

            }
            else
            {
                int i = 1;

                foreach (Item item in GameInfo.inventory)
                {
                    string equippedMark = item.IsEquipped ? "[E]" : "   ";
                    Dialogue.Print($"-{i}{equippedMark}{item.Item_name} | {item.Getstat()} | {item.Item_info}");
                    i++;
                }

            }


            Console.WriteLine();
            Dialogue.Print("1. 아이템 구매");
            Dialogue.Print("2. 아이템 판매");
            Dialogue.Print("0. 나가기");

            string shopchoice;
            shopchoice = Console.ReadLine();
            switch (shopchoice)

            {
                case "1":
                    Buy_Item();
                    break;
                case "2":
                    Sell_Item();
                    break;

                case "0":
                    Display();
                    break;

                default:
                    Dialogue.Print("잘못된 입력입니다. 다시 선택해주세요.");
                    Thread.Sleep(2000);
                    Show_Shop();
                    break;



            }






        }

        public static void Buy_Item()
        {
            Console.Clear();
            Dialogue.Print("상점 - 아이템 구매\n필요한 아이템을 얻을 수 있는 상점입니다.");
            Dialogue.Print($"[보유 골드]\n{GameInfo.PlayerGold}G");
            Dialogue.Print("[상점 아이템 목록]");
            int i = 1; //아이템 번호 변수

            if (GameInfo.shop.Count == 0)
            {

                Dialogue.Print("상점에 아이템이 없습니다.\n");

            }
            else
            {


                foreach (Item item in GameInfo.shop)
                {
                    string soldOutMark = GameInfo.inventory.Any(inv => inv.Item_name == item.Item_name) ? "[보유중] " : ""; // 상점에 아이템이 인벤에 존재 할 시 판매완료 처리
                    Dialogue.Print($"-{i} {soldOutMark}{item.Item_name} | {item.Getstat()} | {item.Item_info} | [구매 가격] {item.Item_gold}G");
                    i++;
                }

            }
            Console.WriteLine();
            Dialogue.Print($"구매하고 싶은 장비의 번호를 입력해주세요. (1 ~ {i - 1})");
            Dialogue.Print("0. 나가기");
            Dialogue.Print(">> 원하는 행동을 입력해주세요");

            string Buy_item = Console.ReadLine();

            if (Buy_item == "0")
            {
                Show_Shop();

            }

            else if (int.TryParse(Buy_item, out int selectnum)) // 아이템 구매
            {
                if (selectnum >= 1 && selectnum <= GameInfo.shop.Count)

                {
                    Item bought_Item = GameInfo.shop[selectnum - 1]; // 입력받은 숫자 -1 번의 상점 아이템 가져오기



                    if (true == GameInfo.inventory.Any(item => item.Item_name == bought_Item.Item_name)) // 인벤토리에 구입한 아이템이 있는지 확인하는 함수 있으면 true반환
                    {
                        Dialogue.Print($"이미 {bought_Item.Item_name}을(를) 가지고 있습니다!");
                        Thread.Sleep(2000);
                        Show_Shop();


                    }
                    else // 진짜 살 건지 확인
                    {
                        Dialogue.Print($"정말로 {bought_Item}을 구매하시겠습니까? (Y/N)");
                        string check_buy = Console.ReadLine();
                        switch (check_buy)
                        {
                            case "Y":
                            case "y":

                                if (GameInfo.PlayerGold >= bought_Item.Item_gold) // 골드가 부족하지 않을때 경우
                                {
                                    GameInfo.PlayerGold -= bought_Item.Item_gold;
                                    GameInfo.inventory.Add(bought_Item);
                                    Dialogue.Print($"{bought_Item.Item_name}을(를) 구매했습니다!");
                                    Thread.Sleep(2000);

                                    Show_Shop();
                                    


                                }
                                else
                                {
                                    Dialogue.Print("골드가 부족합니다! 아이템을 구매할 수 없습니다.");
                                    Thread.Sleep(2000);
                                    Show_Shop();
                                }
                                break;


                            case "N":
                            case "n":
                                        Dialogue.Print("구매를 취소했습니다.");
                                        Thread.Sleep(2000);
                                        Show_Shop();
                                        break;

                                    default:
                                        Dialogue.Print("잘못 입력하셨습니다. 다시 시도해주세요.");
                                        Thread.Sleep(2000);
                                        Show_Shop();
                                        break;


                                    }







                    }


                }


                else
                {

                    Dialogue.Print("잘못 입력하셨습니다. 다시 입력해주세요.");
                    Thread.Sleep(2000);
                    Show_Inventory();

                }
            }





        }// 아이템 구매

        public static void Sell_Item() // 아이템 판매
        {
            Console.Clear();
            Dialogue.Print("상점 - 아이템 판매\n아이템을 판매할 수 있는 상점입니다.\n판매시 기존 가격의 85%의 가격으로 판매 할 수 있습니다.");
            Dialogue.Print($"[보유 골드]\n{GameInfo.PlayerGold}G");
            Dialogue.Print("[보유중인 아이템 목록]");
            int i = 1; //아이템 번호 변수

            if (GameInfo.inventory.Count == 0)
            {

                Dialogue.Print("보유중인 아이템이 없습니다.\n");

            }
            else
            {
                

                foreach (Item item in GameInfo.inventory)
                {
                    string equippedMark = item.IsEquipped ? "[E]" : "   ";
                    Dialogue.Print($"-{i}{equippedMark}{item.Item_name} | {item.Getstat()} | {item.Item_info} | [판매 가격] {0.85*item.Item_gold}");
                    i++;
                }

            }

            Console.WriteLine();
            Dialogue.Print($"판매하고 싶은 장비의 번호를 입력해주세요. (1 ~ {i - 1})");
            Dialogue.Print("0. 나가기");
            Dialogue.Print(">> 원하는 행동을 입력해주세요");

            string Sell_item = Console.ReadLine();

            if (Sell_item == "0")
            {
                Show_Shop();


            }

            else if (int.TryParse(Sell_item, out int selectnum)) // 아이템 판매
            {
                if (selectnum >= 1 && selectnum <= GameInfo.inventory.Count)

                {
                    Item Sold_Item = GameInfo.inventory[selectnum - 1]; // 입력받은 숫자 -1 번의 상점 아이템 가져오기



                    if (true == GameInfo.inventory.Any(item => item.Item_name == Sold_Item.Item_name)) // 인벤토리에 구입한 아이템이 있는지 확인하는 함수 있으면 true반환
                    {
                        Dialogue.Print($"정말로 {Sold_Item}을 판매하시겠습니까? (Y/N)");

                        string check_sell = Console.ReadLine();

                        {

                            switch (check_sell)
                            {
                                case "Y":
                                case "y":

                                    {
                                        if(Sold_Item.IsEquipped == true) //장착하고있다면 해제
                                        {

                                            Sold_Item.IsEquipped = false;
                                        }
                                        GameInfo.PlayerGold += 0.85 * Sold_Item.Item_gold;
                                        GameInfo.inventory.Remove(Sold_Item);
                                        Dialogue.Print($"{Sold_Item.Item_name}을(를) 판매했습니다!");
                                        Thread.Sleep(2000);
                                        //GameInfo.shop.Add(Sold_Item);

                                        Sell_Item();

                                        break;


                                    }



                                case "N":
                                case "n":
                                    Dialogue.Print("판매를 취소했습니다.");
                                    Thread.Sleep(2000);
                                    Sell_Item();
                                    break;

                                default:
                                    Dialogue.Print("잘못 입력하셨습니다. 다시 시도해주세요.");
                                    Thread.Sleep(2000);
                                    Sell_Item();
                                    break;


                            }







                        }


                    }


                    else
                    {

                        Dialogue.Print("잘못 입력하셨습니다. 다시 입력해주세요.");
                        Thread.Sleep(2000);
                        Sell_Item();

                    }
                }



            }
                    
                    




        }
        public static void Rest() //휴식하기
        {
            Console.Clear();
            Dialogue.Print("휴식하기");
            Dialogue.Print($"500G을 내면 체력을 회복 할 수 있습니다. (보유 골드 : {GameInfo.PlayerGold}G)");
            Console.WriteLine();

            Dialogue.Print("1. 휴식하기\n0. 나가기");
            Console.WriteLine();
            Dialogue.Print(">> 원하는 행동을 입력해주세요");

            string rest_choice = Console.ReadLine();

            switch (rest_choice)
            {
                case "1":
                    if (GameInfo.PlayerGold < 500)
                    {
                        Dialogue.Print("Gold가 부족합니다.");
                        Thread.Sleep(2000);
                        Rest();

                    }

                    else
                    {
                        if (GameInfo.Health < 100)
                        {
                            GameInfo.PlayerGold -= 500;
                            GameInfo.Health = 100;
                            Dialogue.Print($"휴식을 완료했습니다.\n남은 골드 : {GameInfo.PlayerGold}");
                            Thread.Sleep(2000);
                            Rest();
                            


                        }
                        else
                        {
                            Dialogue.Print("체력이 충분하기 때문에 휴식을 할 수 없습니다.");
                            Thread.Sleep(2000);
                            Rest();

                        }


                    }
                    break;
                case "0":
                    Display();
                    break;

                default:
                    Dialogue.Print("잘못된 입력입니다. 다시 선택해주세요.");
                    Thread.Sleep(2000);
                    Rest();
                    break;

            }







        }



    }
}
