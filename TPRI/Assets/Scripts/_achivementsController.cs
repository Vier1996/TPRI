﻿using System.Collections;
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
    [SerializeField] private AudioSource getMusic;
    
    

    void Awake()
    {
        if (PlayerPrefs.GetInt(Key + "_buyed") == 1)
        {
            _get.interactable = false;
            sprite.GetComponent<Image>().sprite = Toggle;
        }
        else if (PlayerPrefs.GetInt(Key) == 0)
        {
            _get.interactable = false;
        }
        else
        {
            _get.onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt(_ResourceKeys.skills, PlayerPrefs.GetInt(_ResourceKeys.skills) + _count);

                //PlayerPrefs.SetInt(Key, 1);
                PlayerPrefs.SetInt(Key + "_buyed", 1);

                sprite.GetComponent<Image>().sprite = Toggle;
                getMusic.Play();

                _get.interactable = false;
            });
        }
    }
}
