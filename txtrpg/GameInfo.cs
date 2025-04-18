using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txtrpg
{
    internal class GameInfo
    {
        public static int PlayerLevel =1; //캐릭터 레벨
        public static string PlayerName; // 캐릭터 이름
        public static string PlayerClass; // 캐릭터 직업
        public static List<Item> inventory = new List<Item>();// 인벤토리
        public static double Attack; // 캐릭터 공격력
        public static double Defense; // 캐릭터 방어력
        public static double Health; // 캐릭터 체력
        public static double PlayerGold = 10000; // 캐릭터 골드
        public static double ItemGoold;
        public static List<Item> shop = new List<Item>();// 상점
        public static int EXP = 0; //경험치

       
        
    }




}
