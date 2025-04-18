using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txtrpg
{
    internal class LevelSystem
    {

        public static void LevelUP() //레벨업 관리 함수
        {
            int EXPMAX = 100; // 레벨업에 필요한 경험치

            while (GameInfo.EXP >= EXPMAX) {


                GameInfo.PlayerLevel++;
                GameInfo.Attack += 0.5;
                GameInfo.Defense += 1;
                GameInfo.EXP -= EXPMAX;

                Dialogue.Print($"레벨업! {GameInfo.PlayerLevel - 1}레벨 => {GameInfo.PlayerLevel}레벨");
                
            }

        }
    }
}
