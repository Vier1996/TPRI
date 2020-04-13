using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _backToSelectLevelMenu : MonoBehaviour
{
    [SerializeField] private _GameController _game;
    private GameObject _backToSelect;

    private void Awake()
    {
        _backToSelect = GameObject.FindWithTag("back");
    }

    private void Start()
    {
        _backToSelect.GetComponent<Button>().onClick.AddListener(()=> BackToSelect());
    }

    private void BackToSelect()
    {
        _game.SetNPCcount(0);
        SceneManager.LoadScene("_selectLevelMenu");
    }
}
