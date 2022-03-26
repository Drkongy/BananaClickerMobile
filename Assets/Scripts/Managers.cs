using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.IO;

public class Managers : MonoBehaviour
{
    
    [Header("Scripts    ")]

        // Links to other scripts
    public Controller main; // Links to the main controller scipt
    public MKHands Hand;    // links the MKHands script to this file.
    public MKMonkis Monki;  // links to the MKMonkis script.
    public BananaPrefix prefix;  //Links the Prefix script to this
    public AmountsLoop AL;   // for the amount multiples
    public Prestige p; // For the prestige script
    public Milestones miles; // For the milestones script
    public PrestigeUpgrades PU; // for the prestigeupgrades script to this

    // save / load Varibles to
    private const string SAVESEPERATOR = ",,,"; // this splits all of the text up so i can save seperate varibles.
    // panel

    //Managers Automate buying Monkis for you so you don't need to do it!
    [Header("Game Objects    ")]

    public GameObject panel; // this is for the panel that shriks 


    // Main Varibles
    public GameObject[] Buttons = new GameObject[12];
    [Header("Text    ")]

    public TMP_Text[] txtCost = new TMP_Text[12];
    public TMP_Text[] upgrText = new TMP_Text[12];
    public TMP_Text[] totalMPS = new TMP_Text[12];

    //[Space(25f)]    


    public TMP_Text txtIntelligence;

    [Header("Variables    ")]

    public double Intelligence;

    public double[] cost;
    public int[] UPS;
    public int[] total;
    public bool[] Active;
    public int priority = 0;  // the priority of what should be bought first.

    public int upgradeNo = 0;  // This is the amount of upgrades that has already been bought
    void Start()
    {

        p.load(); // loads the prestige file, since this file loads before that file.
        if(File.Exists(Application.persistentDataPath + "/Managers.json")){
            load();
        } else{
            cost[0] = 1e9;
            cost[1] = 1e10;
            cost[2] = 1e11;
            cost[3] = 1e12;
            cost[4] = 1e13;
            cost[5] = 1e14;
            cost[6] = 1e15;
            cost[7] = 1e16;
            cost[8] = 1e17;
            cost[9] = 1e18;
            cost[10] = 1e19;
            cost[11] = 1e20;
            for(int i = 0; i <= 11; i++){
                Active[i] = false;
            }
            
            bool txt = false;
            string[] contents = new string[]{
                cost[0].ToString(), cost[1].ToString(), cost[2].ToString(), cost[3].ToString(), cost[4].ToString(), cost[5].ToString(), cost[6].ToString(), cost[7].ToString(), cost[8].ToString(), cost[9].ToString(), cost[10].ToString(), cost[11].ToString(), 
                "1","1","1","1","1","1","1","1","1","1","1","1", // for UPS
                "0","0","0","0","0","0","0","0","0","0","0","0", // for total
                txt.ToString(),txt.ToString(),txt.ToString(),txt.ToString(),txt.ToString(),txt.ToString(),txt.ToString(),txt.ToString(),txt.ToString(),txt.ToString(),txt.ToString(),txt.ToString(),
                priority.ToString(), upgradeNo.ToString()
                
            };
            string saveString = string.Join(SAVESEPERATOR, contents);
            File.WriteAllText(Application.persistentDataPath + "/Managers.json", saveString); 

            load();
        }
        if(upgradeNo != 0){
            txtUpdate();

            
        }
        panelSizeUpdate();
    }

