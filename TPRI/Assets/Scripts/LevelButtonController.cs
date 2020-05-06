using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    [SerializeField] private string path;
    void Start()
    {
        if (PlayerPrefs.GetInt(path) == 0)
        {
            GetComponent<Button>().interactable = false;
        }
    }
    
}
