using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _settingsScript : MonoBehaviour
{
    public GameObject close;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        close.GetComponent<Button>().onClick.AddListener(() => ShutDown());
    }

    private void ShutDown()
    {
        gameObject.SetActive(false);
    }
}
