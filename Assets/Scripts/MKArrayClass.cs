using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MKArrayClass : MonoBehaviour
{
    public class MKHands
    {

        // this is for the Monkey Hands
        public string name;   // name of upgrade
        public double cost;    // cost of upgrade
        public int count;     // amount of upgrade
        public double initialCost; // initial cost of upgrade
        public float costMultiplier;
        public double productionPerClick;
        public TMP_Text countText;
        public TMP_Text costText;
        public TMP_Text productionText;

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
