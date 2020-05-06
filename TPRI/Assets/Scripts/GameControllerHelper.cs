using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerHelper : MonoBehaviour
{
    [SerializeField] private Button FullReset;
    void Start()
    {
        FullReset.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("clrd_lvl_1", 0);
            PlayerPrefs.SetInt("clrd_lvl_2", 0);
            PlayerPrefs.SetInt("clrd_lvl_3", 0);
            PlayerPrefs.SetInt("clrd_lvl_4", 0);
            PlayerPrefs.SetInt("clrd_lvl_5", 0);
            PlayerPrefs.SetInt("clrd_lvl_6", 0);
            PlayerPrefs.SetInt("clrd_lvl_7", 0);
            
            PlayerPrefs.SetInt(_ResourceKeys.Money, PlayerPrefs.GetInt(_ResourceKeys.Money) / 2);
            PlayerPrefs.SetInt(_ResourceKeys.CurrentScore, PlayerPrefs.GetInt(_ResourceKeys.CurrentScore) / 2);
            
            SceneManager.LoadScene("_introMenu");
        });
    }
    
}
