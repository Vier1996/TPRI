﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _levelManager : MonoBehaviour
{
    [SerializeField] private Button SettingsButton;
    
    private GameObject _settingsMenu;
    
    private GameObject[] _buttonPool;

    private void Awake()
    {
        _settingsMenu = GameObject.FindGameObjectWithTag("Settings");
    }

    private void Start()
    {
        SettingsButton.GetComponent<Button>().onClick.AddListener(() => OpenSettings());
        
        _buttonPool = GameObject.FindGameObjectsWithTag("level_tag");
        foreach (var t in _buttonPool)
        {
            t.GetComponent<Button>().onClick.AddListener(()=> ChooseLevel(t.GetComponent<Button>()));
        }
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("_introMenu");
    }

    void GoToSettings()
    {
        SceneManager.LoadScene("");
    }

    private void ChooseLevel(Button _choosenLevel)
    {
        String levelName = _choosenLevel.name;
        SceneManager.LoadScene("_level_" + levelName);
    }

    private void OpenSettings()
    {
        _settingsMenu.SetActive(true);
    }
}
