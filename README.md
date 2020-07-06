# BoxWorld
Windows Forms проект по предметот Визуелно Програмирање 2019/2020

##1. Опис на апликацијата

Апликацијата што ја развив е рекреација на puzzle играта BoxWorld, која е излезена во 2004. Задржани се клучните карактеристики на играта со неколку промени.
Имплементирани се алгоритми и функции за започнување нова игра, рестартирање на левел, зачувување на постоечка сесија и продолжување на играта од последниот save-file.

##2. Упатство за користење

###2.1 Главно мени

![main menu](https://i.imgur.com/WJ9Vih6.png)

Слика 1

При стартување на апликацијата се отвара почетниот прозорец (Слика 1) кој функционира како главно мени.
Од тука понудени ни се 3 опции :
* New Game
* Continue Game
* Quit Game

Со опцијата New Game се започнува нова игра од почетокот на првото ниво. Кога ќе ги освоите сите поени се појавува прозорец кој ви кажува дека сте го победиле левелот, и можете да преминете на слиедниот (Слика 2). 
Доколку корисникот сака да ја исклучи играта, при стиснување на X копчето се отвара прозорец (Слика 3) кој ве прашува дали сте сигурни и при потврдување на излез играта се зачувува.

![VictoryPopUP](https://i.imgur.com/IBFB9pU.png)

Слика 2

![ExitPopUP](https://i.imgur.com/jr3Ko6T.png)

Слика 3

Опцијата Continue Game е овозможена само доколку веќе постои save file од претходна сесија. Во случај да е исполнет условот, со стискање на копчето корисникот ќе може да продолжи од истото место каде што претходно ја исклучил играта, без да изгуби никаков прогрес.

Опцијата Quit Game служи за исклучување на играта од главното мени.

###2.2 Контроли

![Controls](https://i.imgur.com/ynX0Yo6.png)

Слика 4

Одкако ќе ја започне играта, на десниот дел од екранот корисникот може да ги забележи контролите за играта (Слика 4). Движењето низ мапата се одвива преку копчињата  W A S D кои соодветно служат за придвижување горе, лево, доле и десно, а со копчето R корисникот може да го рестартира левелот и да почне одново.

###2.3 Цел на играта

![Level3](https://i.imgur.com/QYHkbv4.png)

Слика 5

Играчот се наоѓа во улога на протагонистот - *The Wizard*, кој е заробен низ серија валиринти и ваша цел е да му помогнете да излезе. Користејќи ги контролите за движење корисникот треба да ги постави кутиите врз магичните црвени орбови, со што волшебникот собира доволно моќ за да може да се телепортира на следниот левел.
Корисникот ја победува играта кога ќе ги заврши сите левели.

##3. Претставување на проблемот

###3.1 Податочни структури

Главните податоци и функции за играта се чуваат во класите `class Helper` и `public class PictureBoxLocation`

```
[Serializable]
    public class PictureBoxLocation
    {
        public string pictureBoxName = "";
        public int X = 0;
        public int Y = 0;
    }
 ```
 ```
 class Helper
    {
       public static ExitPopUp popUp = new ExitPopUp();

       public static PictureBoxLocation findPictureBoxLocationByName(string name, PictureBoxLocation[] pictureBoxLocations)
        
       public static void updatePictureBoxLocation(List<PictureBox> pictureBoxes, PictureBoxLocation[] pictureBoxLocations)
       
       public static List<PictureBox> extractPictureBoxesFromNames(string[] names, List<PictureBox> pictureBoxes)
       
       public static bool willHitPictureBox(List<PictureBox> pictureBoxes, Point point)
       
       public static PictureBox getPictureBoxByLocation(List<PictureBox> pictureBoxes, Point point
       
       public static void wizardMovement(Moving moving, PictureBox wizard, List<PictureBox> bricks, List<PictureBox> boxes, List<PictureBox> redOrbs, List<PictureBox> scoredRedOrbs)

       private static void moveWizard(int moveX, int moveY, PictureBox wizard, List<PictureBox> bricks, List<PictureBox> boxes, List<PictureBox> redOrbs, List<PictureBox> scoredRedOrbs)


    }
 
 ```
 Класата `PictureBoxLocation` ја користиме за да сторираме информации за секој PictureBox елемент во играта. Ни овозможува да водиме евиденција за името и локацијата на секој PictureBox.

 Класата `Helper` ги содржи најбитните функции кои ги користиме во оваа апликација.

`willHitPictureBox` проверува дали ќе настане колизија помеѓу два PictureBox елементи.

`wizardMovement` го овозможува движењето на Wizard-от користејќи ја помошната enum класа `Moving`

`moveWizard` проверува дали при движење Wizard-от ќе удри во ѕид, или пак во кутија, и доколку удри во кутија што ќе се случи со истата (дали може да ја помести, дали ќе се помести врз redOrb итн..)

####Изработено:

Предраг Марковиќ 181135
