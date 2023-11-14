using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading;
internal class Program
{
    private static Character player;
    private static List<Item> items = new List<Item>();
    private static Item item;

    private static List<Item> shopItems = new List<Item>();

    
    static void Main(string[] args)
    {
        Console.Clear();
        GameDataSetting();
        PrintStartLogo();
        // DisplayGameIntro();
        StartMenu();
    }

    public static void AddItem(List<Item> items, string name, string desc, Boolean isUsed, Dictionary<string,int>stat){
        Item item = new Item(name,desc,isUsed,stat);
        items.Add(item);

    }
    public static void AddShopItem(List<Item> shopItems, string name, string desc, Dictionary<string,int> stat, int cost){
        Item item = new Item(name,desc,stat,cost);
        shopItems.Add(item);
    }

    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅
        player = new Character("Chad", "전사",1, 10, 5, 100, 1500);

        // 아이템 정보 세팅
        AddItem(items,"무쇠갑옷","무쇠로 만들어져 튼튼한 갑옷입니다",true,new Dictionary<string,int>(){["Def"]=5});        
        AddItem(items,"낡은 검","쉽게 볼 수 있는 낡은 검입니다.",false,new Dictionary<string,int>(){["Atk"]=2});


        AddShopItem(shopItems, "수련자 갑옷","수련에 도움을 주는 갑옷입니다.",new Dictionary<string, int>(){["Def"]=5},1000);
        AddShopItem(shopItems, "무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다", new Dictionary<string, int>() { ["Def"] = 9 }, 1500);
        AddShopItem(shopItems, "스파르타의 갑옷", " 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", new Dictionary<string, int>() { ["Def"] = 15 }, 3500);
        AddShopItem(shopItems, "낡은 검 ", "쉽게 볼 수 있는 낡은 검 입니다. ", new Dictionary<string, int>() { ["Atk"] = 2 }, 600);
        AddShopItem(shopItems, "청동 도끼 ", "어디선가 사용됐던거 같은 도끼입니다 ", new Dictionary<string, int>() { ["Atk"] = 5}, 1500);
        AddShopItem(shopItems, "스파르타의 창 ", "스파르타의 전사들이 사용했다는 전설의 창입니다 ", new Dictionary<string, int>() { ["Atk"] = 7 }, 3500);

    }


    //Scene -----------------------------------
    public static void StartMenu()
    {
        Console.Clear();
        DisplayGameIntro();
    }
    public static void PrintStartLogo(){
        
        string text = @" 
             _____                  _                 
            /  ___|                | |                
            \ `--. _ __   __ _ _ __| |_ __ _          
            `--. \ '_ \ / _` | '__| __/ _` |         
            /\__/ / |_) | (_| | |  | || (_| |         
            \____/| .__/ \__,_|_|   \__\__,_|         
                | |                                 
                |_|                                 
            ______                                    
            |  _  \                                   
            | | | |_   _ _ __   __ _  ___  ___  _ __  
            | | | | | | | '_ \ / _` |/ _ \/ _ \| '_ \ 
            | |/ /| |_| | | | | (_| |  __/ (_) | | | |
            |___/  \__,_|_| |_|\__, |\___|\___/|_| |_|
                                __/ |                 
                               |___/                  
        
        ";
        Console.WriteLine(text);        
        Console.WriteLine("");   
        Console.WriteLine("============================================================");
        Console.WriteLine("                  Press Any Key to Start");
        Console.WriteLine("============================================================");
        Console.ReadKey();
    }
    static void DisplayGameIntro()
    {
        Console.Clear();
    
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        
        int input = CheckValidInput(1, 3);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;
            
            case 2:
				DisplayInventory();			
                break;

            case 3:
                DisplayShop();
                break;
        }
    }
    
    static void DisplayShop(){
        Console.Clear();
        Console.WriteLine("상점");
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        Console.WriteLine();

        Console.WriteLine("[보유 골드]");
        Console.WriteLine($"{player.Gold} G");
        Console.WriteLine();

        Console.WriteLine("[아이템 목록]");

        foreach (Item item in shopItems)
        {
            Console.Write($"- {item.Name}");
            foreach (KeyValuePair<string, int> i in item.Stats)
            {
                if (i.Key == "Atk")
                {
                    Console.Write($"| 공격력 + {i.Value} ");
                }
                if (i.Key == "Def")
                {
                    Console.Write($"| 방어력 + {i.Value} ");
                }

            }
            Console.Write($" | {item.Desc}");
            if (item.isSold)
            {
                Console.WriteLine(" | 구매완료");
            }
            else
            {
                Console.WriteLine($" | {item.Cost} G");
            }
        }

        Console.WriteLine();
        Console.WriteLine("1. 아이템 구매");
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 1);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            
            case 1:
				DisplayBuyProduct();			
                break;

        }



    }
    static void DisplayBuyProduct(){
        Console.Clear();
        Console.WriteLine("상점 - 아이템 구매");
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        Console.WriteLine();

        Console.WriteLine("[보유 골드]");
        Console.WriteLine($"{player.Gold} G");
        Console.WriteLine();

        Console.WriteLine("[아이템 목록]");

        int idx = 1;
        foreach (Item item in shopItems)
        {
        
            Console.Write($"- {idx} {item.Name}");
            foreach (KeyValuePair<string, int> i in item.Stats)
            {
                if (i.Key == "Atk")
                {
                    Console.Write($"| 공격력 + {i.Value} ");
                }
                if (i.Key == "Def")
                {
                    Console.Write($"| 방어력 + {i.Value} ");
                }

            }
            Console.Write($" | {item.Desc}");
            if (item.isSold)
            {
                Console.WriteLine(" | 구매완료");
            }
            else
            {
                Console.WriteLine($" | {item.Cost} G");
            }
            idx += 1;
        }



        Console.WriteLine();
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, shopItems.Count);

        if (input >0 && shopItems[input - 1].isSold )
        {
            Console.WriteLine("이미 구매한 아이템입니다.");
            Thread.Sleep(1000);
            DisplayBuyProduct();
        }
        else if (input >0 && player.Gold < shopItems[input - 1].Cost )
        {
            Console.WriteLine("Gold가 부족합니다");
            Thread.Sleep(1000);
            DisplayBuyProduct();
        }
        else
        {
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                default:
                    {    
                        shopItems[input - 1].setIsSold();
                        AddItem(items, shopItems[input - 1].Name, shopItems[input - 1].Desc, false, shopItems[input - 1].Stats);
                        player.Gold -= shopItems[input - 1].Cost;
         
                        DisplayBuyProduct();
                        break;
                    }
            }
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


    //  -----------------------------------

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

/// Class 
public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int Gold { get; set; }

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
    public Boolean isSold {get; set;}
    public int Cost {get;}
    public Dictionary<string,int> Stats {get; set;}

// ex) {"Atk", 1}, {"Def",1} ... 
    public Item(string name, string desc, Boolean isUsed, Dictionary<string,int> stats){
        Name = name;
        Desc = desc;
        IsUsed = isUsed;
        Stats = stats;
    }
    public Item(string name, string desc, Dictionary<string,int> stats, int cost){ // for shop
        Name = name;
        Desc = desc;
        IsUsed = false;
        Stats = stats;
        Cost = cost;
        isSold = false;

    }
    
    public Boolean setIsUsed(){
       IsUsed = !IsUsed;
       return IsUsed;

    }
    public Boolean setIsSold(){
        isSold = true;
        return isSold;
    }
    
}
