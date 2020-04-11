using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _intro_ButtonController : MonoBehaviour
{
  [SerializeField] private Button _Start, _Contitue, _Settings, _Upgrade;
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
    _Upgrade.onClick.AddListener(() => { SceneManager.LoadScene("DiscoverMenu"); });
    _Settings.onClick.AddListener(() => { _settingsMenu.SetActive(true); });
  }
  
  private void ContinueGame()
  {
    // override PlayerPrefs
  }
}