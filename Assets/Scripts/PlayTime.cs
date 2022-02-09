using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PlayTime : MonoBehaviour
{
    private const string SAVESEPERATOR = ",,,"; // this splits all of the text up so i can save seperate varibles.
    public DateTime dt = DateTime.Now; // time right now
    public DateTime dt2 = new DateTime(); // time when the game was last on.

    private long seconds;
    private long minutes;
    private long hours;
    private long days;
    void Start()
    {
        if(File.Exists(Application.persistentDataPath + "/PlayTime.json")){
            load();
        } else{
            save();
            load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save(){
        // creates a string that stores all the date contents
        dt = DateTime.Now;
        string[] contents = new string[]{
            ""+dt.ToString()

        };
        string saveString = string.Join(SAVESEPERATOR, contents);
        File.WriteAllText(Application.persistentDataPath + "/PlayTime.json", saveString); // saved to a file with a seprator which makes it easier to load the individuak varuibles.
    }

    public void load(){
        try{
            string saveString = File.ReadAllText(Application.persistentDataPath + "/PlayTime.json");  //reads all of the data from the file
            string[] contents; // initilises string
            contents = new string[3];  // declares the string
            contents = saveString.Split(new[] { SAVESEPERATOR }, System.StringSplitOptions.None); // splits all of the data into the strings so that it can be parsed.

            dt2 = DateTime.Parse(contents[0]);
        }catch(IOException e){ // this IOException is for when the file does not exist.
            Debug.Log(e);
            File.WriteAllText(Application.persistentDataPath + "/PlayTime.json", "PlayTime File Created!"); 

        }
    }

    public string time(){
        dt = DateTime.Now;
        TimeSpan ts = dt - dt2;
        string tt = ts.TotalSeconds.ToString("0");
        long prestigeTime = long.Parse(tt);
        seconds = prestigeTime % 60;
        minutes = (prestigeTime / 60) % 60;
        hours = (prestigeTime / 3600) % 24;
        days = prestigeTime / 86400;
        if(minutes == 0){
            return seconds + " Seconds";
        }else if(hours == 0) {
            return minutes + " minutes and " + seconds + " Seconds";
        }else if(days == 0){
            return hours+ " hours, " + minutes + " minutes and " + seconds + " Seconds";
        }else {
            return days + " days, " +hours+ " hours, " + minutes + " minutes and " + seconds + " Seconds";
        }
    }

}
