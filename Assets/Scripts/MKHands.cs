//using System.Diagnostics;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ExceptionServices;
using System.ComponentModel;
using System;
using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MKHands : MonoBehaviour
{

    public Controller main;  // links the main script to this
    public BananaPrefix prefix;  //Links the Prefix script to this
    public Milestones miles;    // for the milestones
    public AmountsLoop AL;   // for the amount multiples
    public Prestige p; // for getting prestige values



    public double totalBPC;     // total amount of BPC
    
    public double[] OriginalHandsCost;
    public float mult = 0.03f; // constant multi


    public MKArrayClass.MKHands[] Hands; // Makes it easier to access the varibles.


    // TMP_Text varibles that would display the values onto the main game.
    public TMP_Text txtHandCount1;
    public TMP_Text txtHandCost1;
    public TMP_Text txtProduction1;

    public TMP_Text txtHandCount2;
    public TMP_Text txtHandCost2;
    public TMP_Text txtProduction2;

    public TMP_Text txtHandCount3;
    public TMP_Text txtHandCost3;
    public TMP_Text txtProduction3;

    public TMP_Text txtHandCount4;
    public TMP_Text txtHandCost4;
    public TMP_Text txtProduction4;

    public TMP_Text txtHandCount5;
    public TMP_Text txtHandCost5;
    public TMP_Text txtProduction5;

    public TMP_Text txtHandCount6;
    public TMP_Text txtHandCost6;
    public TMP_Text txtProduction6;

    public TMP_Text txtHandCount7;
    public TMP_Text txtHandCost7;
    public TMP_Text txtProduction7;

    public TMP_Text txtHandCount8;
    public TMP_Text txtHandCost8;
    public TMP_Text txtProduction8;

    public TMP_Text txtHandCount9;
    public TMP_Text txtHandCost9;
    public TMP_Text txtProduction9;

    public TMP_Text txtHandCount10;
    public TMP_Text txtHandCost10;
    public TMP_Text txtProduction10;

    public TMP_Text txtHandCount11;
    public TMP_Text txtHandCost11;
    public TMP_Text txtProduction11;

    public TMP_Text txtHandCount12;
    public TMP_Text txtHandCost12;
    public TMP_Text txtProduction12;





    void Start()
    {
        Hands = new MKArrayClass.MKHands[12];
        OriginalHandsCost[0] = 15;
        OriginalHandsCost[1] = 150;
        OriginalHandsCost[2] = 10000;
        OriginalHandsCost[3] = 250000;
        OriginalHandsCost[4] = 5e6;
        OriginalHandsCost[5] = 5e8;
        OriginalHandsCost[6] = 1e12;
        OriginalHandsCost[7] = 1e15;
        OriginalHandsCost[8] = 5e17;
        OriginalHandsCost[9] = 1e18;
        OriginalHandsCost[10] = 5e21;
        OriginalHandsCost[11] = 1e24;








        //decalares the hand varibles
        //(name, cost, amount, initialCost ,  costMultiplier, production, HMProduction, txtHandCount, txtHandCost)
        Hands[0] = new MKArrayClass.MKHands("Wooden", OriginalHandsCost[0], 1, OriginalHandsCost[0], mult, 1, 1, txtHandCount1, txtHandCost1, txtProduction1);   
        Hands[1] = new MKArrayClass.MKHands("Stone", OriginalHandsCost[1], 0, OriginalHandsCost[1], mult, 10, 10, txtHandCount2, txtHandCost2, txtProduction2);
        Hands[2] = new MKArrayClass.MKHands("Coal", OriginalHandsCost[2], 0, OriginalHandsCost[2],mult, 500, 500, txtHandCount3, txtHandCost3, txtProduction3);
        Hands[3] = new MKArrayClass.MKHands("Iron", OriginalHandsCost[3], 0, OriginalHandsCost[3],mult, 10000, 10000, txtHandCount4, txtHandCost4, txtProduction4);
        Hands[4] = new MKArrayClass.MKHands("Gold", OriginalHandsCost[4], 0, OriginalHandsCost[4],mult, 5e6, 5e6, txtHandCount5, txtHandCost5, txtProduction5);
        Hands[5] = new MKArrayClass.MKHands("Diamond", OriginalHandsCost[5], 0, OriginalHandsCost[5],mult, 2.5e7, 2.5e7, txtHandCount6, txtHandCost6, txtProduction6);
        Hands[6] = new MKArrayClass.MKHands("Emerald", OriginalHandsCost[6], 0, OriginalHandsCost[6],mult, 1e9f, 1e9f, txtHandCount7, txtHandCost7, txtProduction7);   
        Hands[7] = new MKArrayClass.MKHands("Ruby", OriginalHandsCost[7], 0, OriginalHandsCost[7],mult, 5e11f,  5e11f,txtHandCount8, txtHandCost8, txtProduction8);
        Hands[8] = new MKArrayClass.MKHands("Saphire", OriginalHandsCost[8], 0, OriginalHandsCost[8],mult, 2.5e13f,  2.5e13f,txtHandCount9, txtHandCost9, txtProduction9);
        Hands[9] = new MKArrayClass.MKHands("Void", OriginalHandsCost[9], 0, OriginalHandsCost[9],mult, 1e15f,  1e15f, txtHandCount10, txtHandCost10, txtProduction10);
        Hands[10] = new MKArrayClass.MKHands("Rainbownite", OriginalHandsCost[10], 0, OriginalHandsCost[10],mult, 2.5e20f, 2.5e20f, txtHandCount11, txtHandCost11, txtProduction11);
        Hands[11] = new MKArrayClass.MKHands("BlackStone", OriginalHandsCost[11], 0, OriginalHandsCost[11],mult, 1e22f, 1e22f, txtHandCount12, txtHandCost12, txtProduction12);




    }




    void Update()
    {
        main.BPC = 1+totalBPC; // sends the total BPC to the main controller class.

    }
    // the methods below are for each individual shop, and it also checks what the cycle number is.
    // depending on the cycle number it will upgrade it a certain amount of times.

    public void buyWoodenHand(){
        if(AL.CycleNo == 1){buy1(0);}
        if(AL.CycleNo == 2){buy10(0);}
        if(AL.CycleNo == 0){buy100(0);}
    }

    public void buyStoneHand()
    {
        if(AL.CycleNo == 1){buy1(1);}
        if(AL.CycleNo == 2){buy10(1);}
        if(AL.CycleNo == 0){buy100(1);}
    }


    public void buyCoalHand()
    {
        if(AL.CycleNo == 1){buy1(2);}
        if(AL.CycleNo == 2){buy10(2);}
        if(AL.CycleNo == 0){buy100(2);}
    }

    public void buyIronHand()
    {
        if(AL.CycleNo == 1){buy1(3);}
        if(AL.CycleNo == 2){buy10(3);}
        if(AL.CycleNo == 0){buy100(3);}
    }
    

    public void buyGoldHand()
    {
        if(AL.CycleNo == 1){buy1(4);}
        if(AL.CycleNo == 2){buy10(4);}
        if(AL.CycleNo == 0){buy100(4);}

    }

    public void buyDiamondHand()
    {
        if(AL.CycleNo == 1){buy1(5);}
        if(AL.CycleNo == 2){buy10(5);}
        if(AL.CycleNo == 0){buy100(5);}

    }

    public void buyEmeraldHand()
    {
        if(AL.CycleNo == 1){buy1(6);}
        if(AL.CycleNo == 2){buy10(6);}
        if(AL.CycleNo == 0){buy100(6);}

    }

    public void buyRubyHand()
    {
        if(AL.CycleNo == 1){buy1(7);}
        if(AL.CycleNo == 2){buy10(7);}
        if(AL.CycleNo == 0){buy100(7);}

    }

    public void buySaphireHand()
    {
        if(AL.CycleNo == 1){buy1(8);}
        if(AL.CycleNo == 2){buy10(8);}
        if(AL.CycleNo == 0){buy100(8);}

    }

    public void buyVoidHand()
    {
        if(AL.CycleNo == 1){buy1(9);}
        if(AL.CycleNo == 2){buy10(9);}
        if(AL.CycleNo == 0){buy100(9);}

    }

    public void buyRainbowniteHand()
    {
        if(AL.CycleNo == 1){buy1(10);}
        if(AL.CycleNo == 2){buy10(10);}
        if(AL.CycleNo == 0){buy100(10);}

    }

    public void buyBlackStoneHand()
    {
        if(AL.CycleNo == 1){buy1(11);}
        if(AL.CycleNo == 2){buy10(11);}
        if(AL.CycleNo == 0){buy100(11);}
    }



    // Functions that choose how much shop items you want to buy.

    private void buy1(int x){
        if(main.bananas >= Hands[x].cost){
            main.bananas -= Hands[x].cost;
            totalBPC += Hands[x].HMProduction;
            Hands[x].count += 1;
            Hands[x].cost = Hands[x].initialCost * (Math.Pow((1 + (Hands[x].costMultiplier) / (1 + (Hands[x].count) / (1000000000))), Hands[x].count));
            Hands[x].productionPerClick = miles.milesStoness(Hands[x].count, Hands[x].productionPerClick);
            Hands[x].HMProduction = Hands[x].productionPerClick * (1 + (p.Intelligence * (p.Prestige_Multi /100)));

        }

    }
    // checks to see if you can buy the shop 10 times and buys it.

    private void buy10(int x){
        double temp = 0;
        double temp1;

        for (int i = 0;i <= 9; i++){
            temp1 = Hands[x].initialCost * (Math.Pow((1 + (Hands[x].costMultiplier) / (1 + (Hands[x].count + i) / (10000000000))), Hands[x].count + i));
            temp +=temp1;
        }
        



        if(main.bananas >= temp){
            for (int i = 0;i <= 9; i++){
                main.bananas -= Hands[x].cost;
                totalBPC += Hands[x].HMProduction;
                Hands[x].count += 1;
                Hands[x].cost = Hands[x].initialCost * (Math.Pow((1 + (Hands[x].costMultiplier) / (1 + (Hands[x].count) / (1000000000))), Hands[x].count));
                Hands[x].productionPerClick = miles.milesStoness(Hands[x].count, Hands[x].productionPerClick);
                Hands[x].HMProduction = Hands[x].productionPerClick * (1 + (p.Intelligence * (p.Prestige_Multi /100)));

                
            }
        }


    }
    // checks if the shop can buy it 100 times and buys it if it can.

    private void buy100(int x){
        double temp = 0;
        double temp1;

        for (int i = 0;i <= 99; i++){
            temp1 = Hands[x].initialCost * (Math.Pow((1 + (Hands[x].costMultiplier) / (1 + (Hands[x].count + i) / (1000000000))), Hands[x].count + i));
            temp +=temp1;
        }
        



        if(main.bananas >= temp){
            for (int i = 0;i <= 99; i++){
                main.bananas -= Hands[x].cost;
                totalBPC += Hands[x].HMProduction;
                Hands[x].count += 1;
                Hands[x].cost = Hands[x].initialCost * (Math.Pow((1 + (Hands[x].costMultiplier) / (1 + (Hands[x].count) / (1000000000))), Hands[x].count));
                Hands[x].productionPerClick = miles.milesStoness(Hands[x].count, Hands[x].productionPerClick);
                Hands[x].HMProduction = Hands[x].productionPerClick * (1 + (p.Intelligence * (p.Prestige_Multi /100)));

            }
        }


    }

    public void iniUpdate(int x){
        Hands[x].cost = Hands[x].initialCost * (Math.Pow((1 + (Hands[x].costMultiplier) / (1 + (Hands[x].count) / (1000000000))), Hands[x].count + 1));
        // this goes with the hand cost deduction upgrade, it will not work without this, same with the method below!
        // this links to the monkis cost deduction upgrade, without this the text will not update instantly.
    
    }

    






        
    
}
