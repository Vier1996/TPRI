﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _CommonSkillsController : MonoBehaviour
{
    [SerializeField] private Button _active;
    [SerializeField] private Button _passive;
    [SerializeField] private GameObject _activeBack;
    [SerializeField] private GameObject _passiveBack;
    
    [SerializeField] private Button _return;

    [SerializeField] private _skillController Defense_1; 
    [SerializeField] private _skillController Defense_2;
    
    [SerializeField] private _skillController LifeCity_1; 
    [SerializeField] private _skillController LifeCity_2;

    [SerializeField] private _skillController AddShoot_1;
    [SerializeField] private _skillController AddShoot_2;
    [SerializeField] private _skillController AddShoot_3;
    
    [SerializeField] private _skillController Warning_1;
    [SerializeField] private _skillController Warning_2;

    [SerializeField] private _skillController Healing_1;
    [SerializeField] private _skillController Healing_2;
    
    
    [SerializeField] private TextMeshProUGUI _amount;

    private void Awake()
    {
        _amount.text = PlayerPrefs.GetInt(_ResourceKeys.skills).ToString();
        //_DropProgress.DropSkills();
        //PlayerPrefs.SetInt(_ResourceKeys.CharacterLevel, 15);
    }

    private void Start() {
        _passiveBack.SetActive(false);
        _active.interactable = false;
        if (PlayerPrefs.GetInt(_ResourceKeys.CharacterLevel) >= 15)
        {
            _passive.interactable = true;
        }
        else
        {
            _passive.interactable = false;
        }
       

        _active.onClick.AddListener(SetupActiveSkillsMenu);
        _passive.onClick.AddListener(SetupPassiveSkillsMenu);

        _return.onClick.AddListener(() =>
        {
            preset();
            SceneManager.LoadScene("_home");
        });
    }

    private void Update()
    {
        _amount.text = PlayerPrefs.GetInt(_ResourceKeys.skills).ToString();
    }

    private void SetupActiveSkillsMenu()
    {
        _active.interactable = false;
        _passive.interactable = true;
        
        _passiveBack.SetActive(false);
        _activeBack.SetActive(true);
    }
    
    private void SetupPassiveSkillsMenu()
    {
        _active.interactable = true;
        _passive.interactable = false;
        
        _activeBack.SetActive(false);
        _passiveBack.SetActive(true);
    }

    private void preset()
    {
        int defense = DefenseEquipmentsHelper.GetEqupmentDefense();
        if (Defense_1.reserched)
        {
            int oldDefense = PlayerPrefs.GetInt(_ResourceKeys.Defense);
            PlayerPrefs.SetInt(_ResourceKeys.Defense, oldDefense + 1);
            if (defense + (oldDefense + 1) >= 25)
            {
                PlayerPrefs.SetInt(_ResourceKeys.Крепкий_имунитет, 1);
            }
        }
        if (Defense_2.reserched)
        {
            int oldDefense = PlayerPrefs.GetInt(_ResourceKeys.Defense);
            PlayerPrefs.SetInt(_ResourceKeys.Defense, oldDefense + 2); 
            if (defense + (oldDefense + 2) >= 25)
            {
                PlayerPrefs.SetInt(_ResourceKeys.Крепкий_имунитет, 1);
            }
        }
        if (LifeCity_1.reserched)
        {
            PlayerPrefs.SetInt(_ResourceKeys.CityImunity, 15); 
        }
        if (LifeCity_2.reserched)
        {
            int oldDefense = PlayerPrefs.GetInt(_ResourceKeys.CityImunity);
            PlayerPrefs.SetInt(_ResourceKeys.CityImunity, 30); 
        }
        if (AddShoot_1.reserched)
        {
            PlayerPrefs.SetInt(_ResourceKeys.Shoots, 1); 
        }
        if (AddShoot_2.reserched)
        {
            PlayerPrefs.SetInt(_ResourceKeys.Shoots, 2); 
        }
        if (AddShoot_3.reserched)
        {
            PlayerPrefs.SetInt(_ResourceKeys.Shoots, 3); 
        }
        if (Warning_1.reserched)
        {
            PlayerPrefs.SetInt(_ResourceKeys.Shoots, 15); 
        }
        if (Warning_2.reserched)
        {
            PlayerPrefs.SetInt(_ResourceKeys.Shoots, 30); 
        }
        if (Healing_1.reserched)
        {
            PlayerPrefs.SetInt(_ResourceKeys.Healing_1, 10); 
        }
        if (Healing_2.reserched)
        {
            PlayerPrefs.SetInt(_ResourceKeys.Healing_2, 20); 
        }
    }
}
