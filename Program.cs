namespace Sparta_RPG
{
    internal class Program
    {

        class Character
        {
            public string Name { get; set; }
            public string Job { get; set; }
            public int Level { get; set; }
            public int Exp { get; set; }
            public int Att { get; set; }
            public int Def { get; set; }
            public int Hp { get; set; }
            public int Gold { get; set; }
            public int Weapon { get; set; }
            public int Armor { get; set; }
            public List<Weapon> IWeapons { get; set; }
            public List<Armor> IArmors { get; set; }
            public Weapon EWeapon { get; set; }
            public Armor EArmor { get; set; }

            public Character(string name, string job, int level, int exp, int att, int def, int hp, int gold, int weapon, int armor)
            {
                Name = name;
                Job = job;
                Level = level;
                Exp = exp;
                Att = att;
                Def = def;
                Hp = hp;
                Gold = gold;
                Weapon = weapon;
                Armor = armor;
                IWeapons = new List<Weapon>();
                IArmors = new List<Armor>();
            }// 캐릭터 설정

            public void AddStats(string name, string job, int level, int exp, int att, int def, int hp, int gold)
            {
                Name = name;
                Job = job;
                Level += level;
                Exp += exp;
                Att += att;
                Def += def;
                Hp += hp;
                Gold += gold;
            }//스테이터스 조정

            public void EquipWeapon(Weapon weapon)
            {
                EWeapon = weapon;
            }//장차된 무기

            public void EquipArmor(Armor armor)
            {
                EArmor = armor;
            }//장착된 방어구

            public void ChageWeapon()
            {
                Console.WriteLine("\n장착할 무기의 번호를 입력하세요\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int Index) && Index >= 1 && Index <= IWeapons.Count)
                {
                    EquipWeapon(IWeapons[Index - 1]);
                    Console.Clear();
                    Console.WriteLine("\n{0}무기를 변경하였습니다");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n잘못된 입력입니다. 마을로 돌아갑니다.");
                }
            }//무기 변경

            public void ChageAmor()
            {
                Console.WriteLine("\n장착할 방어구의 번호를 입력하세요\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int Index) && Index >= 1 && Index <= IArmors.Count)
                {
                    EquipArmor(IArmors[Index - 1]);
                    Console.Clear();
                    Console.WriteLine("\n방어구를 변경하였습니다");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n잘못된 입력입니다. 마을로 돌아갑니다.");
                }
            }//방어구 변경

            public void ShowStats()
            {
                Console.WriteLine("\n☆ === 플레이어 능력치 === ☆");
                Console.WriteLine("     Level : " + Level + "(" + Exp + "/100)");
                Console.WriteLine("     이름 : " + Name + "(" + Job + ")");
                Console.WriteLine($"     공격력: {Att + (EWeapon?.AttBonus ?? 0)}" + "(" + (EWeapon?.AttBonus ?? 0) + ")");
                Console.WriteLine($"     방어력: {Def + (EArmor?.DefBonus ?? 0)}" + "(" + (EArmor?.DefBonus ?? 0) + ")");
                Console.WriteLine($"     체력 : " + Hp);
                Console.WriteLine($"     소지 골드 : " + Gold + "G");
                Console.WriteLine("☆ ======================= ☆\n");
            }// 스탯 보여주기 ()는 무기 방어구 값 

            public void ShowWeapons()
            {
                Console.WriteLine("무기\n");
                if (IWeapons.Count == 0)
                {
                    Console.WriteLine("보유한 무기가 없습니다\n");
                }
                else
                {
                    for (int i = 0; i < IWeapons.Count; i++)
                    {
                        string EMark = IWeapons[i] == EWeapon ? "[E]" : "";
                        Console.WriteLine($"{EMark} {i + 1}. {IWeapons[i].Name} (공격력 +{IWeapons[i].AttBonus})" + "\n");
                    }
                }
                Console.WriteLine("방어구\n");
                if (IArmors.Count == 0)
                {
                    Console.WriteLine("보유한 방어구가 없습니다");
                }
                else
                {
                    for (int i = 0; i < IArmors.Count; i++)
                    {
                        string EMarker = IArmors[i] == EArmor ? "[E]" : "";
                        Console.WriteLine($"{EMarker} {i + 1}. {IArmors[i].Name} (방어력 +{IArmors[i].DefBonus})");
                    }
                }
            }//무기, 방어구 리스트 보여주기
        }//캐릭터 스텟, 보유 인벤토리 설정

        class Weapon
        {
            public string Name { get; set; }
            public int AttBonus { get; set; }
            public int Price { get; set; }

            public Weapon(string name, int attBonus, int price)
            {
                Name = name;
                AttBonus = attBonus;
                Price = price;
            }
        }//무기 설정

        class Armor
        {
            public string Name { get; set; }
            public int DefBonus { get; set; }
            public int Price { get; set; }

            public Armor(string name, int defBonus, int price)
            {
                Name = name;
                DefBonus = defBonus;
                Price = price;
            }
        }//방어구 설정

        class Shop
        {
            public List<Weapon> Weapons { get; set; }
            public List<Armor> Armors { get; set; }

            public Shop()
            {
                Weapons = new List<Weapon>
                {
                    new Weapon("낡은검", 2, 600),
                    new Weapon("청동도끼", 5, 1500),
                    new Weapon("철검", 8, 2000),
                    new Weapon("강철검", 10, 2500),
                    new Weapon("부러진 직검", -5, 100),
                    new Weapon("이지모드", 1000,100)
                };

                Armors = new List<Armor>
                {
                    new Armor("수련자 갑옷", 3, 250),
                    new Armor("가죽 갑옷", 5, 500),
                    new Armor("강철 갑옷", 10, 1000),
                    new Armor("이모탈",1000,100)
                };
            }//아이템 리스트

            public void BuyItem(Character player)
            {
                int weaponCount = 0;
                Console.WriteLine("스파르타 상점에 오신 것을 환영합니다! 아래의 아이템을 구매할 수 있습니다.");
                Console.WriteLine("\n무기:");

                for (int i = 0; i < Weapons.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Weapons[i].Name} (공격력 +{Weapons[i].AttBonus}, 가격: {Weapons[i].Price}골드)");
                    weaponCount++;
                }

                Console.WriteLine("\n방어구:");
                for (int i = 0; i < Armors.Count; i++)
                {
                    Console.WriteLine($"{i + weaponCount + 1}. {Armors[i].Name} (방어력 +{Armors[i].DefBonus}, 가격: {Armors[i].Price}골드)");
                }

                Console.WriteLine("\n보유골드 : " + player.Gold + "G");
                Console.WriteLine("\n구매하려면 아이템 번호를 입력하세요    0.나가기");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int itemIndex))
                {

                    if (itemIndex >= 1 && itemIndex <= Weapons.Count)
                    {
                        Weapon selectedWeapon = Weapons[itemIndex - 1];
                        if (player.Gold >= selectedWeapon.Price)
                        {
                            player.Gold -= selectedWeapon.Price;
                            player.EquipWeapon(selectedWeapon);
                            player.IWeapons.Add(selectedWeapon);
                            Weapons.RemoveAt(itemIndex - 1);
                            Console.Clear();
                            Console.WriteLine($"\n{selectedWeapon.Name}을(를) 구매했습니다.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n골드가 부족합니다. 마을로 돌아 갑니다.");
                        }
                    }
                    else if (itemIndex >= Weapons.Count + 1 && itemIndex <= Weapons.Count + Armors.Count)
                    {
                        Armor selectedArmor = Armors[itemIndex - Weapons.Count - 1];
                        if (player.Gold >= selectedArmor.Price)
                        {
                            player.Gold -= selectedArmor.Price;
                            player.EquipArmor(selectedArmor);
                            player.IArmors.Add(selectedArmor);
                            Armors.RemoveAt(itemIndex - Weapons.Count - 1);
                            Console.Clear();
                            Console.WriteLine($"\n{selectedArmor.Name}을(를) 구매했습니다.");

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n골드가 부족합니다. 마을로 돌아 갑니다.");
                        }
                    }
                    else if (itemIndex == 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n그런 아이템은 없습니다. 마을로 돌아 갑니다.");
                    }
                }
                else
                {
                    Console.WriteLine("\n그런 아이템은 없습니다. 마을로 돌아 갑니다.");
                }
            }

            public void Sellitem(Character player)
            {
                player.ShowWeapons();
                Console.WriteLine("\n판매하려면 아이템 번호를 입력하세요    0.나가기");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                int input = int.Parse(Console.ReadLine());
                player.IWeapons.RemoveAt(input);
            }
        }// 상점, 무기, 방어구 관련

        static void Main(string[] args) //게임 관련
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "Sparta_RPG";

            Character player = new Character("", "", 0, 0, 0, 0, 0, 0, 0, 0);
            Character monster = new Character("", "", 0, 0, 0, 0, 0, 0, 0, 0);

            bool trueflase = false;



            Shop shop = new Shop();

            string chooseNum;
            string name = "";
            string job = "";
            string[] item = { };


            Console.WriteLine("스파르타 던전 입구 마을에 오신것을 환영합니다.\n");
            Console.WriteLine("이름을 입력하세요\n");

            while (!trueflase)
            {
                name = Console.ReadLine();
                Console.WriteLine("\n" + name + "이(가) 맞습니까?\n1.예    2.아니요\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                chooseNum = Console.ReadLine();
                if (chooseNum == "2")
                {
                    Console.WriteLine("\n이름을 입력하세요\n");
                }
                else if (chooseNum == "1")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n잘못된 입력입니다.\n \n이름을 입력하세요\n");
                }
            }//시작

            while (!trueflase)
            {
                Console.WriteLine("\n직업을 선택하세요\n1.전사    2.도적    3.마법사\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                chooseNum = Console.ReadLine();
                if (chooseNum == "1")
                {
                    job = "전사";
                    //string name, string job, int level, int exp, int att, int def, int hp, int gold 순서
                    player.AddStats(name, job, 1, 0, 10, 5, 100, 1500);
                    Console.Clear();
                    break;
                }

                else if (chooseNum == "2")
                {
                    //string name, string job, int level, int exp, int att, int def, int hp, int gold 순서
                    job = "도적";
                    player.AddStats(name, job, 1, 0, 12, 4, 80, 1500);
                    Console.Clear();
                    break;
                }

                else if (chooseNum == "3")
                {
                    //string name, string job, int level, int exp, int att, int def, int hp, int gold 순서
                    job = "마법사";
                    player.AddStats(name, job, 1, 0, 15, 3, 60, 1500);
                    Console.Clear();
                    break;
                }

                else
                {
                    Console.WriteLine("\n잘못된 입력입니다.");
                }
            } //직업선택

            while (!trueflase)
            {
                Console.WriteLine("\n안녕하세요! 스파르타 던전 입구 마을 입니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
                Console.WriteLine("1.상태 보기    2.인벤토리    3.상점    4.던전    5.회복\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                chooseNum = Console.ReadLine();

                if (player.Exp >= 100)
                {
                    player.Level += 1;
                    player.Exp -= 100;
                    player.Att += 1;
                    player.Def += 1;
                }

                if (chooseNum == "1")
                {
                    Console.Clear();
                    player.ShowStats();
                    Console.WriteLine("0.나가기\n");
                    Console.Write("원하시는 행동을 입력해주세요.\n>>");
                    chooseNum = Console.ReadLine();
                    if (chooseNum == "0")
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n잘못된 입력입니다. 마을로 돌아갑니다.");
                        continue;
                    }
                }// 상태보기

                if (chooseNum == "2")
                {
                    Console.Clear();
                    Console.WriteLine("\n[보유중인 장비]\n");
                    player.ShowWeapons();
                    Console.WriteLine("\n0.나가기    1.무기변경    2.방어구변경\n");
                    Console.Write("원하시는 행동을 입력해주세요.\n>>");
                    chooseNum = Console.ReadLine();
                    if (chooseNum == "1")
                    {
                        player.ChageWeapon();
                        continue;
                    }
                    if (chooseNum == "2")
                    {
                        player.ChageAmor();
                        continue;
                    }
                    else if (chooseNum == "0")
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n잘못된 입력입니다. 마을로 돌아갑니다.");
                        continue;
                    }
                }//무기변경

                if (chooseNum == "3")
                {
                    Console.Clear();
                    shop.BuyItem(player);
                    continue;
                }//상점 기능

                if (chooseNum == "4")
                {
                    Console.Clear();
                    Console.WriteLine("\n던전에 입장합니다. 난이도를 선택하세요.");
                    Console.WriteLine("1. 쉬움 (권장 방어력 5)");
                    Console.WriteLine("2. 보통 (권장 방어력 11)");
                    Console.WriteLine("3. 어려움 (권장 방어력 17)");
                    Console.WriteLine("0. 나가기");
                    Console.Write("\n원하시는 행동을 입력해주세요.\n>>");

                    chooseNum = Console.ReadLine();
                    if (chooseNum == "0")
                    {
                        Console.Clear();
                        continue;
                    }

                    int recommendedDef = 0;
                    int expReward = 0;
                    int goldReward = 0;
                    int damge = 0;
                    int extraGold = 0;

                    switch (chooseNum)
                    {   //널오류 수정 완료 //위 if랑 다르게 스위치 사용해보기
                        case "1":
                            recommendedDef = 5;
                            expReward = 10;
                            goldReward = 1000;
                            extraGold = 10 * (new Random().Next((player.Att + (player.EWeapon?.AttBonus ?? 0)), (player.Att + (player.EWeapon?.AttBonus ?? 0)) * 2));
                            damge = new Random().Next(20 + recommendedDef - (player.Def + (player.EArmor?.DefBonus ?? 0)), 35 + recommendedDef - (player.Def + (player.EArmor?.DefBonus ?? 0)));
                            break;
                        case "2":
                            recommendedDef = 11;
                            expReward = 20;
                            goldReward = 1700;
                            extraGold = 17 * (new Random().Next((player.Att + (player.EWeapon?.AttBonus ?? 0)), (player.Att + (player.EWeapon?.AttBonus ?? 0)) * 2));
                            damge = new Random().Next(20 + recommendedDef - (player.Def + (player.EArmor?.DefBonus ?? 0)), 35 + recommendedDef - (player.Def + (player.EArmor?.DefBonus ?? 0)));
                            break;
                        case "3":
                            recommendedDef = 17;
                            expReward = 30;
                            goldReward = 2500;
                            extraGold = 25 * (new Random().Next((player.Att + (player.EWeapon?.AttBonus ?? 0)), (player.Att + (player.EWeapon?.AttBonus ?? 0)) * 2));
                            damge = new Random().Next(20 + recommendedDef - (player.Def + (player.EArmor?.DefBonus ?? 0)), 35 + recommendedDef - (player.Def + (player.EArmor?.DefBonus ?? 0)));
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("\n잘못된 입력입니다. 마을로 돌아갑니다.");
                            continue;
                    }

                    if (player.Def + (player.EArmor?.DefBonus ?? 0) >= recommendedDef)
                    {
                        player.Exp += expReward;
                        player.Gold += goldReward;
                        player.Gold += extraGold;
                        player.Hp -= Math.Max(damge, 0);
                        if (player.Hp <= 0)
                        {
                            Console.WriteLine("      ,-=-.     ");
                            Console.WriteLine("     /  +  \\   ");
                            Console.WriteLine("     | ~~~ |  ");
                            Console.WriteLine("     |R.I.P| ");
                            Console.WriteLine("     |_____| ");
                            Console.WriteLine("사망하셨습니다");
                            Console.ReadKey(); //콘솔창 바로 안꺼지고 키 하나 눌러야 Readlind도 가능
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine("\n던전 클리어!");
                        Console.WriteLine($"경험치 {expReward} 획득");
                        Console.WriteLine($"골드 {goldReward} 획득");
                        Console.WriteLine($"추가 골드 {extraGold} 획득");
                        Console.WriteLine($"체력 {Math.Max(damge, 0)} 감소");
                        continue;

                    }
                    else
                    {
                        if (new Random().Next(1, 11) > 6)
                        {
                            int failDamage = (player.Hp / 2);
                            player.Hp -= failDamage;
                            if (player.Hp <= 0)
                            {
                                Console.WriteLine("      ,-=-.     ");
                                Console.WriteLine("     /  +  \\   ");
                                Console.WriteLine("     | ~~~ |  ");
                                Console.WriteLine("     |R.I.P| ");
                                Console.WriteLine("     |_____| ");
                                Console.WriteLine("사망하셨습니다");
                                Console.ReadKey();
                                break;
                            }
                            Console.Clear();
                            Console.WriteLine($"\n던전 클리어 실패! 체력 {failDamage} 감소");
                            continue;
                        }
                        player.Exp += expReward;
                        player.Gold += goldReward;
                        player.Gold += extraGold;
                        player.Hp -= Math.Max(damge, 0);
                        if (player.Hp <= 0)
                        {
                            Console.WriteLine("      ,-=-.     ");
                            Console.WriteLine("     /  +  \\   ");
                            Console.WriteLine("     | ~~~ |  ");
                            Console.WriteLine("     |R.I.P| ");
                            Console.WriteLine("     |_____| ");
                            Console.WriteLine("사망하셨습니다");
                            Console.ReadKey();
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine("\n던전 클리어!");
                        Console.WriteLine($"경험치 {expReward} 획득");
                        Console.WriteLine($"골드 {goldReward} 획득");
                        Console.WriteLine($"추가 골드 {extraGold} 획득");
                        Console.WriteLine($"체력 {Math.Max(damge, 0)} 감소");
                        continue;
                    }
                }//던전기능

                if (chooseNum == "5")
                {
                    if (player.Gold >= 500)
                    {
                        Console.Clear();
                        Console.WriteLine("\n   +");
                        Console.WriteLine("   A_");
                        Console.WriteLine("  /\\-\\");
                        Console.WriteLine(" _||\"|_");
                        Console.WriteLine("~^~^~^~^");
                        Console.WriteLine("\n회복을 완료하였습니다");
                        player.Hp = 100;
                        player.Gold -= 500;
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n골드가 부족합니다(500 골드 소모)");
                        continue;
                    }
                }//휴식기능
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n잘못된 입력입니다. 마을로 돌아갑니다.");
                    continue;
                }
            }//게임 메뉴
        }
    }
}
//save xml 연결??? using System.Xml.Serialization; 저장할데이터 클래스 생성 후 직렬화, FileStream에 데이터 직렬 저장, 실행시 xml 파일에서 값 불러옴

