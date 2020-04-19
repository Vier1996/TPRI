using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseEquipmentsHelper : MonoBehaviour
{
    public static int GetEqupmentDefense()
    {
        int equipmentsDefense = 0;
        
        if (PlayerPrefs.GetInt("Helmet_upg1") == 1)
            equipmentsDefense += 1;
        if (PlayerPrefs.GetInt("Helmet_upg2") == 1)
            equipmentsDefense += 3;
        if (PlayerPrefs.GetInt("Helmet_upg3") == 1)
            equipmentsDefense += 5;
        
        if (PlayerPrefs.GetInt("Mask_upg1") == 1)
            equipmentsDefense += 1;
        if (PlayerPrefs.GetInt("Mask_upg2") == 1)
            equipmentsDefense += 3;
        if (PlayerPrefs.GetInt("Mask_upg3") == 1)
            equipmentsDefense += 5;
        
        if (PlayerPrefs.GetInt("Gloves_upg1") == 1)
            equipmentsDefense += 1;
        if (PlayerPrefs.GetInt("Gloves_upg2") == 1)
            equipmentsDefense += 3;
        if (PlayerPrefs.GetInt("Gloves_upg3") == 1)
            equipmentsDefense += 5;
        
        if (PlayerPrefs.GetInt("Butcher_upg1") == 1)
            equipmentsDefense += 1;
        if (PlayerPrefs.GetInt("Butcher_upg2") == 1)
            equipmentsDefense += 3;
        if (PlayerPrefs.GetInt("Butcher_upg3") == 1)
            equipmentsDefense += 5;
        
        if (PlayerPrefs.GetInt("Suit_upg1") == 1)
            equipmentsDefense += 1;
        if (PlayerPrefs.GetInt("Suit_upg2") == 1)
            equipmentsDefense += 3;
        if (PlayerPrefs.GetInt("Suit_upg3") == 1)
            equipmentsDefense += 5;
        
        if (PlayerPrefs.GetInt("Boots_upg1") == 1)
            equipmentsDefense += 1;
        if (PlayerPrefs.GetInt("Boots_upg2") == 1)
            equipmentsDefense += 3;
        if (PlayerPrefs.GetInt("Boots_upg3") == 1)
            equipmentsDefense += 5;
        
        return equipmentsDefense;
    }
}
