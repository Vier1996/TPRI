using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class _storeController : MonoBehaviour
{
    [SerializeField] private Button Get;
    [SerializeField] private TextMeshProUGUI amount;

    private void Start()
    {
        Get.onClick.AddListener(() =>
        {
            int _amount = Int32.Parse(amount.text);
            Debug.Log("Buyed: " + _amount);
        });
    }
}