/*⠀⠀
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀
⣿⠀    ⠀⠀⠀⠀⠀⠀⠀⠀⠀ Rtan⠀⠀⠀⠀    ⣿
⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣤⣤⣤⣤⣤⣀⡀⠀⠀⠀⠀ ⣿                                                                                                              ⠀⠀⠀⠀⠀⠀
⣿⠀⠀⠀⠀⠀⠀⠀⠀⢀⣶⣾⣿⣿⣿⣿⣿⣿⣿⣷⡆⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀
⣿⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⢿⣿⣿⣿⣿⣿⣇⣛⡛⠃⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀
⣿⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⣿⡷⠀⠀⠀⠀
⣿⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⣿⡷⠀
⣿⠀⠀⠀⠀⣠⣤⣤⣀⣼⣿⣿⣿⡇⡴⠾⣿⣿⡿⢷⣿⠀⠀⠀⠀⠀⣿⡷⠀⠀⠀⠀
⣿⠀⠀⠀⠰⣿⣿⣿⣿⣿⣿⣿⣿⣷⣇⡀⠉⠀⠁⠈⣿⣶⠶⠶⡆⠀⠀⣿⡷⠀⠀⠀
⣿⠀⠀⠀⠀⢹⣿⣿⠛⠘⠛⠿⣿⣿⣿⣧⣤⣤⣤⣤⣿⠛⠀⠀⡇⠀⣿⡷⠀⠀⠀⠀
⣿⠀⠀⠀⠀⠀⠀⢸⠀⠀⣿⣷⣶⠀⠈⠉⠉⠉⠀⢰⠶⠶⠶⠎⠀⠀⠀⣿⠀⡷⠀⠀
⣿⠀⠀⠀⠀⠀⠀⠈⠉⠉⠈⠉⣿⣀⣀⣀⣀⣶⣶⣾⠀⠀⠀⠀⠀⠀⣿⡟⠀⠀⠀⠀
⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠛⡿⠋⠉⠉⠛⣿⣯⠀⠀⠀⠀⠀⠀⠀⣿⠀⠋⠀
⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣀⠷⢄⡀⠀⣀⡠⠜⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀
⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠀⠈⠑⠒⠋⠁⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀
⣿              Breakthrough       ⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
*/