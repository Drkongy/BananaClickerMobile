using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace DanielLochner.Assets.SimpleSideMenu;


public class UI_Layers : MonoBehaviour
{


    public SaveLoad sl; // Links to the save load script
    public Controller main; // Links to the main controller scipt
    public Prestige p; // for getting prestige values

    
    public GameObject Hands;
    public GameObject Monkis;
    public GameObject Upgrades;
    public GameObject Prestige;


    // the collider.tag method checks the tag of the collider, so when it's inside of the rigid body the if statement will be specific to the collider and the tag.
    
    public void Start()
    {
        //sl.outSideLoad(); // loads all of the varibles and data and such.

    }
    
    
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Hands"){
            Monkis.SetActive(false); 
            Upgrades.SetActive(false);
            Prestige.SetActive(false);
        }

        if(collider.tag == "Monkis"){
            Hands.SetActive(false);
            Upgrades.SetActive(false);
            Prestige.SetActive(false);
        }
        

        if(collider.tag == "Upgrades"){
            Hands.SetActive(false);
            Monkis.SetActive(false);
            Prestige.SetActive(false);        
        }

        if(collider.tag == "Prestige"){
            Hands.SetActive(false);
            Monkis.SetActive(false);
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

        // if(p.prestige_no >0){
        //     Prestige.SetActive(false);
        // }
    }

}
