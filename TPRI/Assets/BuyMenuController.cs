using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class BuyMenuController : MonoBehaviour
{
    public TextMeshProUGUI priceText;
    public string item;
    public int price;
    public int lvl;

    [SerializeField] private Button _get;

    private void Awake()
    {
        _get.onClick.AddListener(() =>
        {
            if (PlayerPrefs.GetInt(item + lvl) == 0)
            {
                if (PlayerPrefs.GetInt(_ResourceKeys.Money) >= price)
                {
                    PlayerPrefs.SetInt(_ResourceKeys.Money, PlayerPrefs.GetInt(_ResourceKeys.Money) - price);
                    PlayerPrefs.SetInt(item + lvl, 1);
                    priceText.text = "";
                }
            }
            else
            {
                priceText.text = "";
            }
        });
    }
}
