using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class _upgradeController : MonoBehaviour
{
    [SerializeField] public string Path;
    [SerializeField] Button Upgrade1;
    [SerializeField] Button Upgrade2;
    [SerializeField] Button Upgrade3;

    [SerializeField] private string item;

    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private int price;

    [SerializeField] private GameObject BuyMenu;

    private string oldname;
    

    private void Awake()
    {
        if (PlayerPrefs.GetInt("5_skl") != 1)
            Upgrade3.interactable = false;

        oldname = description.text;
        
        Upgrade1.onClick.AddListener(() =>
        {
            description.text = oldname + item + " 1-го уровня.";
            if(PlayerPrefs.GetInt(Path + 1) == 0)
                _price.text = (price).ToString();
            else
            {
                _price.text = "";
            }
            BuyMenu.SetActive(true);

            BuyMenu.GetComponent<BuyMenuController>().item = Path;
            BuyMenu.GetComponent<BuyMenuController>().price = price;
            BuyMenu.GetComponent<BuyMenuController>().lvl = 1;
        });
        
        Upgrade2.onClick.AddListener(() =>
        {
            description.text = oldname + item + " 2-го уровня.";
            if(PlayerPrefs.GetInt(Path + 2) == 0)
                _price.text = (2*price).ToString();
            else
            {
                _price.text = "";
            }
            BuyMenu.SetActive(true);
            
            BuyMenu.GetComponent<BuyMenuController>().item = Path;
            BuyMenu.GetComponent<BuyMenuController>().price = (2*price);
            BuyMenu.GetComponent<BuyMenuController>().lvl = 2;
        });
        
        Upgrade3.onClick.AddListener(() =>
        {
            description.text = oldname + item + " 3-го уровня.";
            if(PlayerPrefs.GetInt(Path + 3) == 0)
                _price.text = (3*price).ToString();
            else
            {
                _price.text = "";
            }
            BuyMenu.SetActive(true);
            
            BuyMenu.GetComponent<BuyMenuController>().item = Path;
            BuyMenu.GetComponent<BuyMenuController>().price = (3*price);
            BuyMenu.GetComponent<BuyMenuController>().lvl = 3;
        });
        
    }
}
