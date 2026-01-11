//// 1.Boxing Value type --> Reference type - e kecir Stack --> Heap 
//using System.Collections;

//int digit = 123;// value type stackde saxlanilir
//object qutu = digit; // boxing Reference type heap de saxlanilir 
//// bu cevirmenin adi implicit cevirmedir yeni (Avtomatik) cevirme 




//// 2.Unboxing Reference type --> Value type Heap --> Stack e kecir 
//int newdigit = (int)qutu; // stackde saxlanilir cunki refenceden value type kecdi
////Explicit yazilis sayilir mecburi keciddir () icinde her hansi bir tip saxlayiriq meselen (int),(string)

//ArrayList kohne = new ArrayList();
//kohne.Add(10);// boxing cevrilmesi gedir 
//List<int> yeni = new List<int>();
//yeni.Add(10);
//UpCasting tehlukesizdir implicit cevrilme bas verir alt typeni ust type cevirmek ucundur
using Casting;

static void Main(string[]args)
{
    Dog mydog = new Dog();// yaratdigimiz mydog alt type sayilir 
    mydog.Name = "Test";
    Animal myAnim = mydog;
    mydog.loud();
    //downcasting usttype alttype cevirir explicit yazilisdir tehlukelidir 
    Animal myAnim2 = new Dog();
    Dog yenidog = (Dog)myAnim2;
    yenidog.bark(); 
}