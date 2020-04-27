using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _backToSelectLevelMenu : MonoBehaviour
{
    [SerializeField] private _GameController _game;
    [SerializeField] private GameObject settings;
    [SerializeField] private Button back;
    
    private GameObject _backToSelect;

    private void Awake()
    {
        settings.SetActive(false);
    }

    private void Start()
    {
        back.onClick.AddListener(Settings);
    }

    private void Settings()
    {
       settings.SetActive(true);
    }
}