    private float nextActionTime = 0.0f;
    private float period = 1f;
    void Update()
    {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            // code will execute exactly once every second here within the method
            for(int i = 0; i <= 11; i++){
                if(Active[i] == true){
                    MonkiOCD(i, total[i]);
                    Debug.Log("Just gave an upgrade!");

                }
            }


        }
    }

    public void save(){
        // creates a string that stores all the data
        string[] contents = new string[]{
            cost[0].ToString(), cost[1].ToString(), cost[2].ToString(), cost[3].ToString(), cost[4].ToString(), cost[5].ToString(), cost[6].ToString(), cost[7].ToString(), cost[8].ToString(), cost[9].ToString(), cost[10].ToString(), cost[11].ToString(), 
            UPS[0].ToString(), UPS[1].ToString(), UPS[2].ToString(), UPS[3].ToString(), UPS[4].ToString(), UPS[5].ToString(), UPS[6].ToString(), UPS[7].ToString(), UPS[8].ToString(), UPS[9].ToString(), UPS[10].ToString(), UPS[11].ToString(), 
            total[0].ToString(), total[1].ToString(), total[2].ToString(), total[3].ToString(), total[4].ToString(), total[5].ToString(), total[6].ToString(), total[7].ToString(), total[8].ToString(), total[9].ToString(), total[10].ToString(), total[11].ToString(), 
            Active[0].ToString(), Active[1].ToString(), Active[2].ToString(), Active[3].ToString(), Active[4].ToString(), Active[5].ToString(), Active[6].ToString(), Active[7].ToString(), Active[8].ToString(), Active[9].ToString(), Active[10].ToString(), Active[11].ToString(), 
            priority.ToString(), upgradeNo.ToString()
        };
        string saveString = string.Join(SAVESEPERATOR, contents);
        File.WriteAllText(Application.persistentDataPath + "/Managers.json", saveString); 
    }

    public void load(){
        try{
            string saveString = File.ReadAllText(Application.persistentDataPath + "/Managers.json");  //reads all of the data from the file
            string[] contents; // initilises string
            contents = new string[50];  // declares the string
            contents = saveString.Split(new[] { SAVESEPERATOR }, System.StringSplitOptions.None); // splits all of the data into the strings so that it can be parsed.      
            // load all of the contents shit here.
            for(int i = 0; i <= 11; i++){
                cost[i] = double.Parse(contents[i]);
                UPS[i] = int.Parse(contents[i+12]);
                total[i] = int.Parse(contents[i+24]);
                Active[i] = bool.Parse(contents[i+ 36]);
            }

            priority = int.Parse(contents[48]);
            upgradeNo = int.Parse(contents[49]);
        }catch(IOException e){ // this IOException is for when the file does not exist.
            Debug.Log(e);
            File.WriteAllText(Application.persistentDataPath + "/Managers.json", "0");         
        }
    }


    public void txtUpdate(){
        txtIntelligence.text = "Intelligence: " + prefix.Suffix(p.Intelligence, "0.0", false);
        for(int i = 0; i <= 11; i++){
            totalMPS[i].text = Monki.monkis[i].name + " Dealer (" + total[i] + ")";
            upgrText[i].text = "Increase " + UPS[i] + " " + Monki.monkis[i].name + " Per Second";
            txtCost[i].text = "Cost: " + prefix.Suffix(cost[i], "0.0", false) + " Intelligence";
            PU.txtIntelligenceUpdate();
        }
        p.save();   // saves the prestige data.
        p.txtUpdate();  //updates all of the prestige data.

    }

    public void txtIntelligenceUpdate(){
        txtIntelligence.text = "Intelligence: " + prefix.Suffix(p.Intelligence, "0.0", false);

    }

    public void panelSizeUpdate(){
        // If you want to change it in pixels
        float height = 250 + (upgradeNo*125);
        panel.GetComponent<RectTransform>().sizeDelta = new Vector2(720, height);

        if(upgradeNo != 0){
            for(int i = 0; i <= upgradeNo; i++){
                Buttons[i].SetActive(true);
            }
        }

    }


    // for my ocd, Makes the code cleaner and makes it so that there is less lines of code. 
    private void OCD(){
        save();
        txtUpdate();
        panelSizeUpdate();
        AL.BUUpdate();
    }
    private void MonkiOCD(int y, int amount){
        for (int i = 0;i <= amount - 1; i++){
            if(main.bananas >= Monki.monkis[y].cost){
                main.bananas -= Monki.monkis[y].cost;
                Monki.totalBPS += Monki.monkis[y].HMProduction;
                Monki.monkis[y].count += 1;
                Monki.monkis[y].productionPerClick = miles.milesStoness(Monki.monkis[y].count, Monki.monkis[y].productionPerClick);
                Monki.monkis[y].HMProduction = Monki.monkis[y].productionPerClick * (1 + (p.Intelligence * (p.Prestige_Multi /100)));
                Monki.monkis[y].cost = Monki.monkis[y].initialCost * (Math.Pow((1 + (Monki.monkis[y].costMultiplier) / (1 + (Monki.monkis[y].count) / (1000000000))), Monki.monkis[y].count));
            }
        }
        AL.BUUpdate();
    }




    // methods for each individual Buttons
    public void zero(){
        int x = 0;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            if(!Buttons[x+1].activeSelf) { // if it's
                upgradeNo++;
                Buttons[x+1].SetActive(true); // adds the new button to the panel
                Active[x] = true;
            }
            OCD();
        }
    }



    public void one(){
        int x = 1;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            if(!Buttons[x+1].activeSelf) { // if it's
                upgradeNo++;
                Buttons[x+1].SetActive(true); // adds the new button to the panel
                Active[x] = true;
            }
            OCD();
        }
    }

    public void two(){
        int x = 2;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            if(!Buttons[x+1].activeSelf) { // if it's
                upgradeNo++;
                Buttons[x+1].SetActive(true); // adds the new button to the panel
                Active[x] = true;
            }
            OCD();
        }
    }

    public void three(){
        int x = 3;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            if(!Buttons[x+1].activeSelf) { // if it's
                upgradeNo++;
                Buttons[x+1].SetActive(true); // adds the new button to the panel
                Active[x] = true;
            }
            OCD();
        }
    }

    public void four(){
        int x = 4;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            if(!Buttons[x+1].activeSelf) { // if it's
                upgradeNo++;
                Buttons[x+1].SetActive(true); // adds the new button to the panel
                Active[x] = true;
            }
            OCD();
        }
    }

    public void five(){
        int x = 5;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            if(!Buttons[x+1].activeSelf) { // if it's
                upgradeNo++;
                Buttons[x+1].SetActive(true); // adds the new button to the panel
                Active[x] = true;
            }
            OCD();
        }
    }

    public void six(){
        int x = 6;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            if(!Buttons[x+1].activeSelf) { // if it's
                upgradeNo++;
                Buttons[x+1].SetActive(true); // adds the new button to the panel
                Active[x] = true;
            }
            OCD();
        }
    }

    public void seven(){
        int x = 7;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            if(!Buttons[x+1].activeSelf) { // if it's
                upgradeNo++;
                Buttons[x+1].SetActive(true); // adds the new button to the panel
                Active[x] = true;
            }
            OCD();
        }
    }

    public void eight(){
        int x = 8;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            if(!Buttons[x+1].activeSelf) { // if it's
                upgradeNo++;
                Buttons[x+1].SetActive(true); // adds the new button to the panel
                Active[x] = true;
            }
            OCD();
        }
    }

    public void nine(){
        int x = 9;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            if(!Buttons[x+1].activeSelf) { // if it's
                upgradeNo++;
                Buttons[x+1].SetActive(true); // adds the new button to the panel
                Active[x] = true;
            }
            OCD();
        }
    }


    public void ten(){
        int x = 10;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            if(!Buttons[x+1].activeSelf) { // if it's
                upgradeNo++;
                Buttons[x+1].SetActive(true); // adds the new button to the panel
                Active[x] = true;
            }
            OCD();
        }
    }

    public void eleven(){
        int x = 11;
        if(p.Intelligence >= cost[x]){
            p.Intelligence -= cost[x];
            cost[x] *= 1.75;
            total[x] += UPS[x];
            Active[x] = true;
            OCD();
        }
    }


}
