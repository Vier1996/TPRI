using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _levelSettingsScript : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _SaveExit;
    [SerializeField] private Button _closeArea;
    [SerializeField] private Button _close;

    [SerializeField] private Slider _slider;
    private _audioController audio;

    private void Awake()
    {
        audio = _audioController.getInstance();
        _slider.value = audio.lastValue;
    }

    private void Start()
    {

        _restart.onClick.AddListener(() =>
        {
            GameObject.FindWithTag("MainCamera").GetComponent<_GameController>().SetNPCcount(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        _SaveExit.onClick.AddListener(() =>
        {
            GameObject.FindWithTag("MainCamera").GetComponent<_GameController>().SaveCommonState();
            SceneManager.LoadScene("_selectLevelMenu");
        });
        _close.onClick.AddListener(() =>
        {
            _closeArea.gameObject.SetActive(false);
        });
        _closeArea.onClick.AddListener(() =>
        {
            _closeArea.gameObject.SetActive(false);
        });
    }

    private void Update()
    {
         audio.SetVolume(_slider.value);   
    }
}
