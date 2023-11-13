using System.Diagnostics;
using System.Runtime.CompilerServices;

internal class Program
{
    private static Character player;
    private static List<Item> items = new List<Item>();
    private static Item item;

    
    static void Main(string[] args)
    {
        Console.Clear();
        GameDataSetting();
        DisplayGameIntro();
    }

    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅
        player = new Character("Chad", "전사",1, 10, 5, 100, 1500);

        item = new Item("무쇠갑옷","무쇠로 만들어져 튼튼한 갑옷입니다",true,new Dictionary<string,int>(){["Def"]=5});
        items.Add(item);
  
        item = new Item("낡은 검","쉽게 볼 수 있는 낡은 검입니다.",false,new Dictionary<string,int>(){["Atk"]=2});
        items.Add(item);


		// 아이템 정보 세팅
    }

    static void DisplayGameIntro()
    {
        Console.Clear();
    
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        
        int input = CheckValidInput(1, 2);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;
            
            case 2:
				DisplayInventory();			
                break;
        }
    }
    
    static void DisplayMyInfo()
    {

        int totalAtk = 0;
        int totalDef = 0;

        Console.Clear();
    
        foreach(Item item in items){
            if(item.IsUsed){
                foreach(KeyValuePair<string, int> i in item.Stats ){
                    
                    if(i.Key == "Atk"){
                        totalAtk+=i.Value;
                    }
                    if(i.Key == "Def"){
                        totalDef+=i.Value;
                    }
                }
            }
        }   

        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보르 표시합니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Level}");
        Console.WriteLine($"{player.Name}({player.Job})");
  
        if(totalAtk!=0){
            Console.WriteLine($"공격력 :{player.Atk} ( + {totalAtk})");
        }else{
            Console.WriteLine($"공격력 :{player.Atk}");  
        }
        if(totalDef!=0){
            Console.WriteLine($"방어력 : {player.Def}( + {totalDef})");
        }else{
            Console.WriteLine($"방어력 : {player.Def}");
        }
        Console.WriteLine($"체력 : {player.Hp}");
        Console.WriteLine($"Gold : {player.Gold} G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
            
        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;

            
        }
    }

    static void DisplayEquippedInventory(){
        int idx = 1;   
        Console.Clear();
        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        foreach(Item item in items){
            
            //Console.Write($"{item}, {item.Name}");
       
            Console.Write("-");
     
            Console.Write($" {idx}");
            idx+=1;
            if(item.IsUsed){
                Console.Write(" [E]");
            }
            Console.Write($" {item.Name}\t");
            foreach(KeyValuePair<string, int> i in item.Stats ){
                if(i.Key == "Atk"){
                    Console.Write($"| 공격력 + {i.Value} ");
                }
                if(i.Key == "Def"){
                    Console.Write($"| 방어력 + {i.Value} ");
                }

            }
            Console.Write($"|{item.Desc}\n");
    

        }
        Console.WriteLine();

        Console.WriteLine("0. 나가기");
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        int input = CheckValidInput(0, idx-1);        
        if(input == 0){
             DisplayInventory();
        }else{
            items[input-1].setIsUsed();  
            //Console.WriteLine($"{input-1}->{items[input-1].Name}");
            DisplayEquippedInventory();

        }

    }
        
    
    static void DisplayInventory()
    {
  
        Console.Clear();
        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        foreach(Item item in items){
            

       
            Console.Write("-");
            if(item.IsUsed){
                Console.Write(" [E]");
            }
            Console.Write($" {item.Name}\t");
            foreach(KeyValuePair<string, int> i in item.Stats ){
                if(i.Key == "Atk"){
                    Console.Write($"| 공격력 + {i.Value} ");
                }
                if(i.Key == "Def"){
                    Console.Write($"| 방어력 + {i.Value} ");
                }

            }
            Console.Write($"|{item.Desc}\n");


        }
        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 1);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            case 1:
                DisplayEquippedInventory();
                break;
        }


    }
    
    static int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if(ret >= min && ret <= max)
                    return ret;        
            }
            
            Console.WriteLine("잘못된 입력입니다.");
        }
    }
}


public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int Gold { get; }

    public Character(string name, string job, int level, int atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk; // 공격력
        Def = def; // 방어력
        Hp = hp; //체력
        Gold = gold;
    }
}

public class Item{
    public String Name {get;}
    public String Desc {get;}
    public Boolean IsUsed {get; set;}
    public Dictionary<string,int> Stats {get; set;}

// ex) {"Atk", 1}, {"Def",1} ... 
    public Item(string name, string desc, Boolean isUsed, Dictionary<string,int> stats){
        Name = name;
        Desc = desc;
        IsUsed = isUsed;
        Stats = stats;
    }
    
    public Boolean setIsUsed(){
       IsUsed = !IsUsed;
       return IsUsed;

    }
    
}