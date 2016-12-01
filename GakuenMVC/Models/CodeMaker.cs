using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DLLGakuen.Entity;

namespace GakuenMVC.Models
{

    public class CodeMaker
    {
        static Random random = new Random();
        static IDictionary<string, OrderList> dict = new Dictionary<string, OrderList>();
        public static OrderList ORL;

        public CodeMaker(OrderList ORLImpirt)
        {
            ORL = ORLImpirt;
            while (true)
            {
                getOrderList("here shall code be");
                CreaterCode();

            }
        }
        private OrderList getOrderList(string Code)
        {
            return dict[Code];
        }
        private static void CreaterCode()
        {
            string Key = KeyMaker();
            if (dict.ContainsKey(Key) == false)
            {
                dict.Add(Key, ORL);
            }

        }
        private static string KeyMaker()
        {
            string OneCode = ($"{GetLetter()} {GetLetter()} {GetLetter()} {GetLetter()} {GetLetter()} {GetLetter()}");
            return OneCode;
        }
        private static char GetLetter()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ
            int num = random.Next(0, chars.Length);
            return chars[num];

        }//makes a random leter
    }
}