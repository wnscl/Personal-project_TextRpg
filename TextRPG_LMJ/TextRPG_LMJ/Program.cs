using System.Net.Sockets;

namespace TextRPG_LMJ
{
    

    class GameManager
    {
        private static GameManager game;

        public static GameManager Game
        {
            get
            {
                if (game == null)
                    game = new GameManager();
                return game;
            }
        }

        public List<int> ShopItem = new List<int>();

        public string[] isSoled = new string[7] { "0", "1000G", "2000G", "3500G", "600G", "1500G", "3000G" };

        public void StockFilling() //상점 재고 채우는 메서드
        {
            ShopItem.Add(1);
            ShopItem.Add(2);
            ShopItem.Add(3);
            ShopItem.Add(4);
            ShopItem.Add(5);
            ShopItem.Add(6);
        }

        enum MainMenu
        {
            LookMyself = 1,
            Inventory,
            GoShop
        }

        public void GameStart()
        {
            Console.WriteLine("안내드립니다.");
            Console.WriteLine("입력이 필요한 상황이라면 (입력:1)");
            Console.WriteLine("이렇게 띄워쓰기 없이 입력해주시면 되겠습니다.");
            Console.WriteLine("\n");
            Console.WriteLine("드리즐폴에 오신 것 환영합니다.");
            Console.WriteLine("\n");

            Player.Instance.level = 1;
            Player.Instance.attackPoint = 10;
            Player.Instance.defencePoint = 5;
            Player.Instance.healthPoint = 100;
            Player.Instance.gold = 100500;
        }

        public void ShowPlayer()
        {
            Console.WriteLine($"Lv. : {Player.Instance.level}");
            Console.WriteLine($"{Player.Instance.name} [인간]");
            Console.WriteLine($"Att : {Player.Instance.attackPoint}");
            Console.WriteLine($"Def : {Player.Instance.defencePoint}");
            Console.WriteLine($"Def : {Player.Instance.healthPoint}");
            Console.WriteLine($"Gold : {Player.Instance.gold}");
            Console.WriteLine($"\n");
        }

        public string ChoiceName() //이름결정 메서드
        {
            bool isOk = false;
            Console.WriteLine("당신의 이름은?");
            Console.Write("원하시는 이름을 입력해주세요: ");
            string input = Console.ReadLine();

            if (input.Any(x => x == ' ') || input == "")
            {
                while (!isOk)
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.Write("다시 이름을 입력해주세요: ");
                    input = Console.ReadLine();
                    if (!input.Any(x => x == ' ') || input == "")
                    {
                        isOk = true;
                    }
                }
            }
            return Player.Instance.name = input;
        }


        static void ShowMenu()
        {
            Console.WriteLine("\n1.상태보기\n" +
                              "2.인벤토리보기\n" +
                              "3.상점가기");
        }

        public void SelectMenu(bool returnToMainMenu)
        {
            bool isMainMenu = returnToMainMenu;

            while (isMainMenu)
            {
                ShowMenu();
                Console.WriteLine();
                Console.Write("원하시는 행동을 선택해주세요:");

                bool isGood = int.TryParse(Console.ReadLine(), out int answer);
                if (!isGood || 0 >= answer || answer > 3)
                {
                    Console.Clear();
                    Console.WriteLine("제대로 입력해주세요.");
                    Console.WriteLine("\n");
                    continue;
                }

                MainMenu selectedMenu = (MainMenu)answer;
                
                switch (selectedMenu)
                {
                    case MainMenu.LookMyself:
                        Console.Clear();
                        GameManager.Game.ShowPlayer();   
                        break;

                    case MainMenu.Inventory:
                        Console.Clear();
                        Player.Instance.EnterInven(true);
                        break;

                    case MainMenu.GoShop:
                        Console.Clear();
                        isMainMenu = false;
                        ShopManager.EnterShop(true);
                        break;
                }
            }
        }
    }


    

    internal class Program
    {
        static void Main(string[] args)
        {

            GameManager.Game.StockFilling(); //상점 재고 채우기
            
            ItemManager.tem.AddItem();

            GameManager.Game.GameStart(); //게임 시작 메세지
            GameManager.Game.ChoiceName(); //이름 선택
            Console.Clear();
            GameManager.Game.SelectMenu(true); //메인메뉴로 이동

            
        }
    }
}
