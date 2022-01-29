using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Globalization;


public class SaveLoad : MonoBehaviour
{
    public Controller main;  // links the main script to this file.
    public MKHands Hand;    // links the MKHands script to this file.
    public MKMonkis Monki;  // links the MKMonki script to this file.
    public IdleAway IA;

    private int Delay = 60; // in frames        
    public const string SAVESEPERATOR = ",,,"; // this splits all of the text up so i can save seperate varibles.

    public void Start()
    {
        //if(main.bananas != 0 && main.BPC != 1){
        Load();
        IA.load(); // loads the Idle time file.
        //}
        
    }
    public void Update()
    {
        if (Time.frameCount % this.Delay != 0) return;
        Save();

        
    }
    public void Save(){
        Debug.Log("Saved");
        //Debug.Log(Hand.OriginalHandCost[0]);
        string[] contents = new string[]{
            //main data
            ""+main.bananas.ToString("0." + new string('#', 399)),
            ""+main.BPC.ToString("0." + new string('#', 399)),
            ""+main.BPS.ToString("0." + new string('#', 399)),
            ""+Hand.totalBPC.ToString("0." + new string('#', 399)),
            ""+Monki.totalBPS.ToString("0." + new string('#', 399)),

            //Monki hands
            ""+Hand.Hands[0].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[0].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[0].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[1].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[1].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[1].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[2].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[2].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[2].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[3].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[3].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[3].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[4].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[4].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[4].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[5].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[5].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[5].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[6].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[6].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[6].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[7].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[7].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[7].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[8].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[8].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[8].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[9].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[9].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[9].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[10].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[10].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[10].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[11].count.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[11].cost.ToString("0." + new string('#', 399)),
            ""+Hand.Hands[11].productionPerClick.ToString("0." + new string('#', 399)),
            

            // Monkis Workers
            ""+Monki.monkis[0].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[0].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[0].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[1].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[1].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[1].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[2].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[2].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[2].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[3].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[3].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[3].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[4].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[4].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[4].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[5].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[5].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[5].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[6].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[6].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[6].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[7].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[7].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[7].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[8].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[8].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[8].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[9].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[9].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[9].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[10].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[10].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[10].productionPerClick.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[11].count.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[11].cost.ToString("0." + new string('#', 399)),
            ""+Monki.monkis[11].productionPerClick.ToString("0." + new string('#', 399))
        };
        string saveString = string.Join(SAVESEPERATOR, contents);
        File.WriteAllText(Application.persistentDataPath + "/save.json", saveString);
    }

