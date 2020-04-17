using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class _WorldController : MonoBehaviour
{
    private bool weDeadSoon = false;
    private int endDays = 0;

    [SerializeField] private GameObject scene;
    [SerializeField] private GameObject text;
    private string[] Dialogs = new string[3];

    private void Awake()
    {
        Dialogs[0] = "Шот хуево...";
        Dialogs[1] = "Чуствую что скоро сдохну";
        Dialogs[3] = "ОТЪЕБИТЕСЬ! Я В ПОРЯДКЕ";
        
        if (PlayerPrefs.GetInt(_ResourceKeys.OurDeath) == 1)
           if(endDays == 0) 
               endDays = Random.Range(1, 3);
           else
           {
               if (endDays == 0)
               {
                   Debug.Log("пизда");
                   PlayerPrefs.SetInt(_ResourceKeys.OurDeath, 0);
               }
               else
               {
                   ShowIssueScene();
               }
           }

    }

    private void ShowIssueScene()
    {
        int _d = Random.Range(0, Dialogs.Length);
        text.GetComponent<TextMeshProUGUI>().text = Dialogs[_d];
        
        scene.SetActive(true);
        scene.GetComponent<Animation>().Play();
        text.GetComponent<Animation>().Play();
        Invoke(nameof(DisableScene), 13f);
    }

    private void DisableScene()
    {
        scene.SetActive(false);
    }

    public void SetDays(int days)
    {
        endDays = days;
    }

    public int GetDays()
    {
        return endDays;
    }
}
