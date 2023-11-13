# 스파르타 Text Game 

</br>
던전을 떠나기전 마을에서 장비를 구하는 텍스트 게임

</br>

## 주요 기능
* **게임 시작 화면**
  
  간단한 소갯말과 유저가 할 수 있는 행동을 번호로 알려준다. 원하는 행동의 숫자를 타이핑하면 실행.
  지정된 숫자 외에 다른 숫자 입력시 **잘못된 입력입니다** 라는 문구를 출력한다
  
* **상태보기**
  
  캐릭터의 정보 표기. 7개의 속성을 가지고 있다 ( 레벨, 이름, 직업, 공격력, 방어력, 체력, 골드(돈))
  장착한 아이템에 따라 공격력과 방어력 등 수정 될 수 있다
  
* **인벤토리**

  캐릭터가 보유하고 있는 아이템을 전부 보여준다. 아이템을 장착하고 있을 경우에는 앞에 [E] 표시가 붙어있다.
  
  * **장착관리**

    인벤토리 화면에서 각 아이템 앞에 숫자가 추가된다.
    숫자가 일치하는 아이템을 선택하면 장착과 장착해제, 이외의 숫자를 입력했다면 **잘못된 입력입니다** 라는 문구를 출력한다.
    중복 장착도 가능하다.
    아이템이 장착이 되었다면 앞의 상태보기 화면에서 (+ (추가된 스탯)) 표시로 장착된 아이템의 효과를 표시해준다. 



## 기능 세부 설명
* **게임 시작 화면**
  
![image](https://github.com/suhyunChun/week2_text_game-/assets/89771577/ad27bf08-6b80-4714-a6ef-94a543d5f6fc)

  1번 입력시 - 상태보기 페이지로 이동

  2번 입력시 - 인벤토리 페이지로 이동

  이 외의 숫자 입력시 (예. 3) --> **"잘못된 입력입니다"** 출력 

  ![image](https://github.com/suhyunChun/week2_text_game-/assets/89771577/b94e12e6-b946-4af8-98b0-675404d5cd3d)
    
* **상태보기**
  
  ![image](https://github.com/suhyunChun/week2_text_game-/assets/89771577/f74f5cb2-c05c-4511-8429-5398d596d332)

  캐릭터의 기본 정보들 출력한다.
  공격력, 방어력 옆에 아이템 장착으로 추가된 스탯 표시 

* **인벤토리**
  
  ![image](https://github.com/suhyunChun/week2_text_game-/assets/89771577/7a81e929-6364-41c7-8e2c-89859b8a0cd7)
 
  현재 인벤토리에 가지고 있는 아이템들을 나열한다.
  장착된 아이템은 앞에 [E] 표시 

  * **장착관리**
    
      ![image](https://github.com/suhyunChun/week2_text_game-/assets/89771577/d9a6d724-728b-46d4-9e20-ec3211a23def)
    
      아이템 옆에 있는 숫자를 입력함으로써 장착/장착해제가 가능하다

      **새로운 아이템 장착**
    
      ![image](https://github.com/suhyunChun/week2_text_game-/assets/89771577/dd0430ed-0989-40a7-bd81-4c6be787e161)


      **두 아이템 모두 장착 한 후의 상태창**
    
      ![image](https://github.com/suhyunChun/week2_text_game-/assets/89771577/c634c5cc-698a-43d9-9964-44b0e8d2235f)
 
   



##  기술 스택

![C#](https://img.shields.io/badge/-C%23-%7ED321?logo=Csharp&style=flat)

