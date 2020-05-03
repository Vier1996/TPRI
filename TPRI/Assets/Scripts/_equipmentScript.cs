using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class _equipmentScript : MonoBehaviour
{
    [SerializeField] private GameObject ResearchMenu;
    [SerializeField] private GameObject HealthMenu;
    [SerializeField] private GameObject DialogMenu;
    [SerializeField] private GameObject DeathMenu;
    [SerializeField] private GameObject DialogWithPeople;
    public static bool _showDialogs = false;
    [SerializeField] private GameObject hideDialog;
    [SerializeField] private GameObject showDialog;
    [SerializeField] private Button ResearchButton;
    [SerializeField] private Button HealthButton;
    [SerializeField] private Button DialogButton;
    [SerializeField] private Button DeathButton;
    [SerializeField] private Button DialogWithPeopleButton;
    [SerializeField] private Button whereQuestion;
    [SerializeField] private Button problemsQuestion;
    [SerializeField] private Button visitQuestion;
    [SerializeField] private GameObject deactQuestionPanel;
    [SerializeField] private GameObject pistol;
    

    private int showedMenu = 0;
    void Start()
    {
        ResearchMenu.SetActive(false);
        HealthMenu.SetActive(false);
        DialogMenu.SetActive(false);
        DeathMenu.SetActive(false);
        //pistol.SetActive(false);
        
        DialogWithPeople.transform.DOMove(hideDialog.transform.position, 0);
        
        /*whereQuestion.interactable = false;
        problemsQuestion.interactable = false;
        visitQuestion.interactable = false;*/
        
        ResearchButton.onClick.AddListener(() =>
        {
            ResearchButton.interactable = false;
            HealthButton.interactable = true;
            DialogButton.interactable = true;
            DeathButton.interactable = true;
            //pistol.SetActive(false);
            
            Deact();
            //deactQuestionPanel.SetActive(false);
            ResearchMenu.SetActive(true);
            showedMenu = 1;
        });
        
        HealthButton.onClick.AddListener(() =>
        {
            ResearchButton.interactable = true;
            HealthButton.interactable = false;
            DialogButton.interactable = true;
            DeathButton.interactable = true;
            //pistol.SetActive(false);
            
            Deact();
            //deactQuestionPanel.SetActive(false);
            HealthMenu.SetActive(true);
            showedMenu = 2;
        });
        
        DialogButton.onClick.AddListener(() =>
        {
            ResearchButton.interactable = true;
            HealthButton.interactable = true;
            DialogButton.interactable = false;
            DeathButton.interactable = true;
            //pistol.SetActive(false);
            Deact();
            DialogMenu.SetActive(true);
            //deactQuestionPanel.SetActive(true);
            showedMenu = 3;
        });
        
        DeathButton.onClick.AddListener(() =>
        {
            ResearchButton.interactable = true;
            HealthButton.interactable = true;
            DialogButton.interactable = true;
            DeathButton.interactable = false;

            Deact(); 
            //deactQuestionPanel.SetActive(false);
            DeathMenu.SetActive(true);
            //pistol.SetActive(true);
            showedMenu = 4;
        });
        
        DialogWithPeopleButton.onClick.AddListener(() =>
        {
            //deactQuestionPanel.SetActive(false);
            if (!_showDialogs)
            {
                DialogWithPeople.transform.DOMove(showDialog.transform.position, 2);
                _showDialogs = true;
            }
            else
            {
                DialogWithPeople.transform.DOMove(hideDialog.transform.position, 2);
                _showDialogs = false;
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
