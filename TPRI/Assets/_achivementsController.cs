using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _achivementsController : MonoBehaviour
{
    [SerializeField] private string Key;
    [SerializeField] private Button _get;
    [SerializeField] private int _count;
  
    [SerializeField] private GameObject sprite;
    [SerializeField] private Sprite Toggle;
    

    void Awake()
    {
        if (PlayerPrefs.GetInt(Key) == 1 || PlayerPrefs.GetInt(Key + "_buyed") == 1)
        {
            _get.interactable = false;
            sprite.GetComponent<Image>().sprite = Toggle;
        }
        else
        {
            _get.onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt(_ResourceKeys.skills, PlayerPrefs.GetInt(_ResourceKeys.skills) + _count);
                
                PlayerPrefs.SetInt(Key, 1);
                PlayerPrefs.SetInt(Key + "_buyed", 1);
                
                sprite.GetComponent<Image>().sprite = Toggle;
                _get.interactable = false;
            });
        }
    }
}
