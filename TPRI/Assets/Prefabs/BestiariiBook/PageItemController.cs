using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PageItemController : MonoBehaviour
{
    [SerializeField] private Sprite medicine;

    [SerializeField] private TextMeshProUGUI name;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("Key_" + name.text) == 1)
        {
            GetComponent<Image>().sprite = medicine;
        }  
    }
    
}
