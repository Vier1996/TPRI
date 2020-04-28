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
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("_introMenu");
        });
    }
    
}
