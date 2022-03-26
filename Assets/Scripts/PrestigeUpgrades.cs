using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.IO;

public class PrestigeUpgrades : MonoBehaviour
{
    // Links to other scripts
    public Controller main; // Links to the main controller scipt
    public MKHands Hand;    // links the MKHands script to this file.
    public MKMonkis Monki;  // links to the MKMonkis script.
    public BananaPrefix prefix;  //Links the Prefix script to this
    public AmountsLoop AL;   // for the amount multiples
    public Prestige p; // For the prestige script
    public Milestones miles; // For the milestones script
    public Managers managers; // For the managers script
    // save / load Varibles to
    private const string SAVESEPERATOR = ",,,"; // this splits all of the text up so i can save seperate varibles.
    // panel

    public GameObject panel; // this is for the panel that shriks 


    // Main Varibles
    public GameObject[] Buttons = new GameObject[30];
    public TMP_Text[] txtCost = new TMP_Text[30];
    public TMP_Text[] upgrText = new TMP_Text[3];

    public TMP_Text txtIntelligence;


    public double Intelligence;
    public double Prestige_Multi;

    public double[] cost;
    public double[] gains;

    public int upgradeNo = 0;  // This is the amount of upgrades that has already been bought

    // Start is called before the first frame update
    void Start()
    {
        p.load(); // loads the prestige file, since this file loads before that file.
        if(File.Exists(Application.persistentDataPath + "/PrestigeUpgrades.json")){
            load();
        } else{
            string[] contents = new string[]{
                "0"
            };
            string saveString = string.Join(SAVESEPERATOR, contents);
            File.WriteAllText(Application.persistentDataPath + "/PrestigeUpgrades.json", saveString); 
        }
        
        // Initializes all of the costs.
        cost[0] = 1;
        cost[1] = 5;
        cost[2] = 10;
        cost[3] = 25;
        cost[4] = 50;
        cost[5] = 100;
        cost[6] = 150;
        cost[7] = 250;
        cost[8] = 500;
        cost[9] = 1000;
        cost[10] = 2500;
        cost[11] = 5000;
        cost[12] = 7500;
        cost[13] = 25000;
        cost[14] = 50000;
        cost[15] = 100000;
        cost[16] = 250000;
        cost[17] = 300000;
        cost[18] = 500000;
        cost[19] = 1e7;
        cost[20] = 2.5e7;
        cost[21] = 5e7;
        cost[22] = 1e8;
        cost[23] = 5e8;
        cost[24] = 1e9;
        cost[25] = 2.5e9;
        cost[26] = 6.66e9;
        cost[27] = 1e10;
        cost[28] = 1e12;














        gains[0] = 1e9 * (1 + (p.Intelligence * (p.Prestige_Multi /100)));

        // Updates all of the prestige shop texts.

        txtUpdate();
        objChecker();
        panelSizeUpdate();


    }

    // updates all of the text

    public void txtUpdate(){
        txtIntelligence.text = "Intelligence: " + prefix.Suffix(p.Intelligence, "0.0", false);
        for(int i = 0; i <= 28; i++){
            txtCost[i].text = "Cost: " + prefix.Suffix(cost[i], "0.0", false) + " Intelligence";
        }
        upgrText[0].text = "Gain " + prefix.Suffix(gains[0], "0.0", false) + " Bananas";
        p.save();   // saves the prestige data.
        p.txtUpdate();  //updates all of the prestige data.
        managers.txtIntelligenceUpdate(); // updates the intelligence txt

    }

    public void txtIntelligenceUpdate(){
        txtIntelligence.text = "Intelligence: " + prefix.Suffix(p.Intelligence, "0.0", false);
    }



    // this is for the saving and loading for all of the data, so that objects are not repetedly bought
    public void save(){
        // creates a string that stores all the data
        string[] contents = new string[]{
            ""+upgradeNo.ToString()
        };
        string saveString = string.Join(SAVESEPERATOR, contents);
        File.WriteAllText(Application.persistentDataPath + "/PrestigeUpgrades.json", saveString); 
    }

    public void load(){
        try{
            string saveString = File.ReadAllText(Application.persistentDataPath + "/PrestigeUpgrades.json");  //reads all of the data from the file
            string[] contents; // initilises string
            contents = new string[3];  // declares the string
            contents = saveString.Split(new[] { SAVESEPERATOR }, System.StringSplitOptions.None); // splits all of the data into the strings so that it can be parsed.      
            upgradeNo = int.Parse(contents[0]);
        }catch(IOException e){ // this IOException is for when the file does not exist.
            Debug.Log(e);
            File.WriteAllText(Application.persistentDataPath + "/PrestigeUpgrades.json", "0");         
        }
    }

    //this hides the buttons that have already been bought 

    public void objChecker(){
        if(upgradeNo != 0){
            for(int i = 0; i <= upgradeNo-1; i++){
                Buttons[i].SetActive(false);
            }
        }

    }
    // this is for when the back button is pressed. makes sure that the main intelligence updates.
    public void btnBack(){
        p.txtUpdate();
    }

