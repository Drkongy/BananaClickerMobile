using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;




public class Controller : MonoBehaviour {
    //declares other scrips

    public BananaPrefix prefix;
    public SaveLoad save_Load;



    // declaring the text
    public TMP_Text txtBananas;
    public TMP_Text txtBPC;
    public TMP_Text txtBPS;

    // declaring the varibles
    public double bananas;
    public double BPC;
    public double BPS;

    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        bananas += BPS * Time.deltaTime; // This is the main function that increases the bananas every second.
        
        txtBPC.text = prefix.Suffix(BPC, "0.00", false) + " BPC";       // this updates the bpc with it's suffix
        txtBPS.text = prefix.Suffix(BPS, "0.00", false) + " BPS";       // this updates the bpc with a suffix

        txtBananas.text = prefix.Suffix(bananas, "0.00", true);

        // if bananas is not equal to one it will use a singular noun instead of a plural.
        if (bananas != 1)
        {
            txtBananas.text += " Bananas";
        }
        else
        {
            txtBananas.text += " Banana";
        }
    }

    public void bananaClick()   // method that increases the bananas every time you click on the bananas.
    {
        bananas += BPC;
        txtBananas.text = bananas + " Bananas";


    }



}
    