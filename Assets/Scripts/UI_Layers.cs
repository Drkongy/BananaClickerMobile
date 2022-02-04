using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace DanielLochner.Assets.SimpleSideMenu;


public class UI_Layers : MonoBehaviour
{



    public GameObject Hands;
    public GameObject Monkis;
    public GameObject Upgrades;
    private bool a = false;
    private bool b = false;
    private bool c = false;



    


    // Update is called once per frame
    void Update()
    {
        
    }


    public void handsPressed(){
        if(a == false){
            Monkis.SetActive(false);
            Upgrades.SetActive(false);
            a = true;
        } else if(a == true){
            Monkis.SetActive(true);
            Upgrades.SetActive(true);
            a = false;
        }


    }

    public void monkiPressed(){

        if(b == false){
            Hands.SetActive(false);
            Upgrades.SetActive(false);
            b = true;
        } else if(b == true){
            Hands.SetActive(true);
            Upgrades.SetActive(true);
            b = false;
        }


        
    }

    public void upgradesPressed(){

        if(c == false){
            Hands.SetActive(false);
            Monkis.SetActive(false);
            c = true;
        } else if(c == true){
            Hands.SetActive(true);
            Monkis.SetActive(true);
            c = false;
        }


    }

}
