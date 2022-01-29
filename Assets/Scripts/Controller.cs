using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



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
        bananas += BPS * Time.deltaTime;
        
        txtBPC.text = prefix.Suffix(BPC, "0.00", false) + " BPC";
        txtBPS.text = prefix.Suffix(BPS, "0.00", false) + " BPS";

        txtBananas.text = prefix.Suffix(bananas, "0.00", true);
        if (bananas != 1)
        {
            txtBananas.text += " Bananas";
        }
        else
        {
            txtBananas.text += " Banana";
        }
    }

    public void bananaClick()
    {
        bananas += BPC;
        txtBananas.text = bananas + " Bananas";


    }


 











}
    