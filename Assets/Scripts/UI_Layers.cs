using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class UI_Layers : MonoBehaviour
{


    // public SaveLoad sl; // Links to the save load script
    // public Controller main; // Links to the main controller scipt
    
    public GameObject Hands;
    public GameObject Monkis;
    public GameObject Upgrades;
    public GameObject Prestige;
    public GameObject Managers;

    // random stuff 
    private int prestige_no; // the amount of times the person has prestiged.
    public const string SAVESEPERATOR = ",,,"; // this splits all of the text up so i can save seperate varibles.


    // the collider.tag method checks the tag of the collider, so when it's inside of the rigid body the if statement will be specific to the collider and the tag.
    
    public void Start()
    {
        //sl.outSideLoad(); // loads all of the varibles and data and such.

        load();
        if(prestige_no >= 5){
            Managers.SetActive(true);
        }else{
            Managers.SetActive(false);

        }

    }
    
    
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Hands"){
            Monkis.SetActive(false); 
            Upgrades.SetActive(false);
            Prestige.SetActive(false);
            Managers.SetActive(false);

        }

        if(collider.tag == "Monkis"){
            Hands.SetActive(false);
            Upgrades.SetActive(false);
            Prestige.SetActive(false);
            Managers.SetActive(false);

        }
        

        if(collider.tag == "Upgrades"){
            Hands.SetActive(false);
            Monkis.SetActive(false);
            Prestige.SetActive(false);
            Managers.SetActive(false);

        }

        if(collider.tag == "Prestige"){
            Hands.SetActive(false);
            Monkis.SetActive(false);
            Upgrades.SetActive(false);    
            Managers.SetActive(false);

        }

        if(collider.tag == "Managers"){
            Hands.SetActive(false);
            Monkis.SetActive(false);
            Prestige.SetActive(false);
            Upgrades.SetActive(false);        
        }


    }

    private void OnTriggerExit2D(Collider2D Collider)  // this happenns when you leave the 2d box collider.
    {

        //sets all the bottom buttons to true.
        Hands.SetActive(true);
        Monkis.SetActive(true);
        Upgrades.SetActive(true);
        Prestige.SetActive(true);
        if(prestige_no >= 5){
            Managers.SetActive(true);
        }


    }


    // loads the prestige no data since the prestige script object wants to take the piss.
    private void load(){
        try{
            string saveString = File.ReadAllText(Application.persistentDataPath + "/Prestige.json");  //reads all of the data from the file
            string[] contents; // initilises string
            contents = new string[2];  // declares the string
            contents = saveString.Split(new[] { SAVESEPERATOR }, System.StringSplitOptions.None); // splits all of the data into the strings so that it can be parsed.

            prestige_no = int.Parse(contents[0]);


        }catch(IOException e){ // this IOException is for when the file does not exist.
            Debug.Log(e);
        }


    }

}
