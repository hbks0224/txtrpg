using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txtrpg
{
    internal class Dialogue
    {
        public static void Print(String message)
        {


            foreach (char c in message) //따라라락 나오게하자
            {
                Console.Write(c);
                Thread.Sleep(15); //기본값 30
            }

            Console.WriteLine();
        }//
    }
}
