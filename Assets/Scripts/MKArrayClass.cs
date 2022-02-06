using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MKArrayClass : MonoBehaviour
{
    public class MKHands
    {

        // this is array class is designed for the monki hands, but also works for the Monkis.
        public string name;   // name of upgrade
        public double cost;    // cost of upgrade
        public int count;     // amount of upgrade
        public double initialCost; // initial cost of upgrade
        public float costMultiplier; // multiplier 
        public double productionPerClick; // how much is made every time you click / how much is made per second
        public TMP_Text countText;  // the text varible for the amount of stores owned.
        public TMP_Text costText;   // the text varible for the cost of the stores.
        public TMP_Text productionText; // the text varible for the production of the stores.

        public MKHands(string handName, double handCost, int handAmount, double initial_cost, float multi, double HandProduction, TMP_Text txtHandCount, TMP_Text txtHandCost, TMP_Text txtProduction)
        {
            name = handName; 
            cost = handCost;  //saves
            count = handAmount;  //saves
            initialCost = initial_cost; //initial cost of upgrade //saves
            costMultiplier = multi; 
            productionPerClick = HandProduction; //saves
            countText = txtHandCount;
            costText = txtHandCost;
            productionText = txtProduction;

        }
    }















}
