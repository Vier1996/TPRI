using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _levelItemController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private string key;
    [SerializeField] private Button get;
    private int amount;

    void Start()
    {
        amount = PlayerPrefs.GetInt(key);
        counter.text = amount.ToString();
        if(amount <= 0)
            Empty();
        else
        {
            get.onClick.AddListener(() =>
            {
                if (amount > 0)
                {
                    counter.text = (--amount).ToString();
                    PlayerPrefs.SetInt(key, amount);
                    if (amount == 0)
                        Empty();
                }
            });
        }
    }

    private void Empty()
    {
        get.interactable = false;
    }

    void Update()
    {
        
    }
}
