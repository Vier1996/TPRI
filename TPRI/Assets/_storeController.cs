using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _storeController : MonoBehaviour
{
    [SerializeField] private Button Get;
    [SerializeField] private Button Return;
    [SerializeField] private Text amount;
    [SerializeField] private TextMeshProUGUI moneyCounter;
    [SerializeField] private TextMeshProUGUI item;

    private void Awake()
    {
        //_DropProgress.Drop();
       // _DropProgress.DropResources();
    }

    private void Start()
    {
        moneyCounter.text = PlayerPrefs.GetInt(_ResourceKeys.Money).ToString();
        
        Get.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("Key_" + item.text, Convert.ToInt32(amount.text));
            Debug.Log("Buyed - " + item.text + " -" + Convert.ToInt32(amount.text));
            Debug.Log(PlayerPrefs.GetInt("Key_" + item.text));
            PlayerPrefs.SetInt(_ResourceKeys.Buyed_items_count, PlayerPrefs.GetInt(_ResourceKeys.Buyed_items_count) + Convert.ToInt32(amount.text));
            if (PlayerPrefs.GetInt(_ResourceKeys.Buyed_items_count) >= 50)
            {
                PlayerPrefs.SetInt(_ResourceKeys.Продовольствие, 1);
            }
        });
        
        Return.onClick.AddListener(() => { SceneManager.LoadScene("_home"); });
    }
}
