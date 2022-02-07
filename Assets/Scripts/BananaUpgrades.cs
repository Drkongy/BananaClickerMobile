using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BananaUpgrades : MonoBehaviour
{
    public Controller main; // Links to the main controller scipt
    public MKHands Hand;    // links the MKHands script to this file.
    public MKMonkis Monki;  // links to the MKMonkis script.
    public BananaPrefix prefix;  //Links the Prefix script to this
    public AmountsLoop AL;   // for the amount multiples




    public int[] UpgradeNo;

    public int ArrBounds = 13;



    public TMP_Text[] txtUpgrade = new TMP_Text[10];
    public TMP_Text[] txtUpgradeCost = new TMP_Text[5];

    

    void Start()
    {

        txtUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void txtUpdate(){
        // for the text
        txtUpgrade[0].text = getHandUpgradeText(UpgradeNo[0]);      
        txtUpgrade[1].text = getMonkisUpgradeText(UpgradeNo[1]);
        txtUpgrade[2].text = getHandDeductionUpgradeText(UpgradeNo[2]);
        txtUpgrade[3].text = getMonkiDeductionUpgradeText(UpgradeNo[3]);
        txtUpgrade[4].text = getAllUpgradeText(UpgradeNo[4]);


        // For the cost
        txtUpgradeCost[0].text = "Cost: " + prefix.Suffix(getHandCost(UpgradeNo[0]), "0.0", false) + " Bananas"; 
        txtUpgradeCost[1].text = "Cost: " + prefix.Suffix(getMonkisCost(UpgradeNo[1]), "0.0", false) + " Bananas";
        txtUpgradeCost[2].text = "Cost: " + prefix.Suffix(getHandDeductionCost(UpgradeNo[2]), "0.0", false) + " Bananas";
        txtUpgradeCost[3].text = "Cost: " + prefix.Suffix(getMonkiDeductionCost(UpgradeNo[3]), "0.0", false) + " Bananas";
        txtUpgradeCost[4].text = "Cost: " + prefix.Suffix(getAllCost(UpgradeNo[4]), "0.0", false) + " Bananas";
        
    }



    //button pressed events
    public void btnUpgrHands(){
        if(UpgradeNo[0] < ArrBounds){  // makes sure that it does not go out of the array bounds.
            if(main.bananas >= getHandCost(UpgradeNo[0])){
                main.bananas -= getHandCost(UpgradeNo[0]);
                UpgradeNo[0]++; // increases the upgrade number by 1
                txtUpdate();    // updates the text for upgrades
                HandMultCheck(UpgradeNo[0]);    // adds the multiplier for the shop.
            }
        }
    }

    public void btnUpgrMonkis(){
        if(UpgradeNo[1] < ArrBounds){  // makes sure that it does not go out of the array bounds.
            if(main.bananas >= getMonkisCost(UpgradeNo[1])){
                main.bananas -= getMonkisCost(UpgradeNo[1]);
                UpgradeNo[1]++; 
                txtUpdate();
                MonkiMultCheck(UpgradeNo[1]);
            }
        }
    }


    public void btnUpgrHandsCostDeduction(){
        
        if(UpgradeNo[2] < ArrBounds){ // makes usre that it does not go out of the array bounds.
            if(main.bananas >= getHandDeductionCost(UpgradeNo[2])){
                main.bananas -= getHandDeductionCost(UpgradeNo[2]);
                UpgradeNo[2]++;
                txtUpdate();
                HandDeductionCheck(UpgradeNo[2]);
            }

        }
        
        

        

    }
    public void btnUpgrMonkisCostDeduction(){
        if(UpgradeNo[3] < ArrBounds){  // makes sure that it does not go out of the array bounds.
            if(main.bananas >= getMonkiDeductionCost(UpgradeNo[3])){
                main.bananas -= getMonkiDeductionCost(UpgradeNo[3]);
                UpgradeNo[3]++;
                txtUpdate();
                MonkiDeductionCheck(UpgradeNo[3]);
            }

        }
     

        

    }

    public void btnUpgrAll(){
        if(UpgradeNo[4] < ArrBounds){
            if(main.bananas >= getAllCost(UpgradeNo[4])){
                main.bananas -= getAllCost(UpgradeNo[4]);
                UpgradeNo[4]++;
                txtUpdate();
                allUpgradesCheck(UpgradeNo[4]);

            }
        }



    }













    // Other events

    // Gettings the upgrade texts
    public String getHandUpgradeText(int x){
        string[] contents = new string[]{
            "2x Wooden Hands Multiplier",
            "2x Stone Hands Multiplier",
            "2x Coal Hands Multiplier",
            "2x Iron Hands Multiplier",
            "2x Gold Hands Multiplier",
            "2x Diamond Hands Multiplier",
            "2x Emerald Hands Multiplier",
            "2x Ruby Hands Multiplier",
            "2x Saphire Hands Multiplier",
            "2x Void Hands Multiplier",
            "2x Rainbownite Hands Multiplier",
            "2x BlackStone Hands Multiplier",


            "More to come in the future!"

        };

        return contents[x];

    }


    public String getMonkisUpgradeText(int x){
        string[] contents = new string[]{
            "2x Marmocets Workers Multiplier",
            "2x Capuchin Workers Multiplier",
            "2x Bonobo Workers Multiplier",
            "2x Orangutan Workers Multiplier",
            "2x Baboon Workers Multiplier",
            "2x Chimpanzee Workers Multiplier",
            "2x Mandrill Workers Multiplier",
            "2x Gelada Workers Multiplier",
            "2x Gorilla Workers Multiplier",
            "2x Homo Habilis Workers Multiplier",
            "2x Homo Erectus Workers Multiplier",
            "2x Homo Sapian Workers Multiplier",


            "More to come in the future!"



        };

        return contents[x];

    }


    public String getHandDeductionUpgradeText(int x){
        string[] contents = new string[]{
            "99% Wooden Hands Cost Reduction",
            "99% Stone Hands Cost Reduction",
            "99% Coal Hands Cost Reduction",
            "99% Iron Hands Cost Reduction",
            "99% Gold Hands Cost Reduction",
            "99% Diamond Hands Cost Reduction",
            "99% Emerald Hands Cost Reduction",
            "99% Ruby Hands Cost Reduction",
            "99% Saphire Hands Cost Reduction",
            "99% Void Hands Cost Reduction",
            "99% Rainbownite Hands Cost Reduction",
            "99% BlackStone Hands Cost Reduction",

            "More to come in the future!"



        };

        return contents[x];

    }


    public String getMonkiDeductionUpgradeText(int x){
        string[] contents = new string[]{
            "99% Marmocets Workers Cost Reduction",
            "99% Capuchin Workers Cost Reduction",
            "99% Bonobo Workers Cost Reduction",
            "99% Orangutan Workers Cost Reduction",
            "99% Baboon Workers Cost Reduction",
            "99% Chimpanzee Workers Cost Reduction",
            "99% Mandrill Workers Cost Reduction",
            "99% Gelada Workers Cost Reduction",
            "99% Gorilla Workers Cost Reduction",
            "99% Homo Habilis Workers Cost Reduction",
            "99% Homo Erectus Workers Cost Reduction",
            "99% Homo Sapian Workers Cost Reduction",


            "More to come in the future!"



        };

        return contents[x];

    }


    public String getAllUpgradeText(int x){
        string[] contents = new string[]{
            "2x All Hand Upgrades",
            "2x All Monki Upgrades",
            "2x BPC",
            "2x BPS",
            "2x All Hand Upgrades",
            "2x All Monki Upgrades",
            "2x BPC",
            "2x BPS",
            "2x All Hand Upgrades",
            "2x All Monki Upgrades",
            "2x BPC",
            "2x BPS",

            "More to come in the future!"


        };
        return contents[x];

    }


    



    //Gettings the cost functions

    public double getHandCost(int x){
        return 1e7 * Math.Pow(10, (x));
        
    }

    public double getMonkisCost(int x){
        return 5e7 * Math.Pow(10, (x));

    }

    public double getHandDeductionCost(int x){
        return 1e12 * Math.Pow(10, (x));
    }

    public double getMonkiDeductionCost(int x){
        return 5e12 * Math.Pow(10, (x));
        
    }

    public double getAllCost(int x){
        return 1e18 * Math.Pow(10, (x));
        
    }


    //makes sure that the upgrade is done.

    public void HandMultCheck(int x){
        if(x == 1){Hand.Hands[0].productionPerClick *=  2;}
        if(x == 2){Hand.Hands[1].productionPerClick *=  2;}
        if(x == 3){Hand.Hands[2].productionPerClick *=  2;}
        if(x == 4){Hand.Hands[3].productionPerClick *=  2;}
        if(x == 5){Hand.Hands[4].productionPerClick *=  2;}
        if(x == 6){Hand.Hands[5].productionPerClick *=  2;}
        if(x == 7){Hand.Hands[6].productionPerClick *=  2;}
        if(x == 8){Hand.Hands[7].productionPerClick *=  2;}
        if(x == 9){Hand.Hands[8].productionPerClick *=  2;}
        if(x == 10){Hand.Hands[9].productionPerClick *=  2;}
        if(x == 11){Hand.Hands[10].productionPerClick *=  2;}
        if(x == 12){Hand.Hands[11].productionPerClick *=  2;}
    }

    public void MonkiMultCheck(int x){
        if(x == 1){Monki.monkis[0].productionPerClick *=  2;}
        if(x == 2){Monki.monkis[1].productionPerClick *=  2;}
        if(x == 3){Monki.monkis[2].productionPerClick *=  2;}
        if(x == 4){Monki.monkis[3].productionPerClick *=  2;}
        if(x == 5){Monki.monkis[4].productionPerClick *=  2;}
        if(x == 6){Monki.monkis[5].productionPerClick *=  2;}
        if(x == 7){Monki.monkis[6].productionPerClick *=  2;}
        if(x == 8){Monki.monkis[7].productionPerClick *=  2;}
        if(x == 9){Monki.monkis[8].productionPerClick *=  2;}
        if(x == 10){Monki.monkis[9].productionPerClick *=  2;}
        if(x == 11){Monki.monkis[10].productionPerClick *=  2;}
        if(x == 12){Monki.monkis[11].productionPerClick *=  2;}
    }
    

    public void HandDeductionCheck(int x){
        if(x == 1){Hand.Hands[0].initialCost *= 0.01;}
        if(x == 2){Hand.Hands[1].initialCost *= 0.01;}
        if(x == 3){Hand.Hands[2].initialCost *= 0.01;}
        if(x == 4){Hand.Hands[3].initialCost *= 0.01;}
        if(x == 5){Hand.Hands[4].initialCost *= 0.01;}
        if(x == 6){Hand.Hands[5].initialCost *= 0.01;}
        if(x == 7){Hand.Hands[6].initialCost *= 0.01;}
        if(x == 8){Hand.Hands[7].initialCost *= 0.01;} 
        if(x == 9){Hand.Hands[8].initialCost *= 0.01;}
        if(x == 10){Hand.Hands[9].initialCost *= 0.01;}
        if(x == 11){Hand.Hands[10].initialCost *= 0.01;}
        if(x == 12){Hand.Hands[11].initialCost *= 0.01;}
        
        Hand.iniUpdate(x-1); // this makes sure that the deduction text is updated.

                

    }


    public void MonkiDeductionCheck(int x){
        if(x == 1){Monki.monkis[0].initialCost *= 0.01;}
        if(x == 2){Monki.monkis[1].initialCost *= 0.01;}
        if(x == 3){Monki.monkis[2].initialCost *= 0.01;}
        if(x == 4){Monki.monkis[3].initialCost *= 0.01;}
        if(x == 5){Monki.monkis[4].initialCost *= 0.01;}
        if(x == 6){Monki.monkis[5].initialCost *= 0.01;}
        if(x == 7){Monki.monkis[6].initialCost *= 0.01;}
        if(x == 8){Monki.monkis[7].initialCost *= 0.01;}
        if(x == 9){Monki.monkis[8].initialCost *= 0.01;}
        if(x == 10){Monki.monkis[9].initialCost *= 0.01;}
        if(x == 11){Monki.monkis[10].initialCost *= 0.01;}
        if(x == 12){Monki.monkis[11].initialCost *= 0.01;}

        Monki.iniUpdate(x-1); // this makes sure that the deduction text is updated.

        
    }

    public void allUpgradesCheck(int x){
        if(x == 1){
            for(int i = 0; i <= 11; i++){
                Hand.Hands[i].productionPerClick *=  2;

            }
        }
        if(x == 2){
            for(int i = 0; i <= 11; i++){
                Monki.monkis[i].productionPerClick *= 2;
            }
        }
        if(x == 3){Hand.totalBPC *= 2;}
        if(x == 4){Monki.totalBPS *= 2;}



        if(x == 5){
            for(int i = 0; i <= 911; i++){
                Hand.Hands[i].productionPerClick *= 2;
            }}
        if(x == 6){
            for(int i = 0; i <= 11; i++){
                Monki.monkis[i].productionPerClick *= 2;
            }
        }
        if(x == 7){Hand.totalBPC *= 2;}
        if(x == 8){Monki.totalBPS *= 2;}



        if(x == 9){
            for(int i = 0; i <= 11; i++){
                Hand.Hands[i].productionPerClick *= 2;
            }
        }
        if(x == 10){
            for(int i = 0; i <= 11; i++){
                Monki.monkis[i].productionPerClick *= 2;
            }
        }
        if(x == 11){Hand.totalBPC *= 2;}
        if(x == 12){Monki.totalBPS *= 2;}

    }
    
}



