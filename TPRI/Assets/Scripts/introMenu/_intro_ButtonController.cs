using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _intro_ButtonController : MonoBehaviour
{
  [SerializeField] private Button _Start, _Contitue, _Settings;
   private GameObject _settingsMenu;

  private void Awake()
  {
    _settingsMenu = GameObject.FindGameObjectWithTag("Settings");
  }

  private void Start()
  {
    _Start.onClick.AddListener(() => StartGame());
    _Contitue.onClick.AddListener(() => ContinueGame());
    _Settings.onClick.AddListener(() => OpenSettings());
  }

  private void StartGame()
  {
    SceneManager.LoadScene("_selectLevelMenu");
  }

  private void ContinueGame()
  {
    // override PlayerPrefs
  }

  private void OpenSettings()
  {
    _settingsMenu.SetActive(true);
  }
}