    public void Load(){
        Debug.Log("Loaded");
        //Debug.Log(Application.persistentDataPath);
        try{
            string saveString = File.ReadAllText(Application.persistentDataPath + "/save.json");  //reads all of the data from the file
            string[] contents; // initilises string
            contents = new string[80];  // declares the string
            contents = saveString.Split(new[] { SAVESEPERATOR }, System.StringSplitOptions.None); // splits all of the data into the strings so that it can be parsed.
            //Debug.Log(Application.persistentDataPath);

            // assigning the values to the varibles from the array list:
            //main data
            main.bananas = double.Parse(contents[0], CultureInfo.InvariantCulture);
            main.BPC = double.Parse(contents[1], CultureInfo.InvariantCulture);
            main.BPS = double.Parse(contents[2], CultureInfo.InvariantCulture);
            Hand.totalBPC = double.Parse(contents[3], CultureInfo.InvariantCulture);
            Monki.totalBPS = double.Parse(contents[4], CultureInfo.InvariantCulture);

            //monki Hands

            Hand.Hands[0].count = int.Parse(contents[5]);
            Hand.Hands[0].cost = double.Parse(contents[6]);
            Hand.Hands[0].productionPerClick = double.Parse(contents[7]);
            Hand.Hands[1].count = int.Parse(contents[8]);
            Hand.Hands[1].cost = double.Parse(contents[9]);
            Hand.Hands[1].productionPerClick = double.Parse(contents[10]);
            Hand.Hands[2].count = int.Parse(contents[11]);
            Hand.Hands[2].cost = double.Parse(contents[12]);
            Hand.Hands[2].productionPerClick = double.Parse(contents[13]);
            Hand.Hands[3].count = int.Parse(contents[14]);
            Hand.Hands[3].cost = double.Parse(contents[15]);
            Hand.Hands[3].productionPerClick = double.Parse(contents[16]);
            Hand.Hands[4].count = int.Parse(contents[17]);
            Hand.Hands[4].cost = double.Parse(contents[18]);
            Hand.Hands[4].productionPerClick = double.Parse(contents[19]);
            Hand.Hands[5].count = int.Parse(contents[20]);
            Hand.Hands[5].cost = double.Parse(contents[21]);
            Hand.Hands[5].productionPerClick = double.Parse(contents[22]);
            Hand.Hands[6].count = int.Parse(contents[23]);
            Hand.Hands[6].cost = double.Parse(contents[24]);
            Hand.Hands[6].productionPerClick = double.Parse(contents[25]);
            Hand.Hands[7].count = int.Parse(contents[26]);
            Hand.Hands[7].cost = double.Parse(contents[27]);
            Hand.Hands[7].productionPerClick = double.Parse(contents[28]);
            Hand.Hands[8].count = int.Parse(contents[29]);
            Hand.Hands[8].cost = double.Parse(contents[30]);
            Hand.Hands[8].productionPerClick = double.Parse(contents[31]);
            Hand.Hands[9].count = int.Parse(contents[32]);
            Hand.Hands[9].cost = double.Parse(contents[33]);
            Hand.Hands[9].productionPerClick = double.Parse(contents[34]);
            Hand.Hands[10].count = int.Parse(contents[35]);
            Hand.Hands[10].cost = double.Parse(contents[36]);
            Hand.Hands[10].productionPerClick = double.Parse(contents[37]);
            Hand.Hands[11].count = int.Parse(contents[38]);
            Hand.Hands[11].cost = double.Parse(contents[39]);
            Hand.Hands[11].productionPerClick = double.Parse(contents[40]);

            //Monki workers

            Monki.monkis[0].count = int.Parse(contents[41]);
            Monki.monkis[0].cost = double.Parse(contents[42]);
            Monki.monkis[0].productionPerClick = double.Parse(contents[43]);
            Monki.monkis[1].count = int.Parse(contents[44]);
            Monki.monkis[1].cost = double.Parse(contents[45]);
            Monki.monkis[1].productionPerClick = double.Parse(contents[46]);
            Monki.monkis[2].count = int.Parse(contents[47]);
            Monki.monkis[2].cost = double.Parse(contents[48]);
            Monki.monkis[2].productionPerClick = double.Parse(contents[49]);
            Monki.monkis[3].count = int.Parse(contents[50]);
            Monki.monkis[3].cost = double.Parse(contents[51]);
            Monki.monkis[3].productionPerClick = double.Parse(contents[52]);
            Monki.monkis[4].count = int.Parse(contents[53]);
            Monki.monkis[4].cost = double.Parse(contents[54]);
            Monki.monkis[4].productionPerClick = double.Parse(contents[55]);
            Monki.monkis[5].count = int.Parse(contents[56]);
            Monki.monkis[5].cost = double.Parse(contents[57]);
            Monki.monkis[5].productionPerClick = double.Parse(contents[58]);
            Monki.monkis[6].count = int.Parse(contents[59]);
            Monki.monkis[6].cost = double.Parse(contents[60]);
            Monki.monkis[6].productionPerClick = double.Parse(contents[61]);
            Monki.monkis[7].count = int.Parse(contents[62]);
            Monki.monkis[7].cost = double.Parse(contents[63]);
            Monki.monkis[7].productionPerClick = double.Parse(contents[64]);
            Monki.monkis[8].count = int.Parse(contents[65]);
            Monki.monkis[8].cost = double.Parse(contents[66]);
            Monki.monkis[8].productionPerClick = double.Parse(contents[67]);
            Monki.monkis[9].count = int.Parse(contents[68]);
            Monki.monkis[9].cost = double.Parse(contents[69]);
            Monki.monkis[9].productionPerClick = double.Parse(contents[70]);
            Monki.monkis[10].count = int.Parse(contents[71]);
            Monki.monkis[10].cost = double.Parse(contents[72]);
            Monki.monkis[10].productionPerClick = double.Parse(contents[73]);
            Monki.monkis[11].count = int.Parse(contents[74]);
            Monki.monkis[11].cost = double.Parse(contents[75]);
            Monki.monkis[11].productionPerClick = double.Parse(contents[76]);
            Debug.Log(Application.persistentDataPath);
        }catch(IOException e){  // this will happen if the file does not exist
            Debug.Log(e);
            File.WriteAllText(Application.persistentDataPath + "/save.json", "Save File Created!"); 
        }
    }
}