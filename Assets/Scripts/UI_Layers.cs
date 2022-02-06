using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace DanielLochner.Assets.SimpleSideMenu;


public class UI_Layers : MonoBehaviour
{
    public GameObject Hands;
    public GameObject Monkis;
    public GameObject Upgrades;

    // the collider.tag method checks the tag of the collider, so when it's inside of the rigid body the if statement will be specific to the collider and the tag.
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Hands"){
            Monkis.SetActive(false); 
            Upgrades.SetActive(false);
        }

        if(collider.tag == "Monkis"){
            Hands.SetActive(false);
            Upgrades.SetActive(false);
        }
        

        if(collider.tag == "Upgrades"){
            Hands.SetActive(false);
            Monkis.SetActive(false);            
        }
    }

    private void OnTriggerExit2D(Collider2D Collider)  // this happenns when you leave the 2d box collider.
    {

        //sets all the bottom buttons to true.
        Hands.SetActive(true);
        Monkis.SetActive(true);
        Upgrades.SetActive(true);
    }



    



    

}
