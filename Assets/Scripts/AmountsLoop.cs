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
    // Start is called before the first frame update
    public Controller main; // Links to the main controller scipt
    public MKHands Hand;    // links the MKHands script to this file.
    public MKMonkis Monki;  // links to the MKMonkis script.
    public BananaPrefix prefix;  //Links the Prefix script to this

    public int CycleNo;

    public TMP_Text[] txtBuyCountHands = new TMP_Text[12];
    public TMP_Text[] txtBuyCountMonkis = new TMP_Text[12];

    public TMP_Text btnTxtBuyCount;

    public AmountsLoop(){
        //CycleNo;
    }
    void Start()
    {
        //txtBuyCountHands = new TMP_Text[12];
        CycleNo = 0;
        btnAmount();
    }

    // Update is called once per frame
    void Update()
    {
        if (CycleNo == 1)
        {
            txtXone();

        }else if(CycleNo == 2){
            txtXten();

        }else{
            txtXhundred();
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

    public void txtLoop(string s){
        btnTxtBuyCount.text = s;
        for (int i = 0; i <= 11; i++)
        {
            txtBuyCountHands[i].text = s;
            txtBuyCountMonkis[i].text = s;
        }
    }
    
    public void txtXone(){
        for (int i = 0; i <= 11; i++)
        {
            Hand.Hands[i].costText.text = "Cost: " + prefix.Suffix(Hand.Hands[i].cost, "0.0", false) + " Bananas";
            Hand.Hands[i].countText.text = Hand.Hands[i].count.ToString("0");
            Hand.Hands[i].productionText.text = "+ " + prefix.Suffix(Hand.Hands[i].productionPerClick, "0.0", false) + " BPC";

            Monki.monkis[i].costText.text = "Cost: " + prefix.Suffix(Monki.monkis[i].cost, "0.0", false) + " Bananas";
            Monki.monkis[i].countText.text = Monki.monkis[i].count.ToString("0");
            Monki.monkis[i].productionText.text = "+ " + prefix.Suffix(Monki.monkis[i].productionPerClick, "0.0", false) + " BPS";
        }
    }

    public void txtXten(){
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

            for (int i = 0;i <= 9; i++){
                //hands
                temp2 += Hand.Hands[x].productionPerClick;
                temp1 = Hand.OriginalHandsCost[x] * (Math.Pow((1 + (Hand.Hands[x].costMultiplier) / (1 + (Hand.Hands[x].count + i) / (5000))), Hand.Hands[x].count + i));
                temp +=temp1;
                //monkis
                mTemp2 += Monki.monkis[x].productionPerClick;
                mTemp1 = Monki.OriginalMonkisCost[x] * (Math.Pow((1 + (Monki.monkis[x].costMultiplier) / (1 + (Monki.monkis[x].count + i) / (5000))), Monki.monkis[x].count + i));
                mTemp += mTemp1;


            }
            //temp2 -= Hand.Hands[x].productionPerClick;  // hands
            //mTemp2 -= Monki.monkis[x].productionPerClick;   // monkis

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

    public void txtXhundred(){
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

            for (int i = 0;i <= 99; i++){
                //hands
                temp2 += Hand.Hands[x].productionPerClick;
                temp1 = Hand.OriginalHandsCost[x] * (Math.Pow((1 + (Hand.Hands[x].costMultiplier) / (1 + (Hand.Hands[x].count + i) / (5000))), Hand.Hands[x].count + i));
                temp +=temp1;
                //monkis
                mTemp2 += Monki.monkis[x].productionPerClick;
                mTemp1 = Monki.OriginalMonkisCost[x] * (Math.Pow((1 + (Monki.monkis[x].costMultiplier) / (1 + (Monki.monkis[x].count + i) / (5000))), Monki.monkis[x].count + i));
                mTemp += mTemp1;


            }
            //temp2 -= Hand.Hands[x].productionPerClick;  // hands
            //mTemp2 -= Monki.monkis[x].productionPerClick;   // monkis

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


