using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using txtrpg;

namespace txtrpg
{

}

public class Item_Stat //아이템 스탯 클래스
{
    public int Attack;
    public int Defense;
    public int Health;

    //묶어서 Item_Stat으로 관리
    public Item_Stat(int attack, int defense, int health)
    {
        Attack = attack;
        Defense = defense;
        Health = health;
    }
}

// 아이템 클래스
internal class Item
{
    public string Item_name;         // 아이템 이름
    public Item_Stat Item_Stat;      // 능력치
    public string Item_info;         // 아이템 설명
    public bool IsEquipped;          // 장착 여부
    public double Item_gold; //아이템가격
    public string Item_type; // 아이템 타입
    public static Item EquippedWeapon = null;     // 현재 착용한 무기
    public static Item EquippedArmor = null;      // 현재 착용한 방어구
    public static Item EquippedAccessory = null;  // 현재 착용한 악세사리

    public Item(string item_name, Item_Stat item_stat, string item_info, bool IsEquipped, double item_gold, string item_type)
    {
        Item_name = item_name;
        Item_Stat = item_stat;
        Item_info = item_info;
        Item_gold = item_gold;
        IsEquipped = false;
        Item_type = item_type;
    }

    public static void Make() // 아이템 생성
    {
        Item test_item1 = new Item("무쇠 갑옷", new Item_Stat(0, 5, 0), "무쇠로 만들어져 튼튼한 갑옷", false,100, "Armor");
        Item test_item2 = new Item("스파르타의 창", new Item_Stat(7, 0, 0), "스파르타의 전사들이 사용했다는 창", false, 100, "Weapon");
        Item test_item3 = new Item("낡은 검", new Item_Stat(2, 0, 0), "쉽게 볼 수 있는 낡은 검", false, 50, "Weapon");

        Item shop_item1 = new Item("전설의 검", new Item_Stat(30, 0, 0), "이게 그 말로만 듣던 전설의..!", false, 1000, "Weapon");
        Item shop_item2 = new Item("미스릴 갑옷", new Item_Stat(0, 13, 0), "미스릴을 사용하여 방어력을 보강한 갑옷", false, 200, "Armor");
        Item shop_item3 = new Item("허름한 망토", new Item_Stat(0, 0, 20), "허름하지만 신체를 보호 할 만큼은 된다.", false, 300, "Accessory");
        Item shop_item4 = new Item("화염 지팡이", new Item_Stat(15, 0, 0), "불의 마법이 깃든 지팡이", false, 500, "Weapon");
        Item shop_item5 = new Item("행운의 부적", new Item_Stat(0, 0, 30), "알 수 없는 힘이 느껴진다", false,500, "Accessory");
        Item shop_item6 = new Item("드래곤 갑옷", new Item_Stat(0, 30, 0), "전설의 용 비늘로 만든 갑옷", false, 700, "Armor");


        //인벤토리 추가
        GameInfo.inventory.Add(test_item1);
        GameInfo.inventory.Add(test_item2);
        GameInfo.inventory.Add(test_item3);
        //상점 추가
        GameInfo.shop.Add(shop_item1);
        GameInfo.shop.Add(shop_item2);
        GameInfo.shop.Add(shop_item3);
        GameInfo.shop.Add(shop_item4);
        GameInfo.shop.Add(shop_item5);
        GameInfo.shop.Add(shop_item6);

    }

    public string Getstat() // 0인 스탯은 제외해서 출력하게 필터 역할 함수
    {
        string realstat = "";

        if (Item_Stat.Attack != 0)
        {
            realstat += $"공격력: {Item_Stat.Attack}";


        }

        if (Item_Stat.Defense != 0)
        {
            realstat += $"방어력: {Item_Stat.Defense}";


        }

        if (Item_Stat.Health != 0)
        {
            realstat += $"체력: {Item_Stat.Health}";


        }


        return realstat;
    }

    //장착
    public  void Equip()
    {
        if (!IsEquipped)
        {
            if (Item_type == "Weapon")
            {
                if (Item.EquippedWeapon != null)
                {
                    Item.EquippedWeapon.Unequip();

                }
                Item.EquippedWeapon = this;

            }
            else if (Item_type == "Armor")
            {
                if (Item.EquippedArmor != null)
                {
                    Item.EquippedArmor.Unequip();

                }
                Item.EquippedArmor = this;

            }
            else if (Item_type == "Accessory")
            {
                if (Item.EquippedAccessory != null)
                {
                    Item.EquippedAccessory.Unequip();

                }
                Item.EquippedAccessory = this;

            }
            GameInfo.Attack += Item_Stat.Attack;
            GameInfo.Defense += Item_Stat.Defense;
            GameInfo.Health += Item_Stat.Health;
            IsEquipped = true;
            Console.WriteLine($"{Item_name}을(를) 장착했습니다!");
        }

    }
    //해제
    public void Unequip()
    {
        if (IsEquipped)
        {
            GameInfo.Attack -= Item_Stat.Attack;
            GameInfo.Defense -= Item_Stat.Defense;
            GameInfo.Health -= Item_Stat.Health;
            //장착 해제
            if (Item.EquippedWeapon == this)
            {
                Item.EquippedWeapon = null;
            }
            if (Item.EquippedAccessory == this)
            {
                Item.EquippedAccessory = null;
            }
            if (Item.EquippedArmor == this)
            {
                Item.EquippedArmor = null;
            }


            IsEquipped = false;


            Console.WriteLine($"{Item_name}을(를) 해제했습니다!");
        }

    }



}





