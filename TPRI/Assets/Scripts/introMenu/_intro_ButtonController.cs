﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _intro_ButtonController : MonoBehaviour
{
  [SerializeField] private Button _Start, _Contitue, _Settings, _Home;

  [SerializeField] private Button RUS, ENG;
  
   private GameObject _settingsMenu;
   private _HeroData _hero;

  private void Awake()
  {
    _settingsMenu = GameObject.FindGameObjectWithTag("Settings");
  }

  private void Start()
  {
    _Start.onClick.AddListener(() => { SceneManager.LoadScene("_selectLevelMenu"); });
    _Contitue.onClick.AddListener(() => ContinueGame());
    _Home.onClick.AddListener(() => { SceneManager.LoadScene("_home"); });
    _Settings.onClick.AddListener(() => { _settingsMenu.SetActive(true); });
    
    RUS.onClick.AddListener(() =>
    {
      PlayerPrefs.SetInt("LOCALIZED", 0);
    });
    ENG.onClick.AddListener(() =>
    {
      PlayerPrefs.SetInt("LOCALIZED", 1);
    });
  }
  
  private void ContinueGame()
  {
    SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
  }
}