using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _HeroData : MonoBehaviour
{
    private static _HeroData _instance;
    private int _availableLevel, _defence, _numOfSkillPoints, _money;
    private Dictionary<string, string> _equipment;
    private List<string> _skiils;

    private _HeroData()
    {
        _availableLevel = _defence = _numOfSkillPoints = _money = 0;
        _equipment = new Dictionary<string, string>();
        _skiils = new List<string>();
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void setDataFromMemory()
    {
        setLevelMemory();
        setDefenceMemory();
        setMoneyMemory();
        setNumOfSkillPointsMemory();
        setEquipmentMemory();
        setSkillsMemory();
    }
    
    private void setLevelMemory()
    {
        Debug.Log("Level is set");
    }

    private void setDefenceMemory()
    {
        Debug.Log("Defence is set");
    }

    private void setNumOfSkillPointsMemory()
    {
        Debug.Log("Skillpoints is set");
    }

    private void setMoneyMemory()
    {
        Debug.Log("Money is set");
    }

    private void setEquipmentMemory()
    {
        Debug.Log("Equipment is set");
    }

    private void setSkillsMemory()
    {
        Debug.Log("Skills is set");
    }
}