    // method is used to decrease the size of the panel.
    public void panelSizeUpdate(){
        // If you want to change it in pixels
        float height = 5250 - (upgradeNo*175);
        panel.GetComponent<RectTransform>().sizeDelta = new Vector2(720, height);
    }

    // for my ocd, Makes the code cleaner and makes it so that there is less lines of code. 
    private void OCD(){
        upgradeNo++;
        save();
        txtUpdate();
        panelSizeUpdate();
        AL.BUUpdate();
    }
    // made this so that the code is cleaner and so that the code is easier to read.
    private void HandOCD(int y){
        for (int i = 0;i <= 99; i++){
            Hand.totalBPC += Hand.Hands[y].HMProduction;
            Hand.Hands[y].count += 1;
            Hand.Hands[y].productionPerClick = miles.milesStoness(Hand.Hands[y].count, Hand.Hands[y].productionPerClick);
            Hand.Hands[y].HMProduction = Hand.Hands[y].productionPerClick * (1 + (p.Intelligence * (p.Prestige_Multi /100)));
            Hand.Hands[y].cost = Hand.Hands[y].initialCost * (Math.Pow((1 + (Hand.Hands[y].costMultiplier) / (1 + (Hand.Hands[y].count) / (1000000000))), Hand.Hands[y].count));
        }
    }

    private void MonkiOCD(int y){
        for (int i = 0;i <= 99; i++){
            Monki.totalBPS += Monki.monkis[y].HMProduction;
            Monki.monkis[y].count += 1;
            Monki.monkis[y].productionPerClick = miles.milesStoness(Monki.monkis[y].count, Monki.monkis[y].productionPerClick);
            Monki.monkis[y].HMProduction = Monki.monkis[y].productionPerClick * (1 + (p.Intelligence * (p.Prestige_Multi /100)));
            Monki.monkis[y].cost = Monki.monkis[y].initialCost * (Math.Pow((1 + (Monki.monkis[y].costMultiplier) / (1 + (Monki.monkis[y].count) / (1000000000))), Monki.monkis[y].count));
        }

    }

    // methods for each of the individual buttons.
    public void zero(){
        int x = 0;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            for(int i = 0; i <= 11; i++){
                Hand.Hands[i].productionPerClick *=  3;
            }
            Hand.totalBPC *= 3;
            OCD();
        }
    }

    public void one(){
        int x = 1;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            for(int i = 0; i <= 11; i++){
                Monki.monkis[i].productionPerClick *= 3;
            }
            Monki.totalBPS *= 3;
            OCD();
        }
    }

    public void two(){
        int x = 2;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            main.bananas += gains[0];
            OCD();
        }
    }

    public void three(){
        int x = 3;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(0);     
            OCD();
        }
    }

    public void four(){
        int x = 4;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(0);
            OCD();
        }
    }

    public void five(){
        int x = 5;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(1);
            OCD();
        }
    }

    public void six(){
        int x = 6;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(1);
            OCD();
        }
    }


    public void seven(){
        int x = 7;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(2);
            OCD();
        }
    }

    public void eight(){
        int x = 8;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(2);
            OCD();
        }
    }


    public void nine(){
        int x = 9;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(3);
            OCD();
        }
    }

    public void ten(){
        int x = 10;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(3);
            OCD();
        }
    }

    public void eleven(){
        int x = 11;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(4);
            OCD();
        }
    }

    public void twelve(){
        int x = 12;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(4);
            OCD();
        }
    }

    public void thirteen(){
        int x = 13;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(5);
            OCD();
        }
    }

    public void fourteen(){
        int x = 14;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(5);
            OCD();
        }
    }


    public void fifteen(){
        int x = 15;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            p.Prestige_Multi += 1; // this is the multiplier one just in case u get trouble seeing it :)
            OCD();
        }
    }

    public void sixteen(){
        int x = 16;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(6);
            OCD();
        }
    }

    public void seventeen(){
        int x = 17;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(6);
            OCD();
        }
    }

    public void eighteen(){
        int x = 18;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(7);
            OCD();
        }
    }

    public void nineteen(){
        int x = 19;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(7);
            OCD();
        }
    }

    public void twenty(){
        int x = 20;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(8);
            OCD();
        }
    }

    public void twentyone(){
        int x = 21;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(8);
            OCD();
        }
    }


    public void twentytwo(){
        int x = 22;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(9);
            OCD();
        }
    }

    public void twentythree(){
        int x = 23;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(9);
            OCD();
        }
    }

    public void twentyfour(){
        int x = 24;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(10);
            OCD();
        }
    }

    public void twentyfive(){
        int x = 25;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(10);
            OCD();
        }
    }

    public void twentysix(){
        int x = 26;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            HandOCD(11);
            OCD();
        }
    }

    public void twentyseven(){
        int x = 27;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            MonkiOCD(11);
            OCD();
        }
    }

    public void twentyeight(){
        int x = 28;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            Buttons[x].SetActive(false);
            p.Prestige_Multi += 3; // this is the multiplier one just in case u get trouble seeing it :)
            OCD();
        }
    }

    



}


