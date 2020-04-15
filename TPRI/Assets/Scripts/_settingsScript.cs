using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _settingsScript : MonoBehaviour
{
    public GameObject close;
    [SerializeField] private Slider _slider;
    private _audioController audio;

    private void Awake()
    {
        audio = _audioController.getInstance();
        _slider.value = audio.lastValue;
        gameObject.SetActive(false);
    }

    private void Start()
    {
        close.GetComponent<Button>().onClick.AddListener(() => ShutDown());
    }

    private void Update()
    {
        audio.SetVolume(_slider.value);   
    }
    
    private void ShutDown()
    {
        gameObject.SetActive(false);
    }
}
