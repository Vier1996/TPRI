using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _pageController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI name;
    public TextMeshProUGUI[] symptones;
    private string[] oldSymptomesname;

    private string closed = "???";
    private string empty = " ";
    private string oldName;

    private void Awake()
    {
        //_DropProgress.DporBestiarii(0);
        //_DropProgress.DropSymptomys(0);
        
        oldSymptomesname = new string[symptones.Length];
        oldName = name.text;

        for (int i = 0; i < symptones.Length; i++)
        {
            oldSymptomesname[i] = symptones[i].text;
        }
        
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("Key_" + name.text.ToLower()) == 0)
        {
            name.text = closed;
        }
        
        for (int i = 0; i < symptones.Length; i++)
        {
            if(PlayerPrefs.GetInt("Key_" + symptones[i].text) == 0)
            {
                symptones[i].text = empty;
            }
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Key_" + name.text.ToLower()) == 1)
        {
            name.text = oldName;
        }
    }

    private void namesController()
    {
        for (int i = 0; i < symptones.Length; i++)
        {
            if(PlayerPrefs.GetInt("Key_" + symptones[i].text) == 1)
            {
                symptones[i].text = oldSymptomesname[i];
            }
        }
    }
}
