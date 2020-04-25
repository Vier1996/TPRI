using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _audioController : MonoBehaviour
{
    private static _audioController instance;
    [SerializeField] private AudioSource Music;
    public float lastValue = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Music.loop = true;
    }

    private void Start()
    {
        Music.Play();
    }

    public static _audioController getInstance()
    {
        if (instance == null)
        {
            instance = new _audioController();
        }

        return instance;
    }
    
    public void SetVolume(float _volume)
    {
        try
        {
            Music.volume = _volume;
            lastValue = _volume;
        }
        catch (NullReferenceException)
        {
        }
        
    }
}
