using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _pageController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI name;

    private string closed = "???";
    private string empty = " ";
    private string oldName;

    private void Awake()
    {
        oldName = name.text;
        //_DropProgress.DporBestiarii(0);
        //_DropProgress.DropSymptomys(0);
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("Key_" + name.text.ToLower()) == 0)
        {
            name.text = closed;
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Key_" + name.text.ToLower()) == 1)
        {
            name.text = oldName;
        }
      
    }
}
