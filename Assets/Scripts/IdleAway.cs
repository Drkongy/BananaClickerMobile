using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Globalization;
//using System.DateTime;

public class IdleAway : MonoBehaviour
{
    public Controller main;  // links the main script to this file.
    public const string SAVESEPERATOR = ",,,"; // this splits all of the text up so i can save seperate varibles.
    private int Delay = 60; // in frames        

    private DateTime dt = DateTime.Now; // time right now
    private DateTime dt2 = new DateTime(); // time when the game was last on.

    private double BPS;

    public double b;
    // Start is called before the first frame update
    void Start()
    {
        //load();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % this.Delay != 0) return;  // makes sure that it's not updating every frame. makes sure that the game does not lag.
        saveTime();


    }


    public void saveTime(){
        // creates a string that stores all the date contents
        string[] contents = new string[]{
            ""+dt.ToString(),
            ""+main.BPS.ToString()

        };
        string saveString = string.Join(SAVESEPERATOR, contents);
        File.WriteAllText(Application.persistentDataPath + "/Idle.json", saveString); // saved to a file with a seprator which makes it easier to load the individuak varuibles.
    }

    public void load(){
        try{
            string saveString = File.ReadAllText(Application.persistentDataPath + "/Idle.json");  //reads all of the data from the file
            string[] contents; // initilises string
            contents = new string[5];  // declares the string
            contents = saveString.Split(new[] { SAVESEPERATOR }, System.StringSplitOptions.None); // splits all of the data into the strings so that it can be parsed.


            dt2 = DateTime.Parse(contents[0]);
            BPS = double.Parse(contents[1]);
            
            // Gives bananas to the user
            TimeSpan ts = dt - dt2;  // gets the difference in time
            b = (BPS * ts.TotalSeconds); // gets the amount of seconds away and multiplies it by the BPS
            main.bananas += b;      
            // adds the BPS made away to the bananas.
            Debug.Log("Been away for: " + ts.TotalSeconds + " Seconds. You have made : "  + b + " White away");
        }catch(IOException e){ // this IOException is for when the file does not exist.
            Debug.Log(e);
            File.WriteAllText(Application.persistentDataPath + "/Idle.json", "Idle File Created!"); 
        }
    }
}
