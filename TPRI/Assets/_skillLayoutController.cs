using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _skillLayoutController : MonoBehaviour
{
    [SerializeField] private GameObject Layout1;
    
    [SerializeField] private GameObject Layout2;
    [SerializeField] private GameObject Layout3;
    
    [SerializeField] private GameObject Layout4;
    
    [SerializeField] private GameObject Layout5;
    [SerializeField] private GameObject Layout6;
    [SerializeField] private GameObject Layout7;
    [SerializeField] private GameObject Layout8;
    
    [SerializeField] private GameObject Layout9;

    private void Start()
    {
        Layout1.SetActive(false);
        Layout2.SetActive(false);
        Layout3.SetActive(false);
        Layout4.SetActive(false);
        
        Layout5.SetActive(false);
        Layout6.SetActive(false);
        Layout7.SetActive(false);
        Layout8.SetActive(false);
        
        Layout9.SetActive(false);
    }

    private void Update()
    {
        SkillCheker();
    }

    private void SkillCheker()
    {
        if (PlayerPrefs.GetInt("1_skl") == 1)
        {
            Layout1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("2_skl") == 1)
        {
            Layout2.SetActive(true);
            Layout3.SetActive(true);
        }
        if (PlayerPrefs.GetInt("3_skl") == 1)
        {
            Layout4.SetActive(true);
            Layout7.SetActive(true);
        }
        if (PlayerPrefs.GetInt("4_skl") == 1)
        {
            Layout6.SetActive(true);
        }
        if (PlayerPrefs.GetInt("5_skl") == 1 && PlayerPrefs.GetInt("7_skl") == 1)
        {
            Layout5.SetActive(true);
        }
        if (PlayerPrefs.GetInt("8_skl") == 1)
        {
            Layout8.SetActive(true);
        }

        if (PlayerPrefs.GetInt("6_skl") == 1 && PlayerPrefs.GetInt("9_skl") == 1)
        {
            Layout9.SetActive(true);
        }
    }
    
}
