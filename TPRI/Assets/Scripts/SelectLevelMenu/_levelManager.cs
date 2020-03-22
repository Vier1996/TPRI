using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _levelManager : MonoBehaviour
{
    private GameObject[] _buttonPool;
    private GameObject _backToSelectMenu;

    private void Start()
    {    
        _backToSelectMenu = GameObject.FindWithTag("back");
        _backToSelectMenu.GetComponent<Button>().onClick.AddListener(()=>BackToMenu());
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
}
