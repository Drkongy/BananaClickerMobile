using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
using System.Globalization;



public class Prestige : MonoBehaviour
{

    public Controller main;  // links the main script to this
    public BananaPrefix prefix;  //Links the Prefix script to this
    public SaveLoad SL; // links the saveLoad file to this file.
    public PlayTime PT;
    


    public const string SAVESEPERATOR = ",,,"; // this splits all of the text up so i can save seperate varibles.


    // these are the main varibles
    public int prestige_no;     // the amount of times player has prestiged
    public double Intelligence;     // the current amout of intlligence you have
    private double futureIntelligence;       // calculation of intlligence you will have after the prestige.
    public double Prestige_Multi;   // the multiplier you will get on the shops

    public TMP_Text txtPrestigeNO;      // updates the prestigeNo txt in game
    public TMP_Text txtIntelligence;    // updates the Intelligence txt in game
    public TMP_Text txtPrestigeMulti;   // updates the prestige Multiplier txt in game
    public TMP_Text txtFutureIntelligence; // updates the Future intlligence txt in game
    public TMP_Text txtPrestigeTime; // updates the Future intlligence txt in game




    private int Delay = 60; // in frames        



    void Start(){
        txtUpdate();
    }
    void Update()
    {
        if (Time.frameCount % this.Delay != 0) return;  // makes sure that it's not updating every frame. makes sure that the game does not lag.
        //futureIntelligence = main.bananas / 1e39; // old version of prestige.
        futureIntelligence = 500 * (System.Math.Sqrt(main.bananas/1e45));
        txtFutureIntelligence.text = "You can prestige with " + prefix.Suffix(futureIntelligence, "0.00", true) + " Intelligence";
        time();
    }


    public void btnPrestige(){
        Debug.Log(futureIntelligence.ToString());
        if(futureIntelligence >= 0.5){
            Intelligence += futureIntelligence;
            prestige_no++;
            Restart();

        }
        txtUpdate();
    }

    public void txtUpdate(){
        txtPrestigeNO.text = "Prestige: " + prestige_no.ToString();
        txtIntelligence.text = "Total Intelligence: " + prefix.Suffix(Intelligence, "0.00", true);
        txtPrestigeMulti.text = "% Per Intelligence \n" + Prestige_Multi.ToString() + "%";


    }


    public void Restart(){
        string filePath = Application.persistentDataPath + "/save.json";
        File.Delete(filePath);
        string filePath2 = Application.persistentDataPath + "/Idle.json";
        File.Delete(filePath2);
        string filePath3 = Application.persistentDataPath + "/PrestigeUpgrades.json";
        File.Delete(filePath3);


        Prestige_Multi = 1;
        
        save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }



    public void save(){
        // creates a string that stores all the date contents
        string[] contents = new string[]{
            ""+prestige_no.ToString(),
            ""+Intelligence.ToString(),
            ""+futureIntelligence.ToString(),
            ""+Prestige_Multi.ToString(),
        };
        string saveString = string.Join(SAVESEPERATOR, contents);
        File.WriteAllText(Application.persistentDataPath + "/Prestige.json", saveString); // saved to a file with a seprator which makes it easier to load the individuak varuibles.
    }

    public void load(){
        try{
            string saveString = File.ReadAllText(Application.persistentDataPath + "/Prestige.json");  //reads all of the data from the file
            string[] contents; // initilises string
            contents = new string[6];  // declares the string
            contents = saveString.Split(new[] { SAVESEPERATOR }, System.StringSplitOptions.None); // splits all of the data into the strings so that it can be parsed.


            prestige_no = int.Parse(contents[0]);
            Intelligence = double.Parse(contents[1]);
            futureIntelligence = double.Parse(contents[2]);
            Prestige_Multi = double.Parse(contents[3]);


            

        }catch(IOException e){ // this IOException is for when the file does not exist.
            Prestige_Multi = 1;
            Debug.Log(e);
        }

    }

    public void time(){
        //Debug.Log(PT.time());
        txtPrestigeTime.text = "Prestige time: " + PT.time();

        
    }










}
