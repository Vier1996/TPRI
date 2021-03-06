﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _storeController : MonoBehaviour
{
    [SerializeField] private Button Get;
    [SerializeField] private Button Return;
    [SerializeField] private TextMeshProUGUI moneyCounter;
    
    [SerializeField] private TextMeshProUGUI item;

    [SerializeField] private Button x1;
    [SerializeField] private Button x2;
    [SerializeField] private Button x5;
    [SerializeField] private Button x10;
    [SerializeField] private Button x25;
    
    [SerializeField] private AudioSource moenyGet;
    [SerializeField] private AnimatedText AT;
    [SerializeField] private GameObject coin, coin1, coin2;
    
    private int multiplicator = 0;

    private void Awake()
    {
        //_DropProgress.Drop();
        // _DropProgress.DropResources();
    }

    private void Start()
    {
        moneyCounter.text = PlayerPrefs.GetInt(_ResourceKeys.Money).ToString();
        
        x1.onClick.AddListener(() =>
        {
            multiplicator = 1;

            x1.interactable = false;
            x2.interactable = true;
            x5.interactable = true;
            x10.interactable = true;
            x25.interactable = true;
        });
        x2.onClick.AddListener(() =>
        {
            multiplicator = 2; 
            
            x2.interactable = false;
            x1.interactable = true;
            x5.interactable = true;
            x10.interactable = true;
            x25.interactable = true;
        });
        x5.onClick.AddListener(() =>
        {
            multiplicator = 5; 
            
            x5.interactable = false;
            x2.interactable = true;
            x1.interactable = true;
            x10.interactable = true;
            x25.interactable = true;
        });
        x10.onClick.AddListener(() =>
        {
            multiplicator = 10; 
            
            x10.interactable = false;
            x2.interactable = true;
            x5.interactable = true;
            x1.interactable = true;
            x25.interactable = true;
        });
        x25.onClick.AddListener(() =>
        {
            multiplicator = 25; 
            
            x25.interactable = false;
            x2.interactable = true;
            x5.interactable = true;
            x10.interactable = true;
            x1.interactable = true;
        });
        
        Get.onClick.AddListener(() =>
        {
            _DescriptionController info = GameObject.FindGameObjectWithTag("store").GetComponent<_DescriptionController>();

            if (PlayerPrefs.GetInt(_ResourceKeys.Money) < multiplicator * info.GetPrice())
            {
            }
            else
            {
                int preMoney = PlayerPrefs.GetInt(_ResourceKeys.Money);
                UpdateMoney(preMoney, preMoney - multiplicator * info.GetPrice(), false);
                
                PlayerPrefs.SetInt(_ResourceKeys.Money, PlayerPrefs.GetInt(_ResourceKeys.Money) - multiplicator * info.GetPrice());
                PlayerPrefs.SetInt("Key_" + info.getKey(), PlayerPrefs.GetInt("Key_" + info.getKey()) + multiplicator);
            
                Debug.Log("Buyed - " + item.text + " -" + multiplicator);
                Debug.Log(PlayerPrefs.GetInt("Key_" + info.getKey()));
            
                PlayerPrefs.SetInt(_ResourceKeys.Buyed_items_count, PlayerPrefs.GetInt(_ResourceKeys.Buyed_items_count) + multiplicator);
                if (PlayerPrefs.GetInt(_ResourceKeys.Buyed_items_count) >= 50)
                {
                    PlayerPrefs.SetInt(_ResourceKeys.Продовольствие, 1);
                }
                moenyGet.Play();
            }
        });
        
        Return.onClick.AddListener(() => { SceneManager.LoadScene("_home"); });
    }

    private void UpdateMoney(int pre, int to, bool operation)
    {
        AT.ANIMATEDTEXT(moneyCounter, pre, to, operation);
    }

    private void Update()
    {
        coin.transform.Rotate(0, 0, -60*Time.deltaTime);
        coin1.transform.Rotate(0, 0, -60*Time.deltaTime);
        coin2.transform.Rotate(0, 0, -60*Time.deltaTime);
    }
}
