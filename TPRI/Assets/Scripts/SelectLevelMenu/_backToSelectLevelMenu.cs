using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _backToSelectLevelMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("_selectLevelMenu");
    }
}
