using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TextRPG_LMJ;

namespace TextRPG_LMJ
{
    public class ItemTemplit
    {
        public int code;
        public string name;
        public int atk;
        public int def;
        public string text;
        public bool isEquip;
        public string mark;

        public void Print()
        {
            Console.WriteLine($"-{mark} {name}\t |공격력 +{atk}\t |방어력 +{def}\t |{text}");
        }
    }
    


    class ItemManager
    {
        private static ItemManager _tem;

        public static ItemManager tem
        {
            get
            {
                if(_tem == null)
                    _tem = new ItemManager();
                return _tem;
            }
        }




        public Dictionary<int, ItemTemplit> Box = new Dictionary<int, ItemTemplit>();


        public void AddItem()
        {

            Box.Add(1, new ItemTemplit
            {
                name = "수련자 갑옷",
                atk = 0,
                def = 5,
                text = "수련에 도움을 주는 갑옷입니다.",
                isEquip = false,
                mark = ""

            });
            Box.Add(2, new ItemTemplit
            {
                name = "무쇠 갑옷",
                atk = 0,
                def = 9,
                text = "무쇠로 만들어져 튼튼한 갑옷입니다.",
                isEquip = false,
                mark = ""
            });
            Box.Add(3, new ItemTemplit
            {
                name = "스파르타갑옷",
                atk = 0,
                def = 15,
                text = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                isEquip = false,
                mark = ""
            });
            Box.Add(4, new ItemTemplit
            {
                name = "낡은 검",
                atk = 2,
                def = 0,
                text = "쉽게 볼 수 있는 낡은 검 입니다.",
                isEquip = false,
                mark = ""
            });
            Box.Add(5, new ItemTemplit
            {
                name = "청동 도끼",
                atk = 5,
                def = 0,
                text = "어디선가 사용됐던거 같은 도끼입니다.",
                isEquip = false,
                mark = ""
            });
            Box.Add(6, new ItemTemplit
            {
                name = "스파르타창",
                atk = 7,
                def = 0,
                text = "스파르타의 전사들이 사용했다는 전설의 창입니다.",
                isEquip = false,
                mark = ""
            });
        }

        
        public void ShowItem()
        {
            for (int i = 1; i < Player.Instance.bag.Length; i++)
            {
                int code = Player.Instance.bag[i];
                if (Box.TryGetValue(code, out var item))
                {
                    item.Print();
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }




    }

}
