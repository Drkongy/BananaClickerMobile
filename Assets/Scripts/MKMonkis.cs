using System;   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MKMonkis : MonoBehaviour
{

    public Controller main;  // links the main script to this
    public BananaPrefix prefix;  //Links the Prefix script to this
    public Milestones miles;    // for the milestones   
    public AmountsLoop AL;   // for the amount multiples


    public double totalBPS;     // total amount of BPS
    
    
    public MKArrayClass.MKHands[] monkis; // Makes it easier to access the varibles.
    public double[] OriginalMonkisCost;
    public float mult = 0.03f;      // multiplier for all of the shops.

    // TMP_Text varibles that would display the values onto the main game.
    public TMP_Text txtMonkiCount1;
    public TMP_Text txtMonkiCost1;
    public TMP_Text txtProduction1;

    public TMP_Text txtMonkiCount2;
    public TMP_Text txtMonkiCost2;
    public TMP_Text txtProduction2;

    public TMP_Text txtMonkiCount3;
    public TMP_Text txtMonkiCost3;
    public TMP_Text txtProduction3;

    public TMP_Text txtMonkiCount4;
    public TMP_Text txtMonkiCost4;
    public TMP_Text txtProduction4;

    public TMP_Text txtMonkiCount5;
    public TMP_Text txtMonkiCost5;
    public TMP_Text txtProduction5;

    public TMP_Text txtMonkiCount6;
    public TMP_Text txtMonkiCost6;
    public TMP_Text txtProduction6;

    public TMP_Text txtMonkiCount7;
    public TMP_Text txtMonkiCost7;
    public TMP_Text txtProduction7;

    public TMP_Text txtMonkiCount8;
    public TMP_Text txtMonkiCost8;
    public TMP_Text txtProduction8;

    public TMP_Text txtMonkiCount9;
    public TMP_Text txtMonkiCost9;
    public TMP_Text txtProduction9;

    public TMP_Text txtMonkiCount10;
    public TMP_Text txtMonkiCost10;
    public TMP_Text txtProduction10;

    public TMP_Text txtMonkiCount11;
    public TMP_Text txtMonkiCost11;
    public TMP_Text txtProduction11;

    public TMP_Text txtMonkiCount12;
    public TMP_Text txtMonkiCost12;
    public TMP_Text txtProduction12;
    



    void Start()
    {
        monkis = new MKArrayClass.MKHands[12];

        OriginalMonkisCost[0] = 250;
        OriginalMonkisCost[1] = 10000;
        OriginalMonkisCost[2] = 2.5e7;
        OriginalMonkisCost[3] = 5e8;
        OriginalMonkisCost[4] = 1e9;
        OriginalMonkisCost[5] = 5e10;
        OriginalMonkisCost[6] = 1e12;
        OriginalMonkisCost[7] = 7.5e14;
        OriginalMonkisCost[8] = 2.5e17;
        OriginalMonkisCost[9] = 2.5e20;
        OriginalMonkisCost[10] = 1e22;
        OriginalMonkisCost[11] = 1e27;

        //decalares the hand varibles
        //(name, cost, amount, initalcost, costMultiplier, production, txtHandCount, txtHandCost)
        monkis[0] = new MKArrayClass.MKHands("Marmocets", OriginalMonkisCost[0], 0, OriginalMonkisCost[0],mult, 5, txtMonkiCount1, txtMonkiCost1, txtProduction1);
        monkis[1] = new MKArrayClass.MKHands("Capuchin", OriginalMonkisCost[1], 0, OriginalMonkisCost[1],mult, 100, txtMonkiCount2, txtMonkiCost2, txtProduction2);   
        monkis[2] = new MKArrayClass.MKHands("Bonobo", OriginalMonkisCost[2], 0, OriginalMonkisCost[2],mult, 1e4, txtMonkiCount3, txtMonkiCost3, txtProduction3);   
        monkis[3] = new MKArrayClass.MKHands("Orangutan", OriginalMonkisCost[3], 0, OriginalMonkisCost[3],mult, 5e5, txtMonkiCount4, txtMonkiCost4, txtProduction4);   
        monkis[4] = new MKArrayClass.MKHands("Baboon", OriginalMonkisCost[4], 0, OriginalMonkisCost[4],mult, 5e7, txtMonkiCount5, txtMonkiCost5, txtProduction5);   
        monkis[5] = new MKArrayClass.MKHands("Chimpanzee", OriginalMonkisCost[5], 0, OriginalMonkisCost[5],mult, 1e9, txtMonkiCount6, txtMonkiCost6, txtProduction6);   
        monkis[6] = new MKArrayClass.MKHands("Mandrill", OriginalMonkisCost[6], 0, OriginalMonkisCost[6],mult, 7.5e9, txtMonkiCount7, txtMonkiCost7, txtProduction7);
        monkis[7] = new MKArrayClass.MKHands("Gelada", OriginalMonkisCost[7], 0, OriginalMonkisCost[7],mult, 1e12, txtMonkiCount8, txtMonkiCost8, txtProduction8);   
        monkis[8] = new MKArrayClass.MKHands("Gorilla", OriginalMonkisCost[8], 0, OriginalMonkisCost[8],mult, 1e15, txtMonkiCount9, txtMonkiCost9, txtProduction9);   
        monkis[9] = new MKArrayClass.MKHands("Homo Habilis", OriginalMonkisCost[9], 0, OriginalMonkisCost[9],mult, 1e17, txtMonkiCount10, txtMonkiCost10, txtProduction10);   
        monkis[10] = new MKArrayClass.MKHands("Homo Erectus", OriginalMonkisCost[10], 0, OriginalMonkisCost[10],mult, 1e19, txtMonkiCount11, txtMonkiCost11, txtProduction11);   
        monkis[11] = new MKArrayClass.MKHands("Homo Sapian", OriginalMonkisCost[11], 0, OriginalMonkisCost[11],mult, 1e21, txtMonkiCount12, txtMonkiCost12, txtProduction12);  
    }
    void Update()
    {
        main.BPS = 0+totalBPS; // updates the bananas per second to the new BPS.
    }

    // the methods below are for each individual shop, and it also checks what the cycle number is.
    // depending on the cycle number it will upgrade it a certain amount of times.
    public void BuyMarmocets(){ 
        if(AL.CycleNo == 1){buy1(0);}
        if(AL.CycleNo == 2){buy10(0);}
        if(AL.CycleNo == 0){buy100(0);}
    }

    public void BuyCapuchin(){
        if(AL.CycleNo == 1){buy1(1);}
        if(AL.CycleNo == 2){buy10(1);}
        if(AL.CycleNo == 0){buy100(1);}
    }

    public void BuyBonobo(){
        if(AL.CycleNo == 1){buy1(2);}
        if(AL.CycleNo == 2){buy10(2);}
        if(AL.CycleNo == 0){buy100(2);}
    }

    public void BuyOrangutan(){
        if(AL.CycleNo == 1){buy1(3);}
        if(AL.CycleNo == 2){buy10(3);}
        if(AL.CycleNo == 0){buy100(3);}
    }
    
    public void BuyBaboon(){
        if(AL.CycleNo == 1){buy1(4);}
        if(AL.CycleNo == 2){buy10(4);}
        if(AL.CycleNo == 0){buy100(4);}
    }


    public void BuyChimpanzee(){
        if(AL.CycleNo == 1){buy1(5);}
        if(AL.CycleNo == 2){buy10(5);}
        if(AL.CycleNo == 0){buy100(5);}
    }
    
    public void BuyMandrill(){
        if(AL.CycleNo == 1){buy1(6);}
        if(AL.CycleNo == 2){buy10(6);}
        if(AL.CycleNo == 0){buy100(6);}
    }


    public void BuyGelada(){
        if(AL.CycleNo == 1){buy1(7);}
        if(AL.CycleNo == 2){buy10(7);}
        if(AL.CycleNo == 0){buy100(7);}
    }


    public void BuyGorilla(){
        if(AL.CycleNo == 1){buy1(8);}
        if(AL.CycleNo == 2){buy10(8);}
        if(AL.CycleNo == 0){buy100(8);}
    }

    public void BuyHomoHabilis(){
        if(AL.CycleNo == 1){buy1(9);}
        if(AL.CycleNo == 2){buy10(9);}
        if(AL.CycleNo == 0){buy100(9);}
    }
    
    public void BuyHomoErectus(){
        if(AL.CycleNo == 1){buy1(10);}
        if(AL.CycleNo == 2){buy10(10);}
        if(AL.CycleNo == 0){buy100(10);}
    }

    public void BuyHomoSapian(){
        if(AL.CycleNo == 1){buy1(11);}
        if(AL.CycleNo == 2){buy10(11);}
        if(AL.CycleNo == 0){buy100(11);}
    }












    //function to see how many items you can buy.
    private void buy1(int x){
        if(main.bananas >= monkis[x].cost){
            main.bananas -= monkis[x].cost;
            totalBPS += monkis[x].productionPerClick;
            monkis[x].count += 1;
            monkis[x].cost = monkis[x].initialCost * (Math.Pow((1 + (monkis[x].costMultiplier) / (1 + (monkis[x].count) / (5000))), monkis[x].count));

            monkis[x].productionPerClick = miles.milesStoness(monkis[x].count, monkis[x].productionPerClick);
        }
    }


    // checks to see if you can buy the shop 10 times and buys it.
    private void buy10(int x){
        double temp = 0;
        double temp1;

        for (int i = 0;i <= 9; i++){
            temp1 = monkis[x].initialCost * (Math.Pow((1 + (monkis[x].costMultiplier) / (1 + (monkis[x].count + i) / (5000))), monkis[x].count + i));
            temp +=temp1;
        }
        



        if(main.bananas >= temp){
            for (int i = 0;i <= 9; i++){
                main.bananas -= monkis[x].cost;
                totalBPS += monkis[x].productionPerClick;
                monkis[x].count += 1;
                monkis[x].cost = monkis[x].initialCost * (Math.Pow((1 + (monkis[x].costMultiplier) / (1 + (monkis[x].count) / (5000))), monkis[x].count));
                monkis[x].productionPerClick = miles.milesStoness(monkis[x].count, monkis[x].productionPerClick);
            }
        }


    }


    // checks if the shop can buy it 100 times and buys it if it can.
    private void buy100(int x){
        double temp = 0;
        double temp1;

        for (int i = 0;i <= 99; i++){
            temp1 = monkis[x].initialCost * (Math.Pow((1 + (monkis[x].costMultiplier) / (1 + (monkis[x].count + i) / (5000))), monkis[x].count + i));
            temp +=temp1;
        }
        



        if(main.bananas >= temp){
            for (int i = 0;i <= 99; i++){
                main.bananas -= monkis[x].cost;
                totalBPS += monkis[x].productionPerClick;
                monkis[x].count += 1;
                monkis[x].cost = monkis[x].initialCost * (Math.Pow((1 + (monkis[x].costMultiplier) / (1 + (monkis[x].count) / (5000))), monkis[x].count));
                monkis[x].productionPerClick = miles.milesStoness(monkis[x].count, monkis[x].productionPerClick);
            }
        }


    }
    
    

}
