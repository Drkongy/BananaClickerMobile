using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AmountsLoop : MonoBehaviour
{
    
    /* 

    @author Zeeshan
    This class makes sure that the user can buy multiple shops at the same time.
    they can either buy 1x shops, 10x shops or 100x shops.
    this makes it easier for the user as it means that they don't need to click the button 100 times.
    makes it much more flexible for the user.
    This class just updates the text varibles, the MKHands and MKMonki classes are used to buy the actual hands.




    */


    // Start is called before the first frame update
    public Controller main; // Links to the main controller scipt
    public MKHands Hand;    // links the MKHands script to this file.
    public MKMonkis Monki;  // links to the MKMonkis script.
    public BananaPrefix prefix;  //Links the Prefix script to this

    public int CycleNo; // number that has the equivalent of the amount that needs to be bought. 1 = 1x, 2 = 10x, 3 = 100x.

    public TMP_Text[] txtBuyCountHands = new TMP_Text[12];   // text varibles for the count of the hands shop. 
    public TMP_Text[] txtBuyCountMonkis = new TMP_Text[12]; // text varibles for the count of the Monkis shop.

    public TMP_Text btnTxtBuyCount; // the buy amount button text, can either be 1x, 10x, or 100x


    void Start()
    {
        CycleNo = 0;    // when the game starts it makes sure that it's initilized as 0, since the btn amount will increase it by one within the method.
        btnAmount();    // links to the button in game, when it's clicked it changes the text values of all the varibles.
    }

    // Update is called once per frame
    void Update() // this always checks what the cycleno is, 
    {
        if (CycleNo == 1)
        {
            txtXone(); // if they cycleNo is one it will do the 1x, and updates all the text varibles.

        }else if(CycleNo == 2){
            txtXten();  // if they cycleNo is two it will do the 10x, and updates all the text varibles.

        }else{
            txtXhundred();  // if they cycleNo is Three, or something else it will do the 100x, and updates all the text varibles.
            // the CycleNo can never be more that 3 so the else statement will always output 100x
        }
    }


    public void BUUpdate(){ // this is used to update text from outside the classes.
        if (CycleNo == 1)
        {
            txtXone();
            Debug.Log("test one");

        }else if(CycleNo == 2){
            txtXten();
            Debug.Log("test two");

        }else if(CycleNo == 3){
            txtXhundred();
            Debug.Log("test three");
        }
        
    }

    public void btnAmount(){
        if(CycleNo == 0){ // this is for 1x
            txtLoop("1x");
            txtXone();

            CycleNo++;
        }else if(CycleNo == 1){  // this is for 10x
            txtLoop("10x");
            txtXten();


            CycleNo++;
        }else if(CycleNo == 2){ // this is for 100x
            txtLoop("100x");
            txtXhundred();
            CycleNo = 0;
        }
    }

    public void txtLoop(string s){ // quick method that loops through all 12 of the monki and hands shops, and assins it a string.
        btnTxtBuyCount.text = s;
        for (int i = 0; i <= 11; i++)
        {
            txtBuyCountHands[i].text = s;
            txtBuyCountMonkis[i].text = s;
        }
    }
    
    public void txtXone(){ // this is the method that displays the text for 1x, it's simple and no calculations are needed.
        for (int i = 0; i <= 11; i++) // loops through all 12 shops, means their is no code repeated.
        {
            Hand.Hands[i].costText.text = "Cost: " + prefix.Suffix(Hand.Hands[i].cost, "0.0", false) + " Bananas";
            Hand.Hands[i].countText.text = Hand.Hands[i].count.ToString("0");
            Hand.Hands[i].productionText.text = "+ " + prefix.Suffix(Hand.Hands[i].productionPerClick, "0.0", false) + " BPC";

            Monki.monkis[i].costText.text = "Cost: " + prefix.Suffix(Monki.monkis[i].cost, "0.0", false) + " Bananas";
            Monki.monkis[i].countText.text = Monki.monkis[i].count.ToString("0");
            Monki.monkis[i].productionText.text = "+ " + prefix.Suffix(Monki.monkis[i].productionPerClick, "0.0", false) + " BPS";
        }
    }

    public void txtXten(){  // method updates the shop text but for 10x ammounts
        for (int x = 0; x <= 11; x++)
        {

            // Hands
            double temp = 0;
            double temp1;
            double temp2 = 0;
            //monkis
            double mTemp = 0;
            double mTemp1;
            double mTemp2 = 0;

            for (int i = 0;i <= 9; i++){ // this for for statement loops 10 times, which will give temp values of the shop costs and production
                //hands
                temp2 += Hand.Hands[x].productionPerClick; 
                temp1 = Hand.Hands[x].initialCost * (Math.Pow((1 + (Hand.Hands[x].costMultiplier) / (1 + (Hand.Hands[x].count + i) / (5000))), Hand.Hands[x].count + i));
                temp +=temp1;
                //monkis
                mTemp2 += Monki.monkis[x].productionPerClick;
                mTemp1 = Monki.monkis[x].initialCost * (Math.Pow((1 + (Monki.monkis[x].costMultiplier) / (1 + (Monki.monkis[x].count + i) / (5000))), Monki.monkis[x].count + i));
                mTemp += mTemp1;


            }
      
            // once the temp values are created, it updates the text values for 10x.
            // hands
            Hand.Hands[x].costText.text = "Cost: " + prefix.Suffix(temp, "0.0", false) + " Bananas x10";
            Hand.Hands[x].countText.text = Hand.Hands[x].count.ToString("0");
            Hand.Hands[x].productionText.text = "+ " + prefix.Suffix(temp2, "0.0", false) + " BPC x10";


            //Monkis
            Monki.monkis[x].costText.text = "Cost: " + prefix.Suffix(mTemp, "0.0", false) + " Bananas x10";
            Monki.monkis[x].countText.text = Monki.monkis[x].count.ToString("0");
            Monki.monkis[x].productionText.text = "+ " + prefix.Suffix(mTemp2, "0.0", false) + " BPS x10";



        }

    }

    public void txtXhundred(){  // method updates the shop text but for 1000x ammounts
        for (int x = 0; x <= 11; x++)
        {

            // Hands
            double temp = 0;
            double temp1;
            double temp2 = 0;
            //monkis
            double mTemp = 0;
            double mTemp1;
            double mTemp2 = 0;

            // once the temp values are created, it updates the text values for 10x.
            for (int i = 0;i <= 99; i++){   
                //hands
                temp2 += Hand.Hands[x].productionPerClick;
                temp1 = Hand.Hands[x].initialCost * (Math.Pow((1 + (Hand.Hands[x].costMultiplier) / (1 + (Hand.Hands[x].count + i) / (5000))), Hand.Hands[x].count + i));
                temp +=temp1;
                //monkis
                mTemp2 += Monki.monkis[x].productionPerClick;
                mTemp1 = Monki.monkis[x].initialCost * (Math.Pow((1 + (Monki.monkis[x].costMultiplier) / (1 + (Monki.monkis[x].count + i) / (5000))), Monki.monkis[x].count + i));
                mTemp += mTemp1;


            }


            // hands
            Hand.Hands[x].costText.text = "Cost: " + prefix.Suffix(temp, "0.0", false) + " Bananas x100";
            Hand.Hands[x].countText.text = Hand.Hands[x].count.ToString("0");
            Hand.Hands[x].productionText.text = "+ " + prefix.Suffix(temp2, "0.0", false) + " BPC x100";


            //Monkis
            Monki.monkis[x].costText.text = "Cost: " + prefix.Suffix(mTemp, "0.0", false) + " Bananas x100";
            Monki.monkis[x].countText.text = Monki.monkis[x].count.ToString("0");
            Monki.monkis[x].productionText.text = "+ " + prefix.Suffix(mTemp2, "0.0", false) + " BPS x100";



        }

    }


    


    

}


