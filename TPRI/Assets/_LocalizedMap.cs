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
        _CommonMap.Add("Settings_sounds", "Звуки_Sounds");
        _CommonMap.Add("Settings_music", "Музыка_Music");
        _CommonMap.Add("Settings_donate", "Пожертвование_Donate");
        _CommonMap.Add("Settings_language", "Выбор языка_Choose language");
        
        //Выбор уровня
        _CommonMap.Add("Settings_day1", "День 1_Day 1");
        _CommonMap.Add("Settings_day2", "День 2_Day 2");
        _CommonMap.Add("Settings_day3", "День 3_Day 3");
        _CommonMap.Add("Settings_day4", "День 4_Day 4");
        _CommonMap.Add("Settings_day5", "День 5_Day 5");
        _CommonMap.Add("Settings_day6", "День 6_Day 6");
        _CommonMap.Add("Settings_day7", "День 7_Day 7");
        _CommonMap.Add("Settings_back", "Вернутся_Back");
        _CommonMap.Add("Settings_openSettings", "Настройки_Settings");
        
    }
    
    
    public static string GetLocalisedText(string KEY) {
        
        string[] _values = _CommonMap[KEY].Split('_');

        if (PlayerPrefs.GetInt("LOCALIZED") == 0)
            return _values[0];
        else
            return _values[1];
    }
}
