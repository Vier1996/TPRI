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
    
    private GameObject _backToSelect;

    private void Awake()
    {
        _backToSelect = GameObject.FindWithTag("back");
        settings.SetActive(false);
    }

    private void Start()
    {
        
        _backToSelect.GetComponent<Button>().onClick.AddListener(()=> Settings());
    }

    private void Settings()
    {
       settings.SetActive(true);
    }
}
