using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_LMJ
{
    

    public static class ShopManager
    {
        

        private enum Shop
        {
            BuyItem = 1,
            BackToMenu
        }

        public static void ShowShop(int? num)
        {
            Console.WriteLine($"[상점]\n" +
                $"[보유골드]\n" +
                $"{Player.Instance.gold} G\n");

            Console.WriteLine($"[아이템 목록]\n" +
                              $"- {num} 수련자 갑옷\t|  방어력 +5\t|  수련에 도움을 주는 갑옷입니다.\t\t\t\t|{GameManager.Game.isSoled[1]}\n" +
                              $"- {num +1} 무쇠 갑옷\t|  방어력 +9\t|  무쇠로 만들어져 튼튼한 갑옷입니다.\t\t\t\t|{GameManager.Game.isSoled[2]}\n" +
                              $"- {num +2} 스파르타갑옷 |  방어력 +15\t|  스파르타의 전사들이 사용했다는 전설의 갑옷입니다.\t\t|{GameManager.Game.isSoled[3]}\n" +
                              $"- {num +3} 낡은 검\t|  공격력 +2\t|  쉽게 볼 수 있는 낡은 검 입니다.\t\t\t\t|{GameManager.Game.isSoled[4]}\n" +
                              $"- {num +4} 청동 도끼\t|  공격력 +5\t|  어디선가 사용됐던거 같은 도끼입니다.\t\t\t\t|{GameManager.Game.isSoled[5]}\n" +
                              $"- {num +5} 스파르타창\t|  공격력 +7\t|  스파르타의 전사들이 사용했다는 전설의 창입니다.\t\t|{GameManager.Game.isSoled[6]}\n");


        }

        public static int BuyItem(bool isBuy)
        {
            while ( isBuy )
            {
                Console.Write($"\n7.나가기\n\n" +
                    $"구매하실 아이템을 선택해주세요:");

                bool isGood = int.TryParse(Console.ReadLine(), out int answer);
                if (!isGood || 0 >= answer || answer > 7)
                {
                    Console.Clear();
                    Console.WriteLine("제대로 입력해주세요.\n");
                    continue;
                }

                if (answer == 7)
                {
                    isBuy = false;
                    Console.Clear();
                    EnterShop(true);
                }
                else
                {
                    bool checkItem = SoldItem(answer);

                }
            }
            return 0;
        }


        public static void EnterShop(bool returnToMainMenu)
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
        }

        public static bool SoldItem(int itemNum)
        {
            int test1;
            int[] price = new int[7] { 0, 1000, 2000, 3500, 600, 1500, 3000 };
            
            if (Player.Instance.gold <  price[itemNum])
            {
                Console.WriteLine($"\n{price[itemNum] - Player.Instance.gold}G 가 부족합니다.");
                return false;
            }
            else
            {
                GameManager.Game.ShopItem.Remove(itemNum);
                
                if((test1 = GameManager.Game.ShopItem.IndexOf(itemNum)) == -1)
                {
                    Player.Instance.gold -= price[itemNum];
                    
                    Console.WriteLine($"\n{itemNum}번 아이템을 구매하셨습니다.");

                    //ItemManager.tem.AddItem(GameManager.Game.isSoled[itemNum]);
                    Player.Instance.bag[itemNum] = itemNum;
                    GameManager.Game.isSoled[itemNum] = "구매완료";
                    Console.Clear();
                    ShowShop(1);
                }
               
                return true;
            }
        }

    }
}


