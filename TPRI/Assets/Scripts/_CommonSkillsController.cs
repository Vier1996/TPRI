using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        _DropProgress.DropSkills();
    }

    private void Start() {
        _passiveBack.SetActive(false);
        _active.interactable = false;
        _passive.interactable = true;

        _active.onClick.AddListener(SetupActiveSkillsMenu);
        _passive.onClick.AddListener(SetupPassiveSkillsMenu);

        _return.onClick.AddListener(() =>
        {
            preset();
            SceneManager.LoadScene("_introMenu");
        });
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
        if (Defense_1.reserched)
        {
            int oldDefense = PlayerPrefs.GetInt(_ResourceKeys.Defense);
            PlayerPrefs.SetInt(_ResourceKeys.Defense, oldDefense + 1); 
        }
        if (Defense_2.reserched)
        {
            int oldDefense = PlayerPrefs.GetInt(_ResourceKeys.Defense);
            PlayerPrefs.SetInt(_ResourceKeys.Defense, oldDefense + 2); 
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
    }
}
