using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class PrestigeMenu : MonoBehaviour
{
    public BananaPrefix prefix;  //Links the Prefix script to this
    public PlayTime PT; // this links the Playtime with this script
    


    private int prestige_no;
    private double Intelligence;
    private double futureIntelligence;
    private double Prestige_Multi;


    public TMP_Text txtPrestigeNO;      // updates the prestigeNo txt in game
    public TMP_Text txtIntelligence;    // updates the Intelligence txt in game
    public TMP_Text txtPrestigeMulti;   // updates the prestige Multiplier txt in game
    public TMP_Text txtFutureIntelligence; // updates the Future intlligence txt in game
    public TMP_Text txtTime;

    public const string SAVESEPERATOR = ",,,"; // this splits all of the text up so i can save seperate varibles.

    
    // Start is called before the first frame update
    void Start()
    {
        load();
        txtUpdate();
    }

    private void load(){
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
            Debug.Log(e);
        }


    }

    private void txtUpdate(){
        PT.load();
        txtPrestigeNO.text  = "The total times you've Prestiged: " + prestige_no.ToString();
        txtIntelligence.text = "Which means you have a total of " + prefix.Suffix(Intelligence, "0.00", true) + " Intelligence!";
        txtPrestigeMulti.text = "Your current multiplier is: \n" + Prestige_Multi.ToString() + "% / Intelligence";
        txtFutureIntelligence.text = "You've earned " + prefix.Suffix(futureIntelligence, "0.00", true) + " Intelligence!";
        txtTime.text = "You've been playing this prestige for: " + PT.time() + "!";
        Debug.Log(PT.time());
    }




}
