using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_LMJ
{
    class Player
    {
        private static Player instance;

        public static Player Instance
        {
            get
            {
                if (instance == null)
                    instance = new Player();

                return instance;
            }
        }

        public int level;
        public string name;
        public int attackPoint;
        public int defencePoint;
        public int healthPoint;
        public int gold;

        public int[] bag = new int[7]{0,0,0,0,0,0,0 };

        enum inInven
        {
            EquipItem = 1,
            GetOut = 2
        }


        public void Install(int search)
        {
            int code = bag[search];
            if (ItemManager.tem.Box.TryGetValue(code, out var item))
            {
                if (!item.isEquip)
                {
                    item.isEquip = true;
                    attackPoint += item.atk;
                    defencePoint += item.def;
                    item.mark = "[E]";
                    Console.WriteLine("장착");
                }
                else if (item.isEquip)
                {
                    item.isEquip = false;
                    attackPoint -= item.atk;
                    defencePoint -= item.def;
                    item.mark = "";
                    Console.WriteLine("장착해제");
                }

            }
            else
            {
                Console.WriteLine("\n그런 장비는 없어요.");
            }

        }

        public static void ChoiceItem(bool isChoice)
        {
            while (isChoice)
            {
                Console.Write($"\n7.나가기\n\n" +
                    $"장착하실 장비를 선택해주세요:");

                bool isGood = int.TryParse(Console.ReadLine(), out int answer);
                if (!isGood || 0 >= answer || answer > 7)
                {
                    Console.Clear();
                    continue;
                }

                if (answer == 7)
                {
                    isChoice = false;
                    Console.Clear();
                    Player.instance.EnterInven(true);
                }
                else if (answer > 0 &&  answer < 7) 
                {
                    Player.instance.Install(answer);
                    Console.Clear();
                    ItemManager.tem.ShowItem();

                }
            }
        }

        public void EnterInven(bool returnToMainMenu)
        {
            bool isMainMenu = returnToMainMenu;
            bool hasEquip = false;

            while (isMainMenu)
            {
                Console.WriteLine();
                if (!hasEquip)
                {
                    ItemManager.tem.ShowItem();
                    Console.Write($"1.아이템 장착\n" +
                                  $"2.나가기\n\n" +
                                  $"원하시는 행동을 선택해주세요:");


                }
                bool isGood = int.TryParse(Console.ReadLine(), out int answer);
                if (!isGood || 0 >= answer || answer > 2)
                {
                    Console.Clear();
                    Console.WriteLine("제대로 입력해주세요.\n");
                    continue;
                }
                
                inInven nowinven = (inInven)answer;
                switch (nowinven)
                {
                    case inInven.EquipItem:
                        Console.Clear();
                        //ItemManager.tem.ShowItem(1);
                        //BuyItem(true);
                        ChoiceItem(true);
                        hasEquip = true;
                        break;
                        
                    case inInven.GetOut:
                        Console.Clear();
                        isMainMenu = false;
                        GameManager.Game.SelectMenu(true);
                        break;

                }
            }
        }

/*        public static void EnterShop(bool returnToMainMenu)
        {
            bool isMainMenu = returnToMainMenu;
            bool hasSelect = false;

            while (isMainMenu)
            {
                Console.WriteLine();
                if (!hasSelect)
                {
                    ShowShop(null);
                    Console.Write($"1.아이템 구매\n" +
                                  $"2.나가기\n\n" +
                                  $"원하시는 행동을 선택해주세요:");


                }

                bool isGood = int.TryParse(Console.ReadLine(), out int answer);
                if (!isGood || 0 >= answer || answer > 2)
                {
                    Console.Clear();
                    Console.WriteLine("제대로 입력해주세요.\n");
                    continue;
                }

                Shop selectedShop = (Shop)answer;

                switch (selectedShop)
                {
                    case Shop.BuyItem:
                        Console.Clear();
                        ShowShop(1);
                        BuyItem(true);
                        hasSelect = true;
                        break;

                    case Shop.BackToMenu:
                        Console.Clear();
                        isMainMenu = false;
                        GameManager.Game.SelectMenu(true);
                        break;

                }
            }
        }*/
    }


}
