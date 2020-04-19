using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _LocalizedMap : MonoBehaviour
{
    private static _LocalizedMap instance;
    private static Dictionary<string, string> _CommonMap = null;

    
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
        
        _CommonMap = new Dictionary<string, string>();
        
        // Настройки
        _CommonMap.Add("Settings_title", "Настройки_Settings");
        
    }
    
    
    public static string GetLocalisedText(string KEY) {
        
        string[] _values = _CommonMap[KEY].Split('_');

        if (PlayerPrefs.GetInt("LOCALIZED") == 0)
            return _values[0];
        else
            return _values[1];
    }
}
