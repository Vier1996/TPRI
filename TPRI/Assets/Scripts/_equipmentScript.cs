using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _equipmentScript : MonoBehaviour
{
    [SerializeField] private GameObject ResearchMenu;
    [SerializeField] private GameObject HealthMenu;
    [SerializeField] private GameObject DialogMenu;
    [SerializeField] private GameObject DeathMenu;
    [SerializeField] private GameObject DialogWithPeople;
    
    
    [SerializeField] private Button ResearchButton;
    [SerializeField] private Button HealthButton;
    [SerializeField] private Button DialogButton;
    [SerializeField] private Button DeathButton;
    [SerializeField] private Button DialogWithPeopleButton;

    private int showedMenu = 0;
    void Start()
    {
        ResearchMenu.SetActive(false);
        HealthMenu.SetActive(false);
        DialogMenu.SetActive(false);
        DeathMenu.SetActive(false);
        DialogWithPeople.SetActive(false);
        
        ResearchButton.onClick.AddListener(() =>
        {
            Deact();
            ResearchMenu.SetActive(true);
            showedMenu = 1;
        });
        
        HealthButton.onClick.AddListener(() =>
        {
            Deact();
            HealthMenu.SetActive(true);
            showedMenu = 2;
        });
        
        DialogButton.onClick.AddListener(() =>
        {
            Deact();
            DialogMenu.SetActive(true);
            showedMenu = 3;
        });
        
        DeathButton.onClick.AddListener(() =>
        {
            Deact();
            DeathMenu.SetActive(true);
            showedMenu = 4;
        });
        
        DialogWithPeopleButton.onClick.AddListener(() =>
        {
            if(DialogWithPeople.activeSelf)
                DialogWithPeople.SetActive(false);
            else
            {
                DialogWithPeople.SetActive(true);
            }
        });
    }

    private void Deact()
    {
        switch (showedMenu)
        {
            case 1: ResearchMenu.SetActive(false); break;
            case 2: HealthMenu.SetActive(false); break;
            case 3: DialogMenu.SetActive(false); break;
            case 4: DeathMenu.SetActive(false); break;
            default: break;
        }
    }

}
