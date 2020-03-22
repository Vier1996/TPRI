using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _settingsScript : MonoBehaviour
{
    private GameObject close;

    private void Awake()
    {
        close = GameObject.FindGameObjectWithTag("CloseButton");
        
        close.GetComponent<Button>().onClick.AddListener(() => ShutDown());
    }

    private void ShutDown()
    {
        gameObject.SetActive(false);
    }
}
