﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _LevelEndController : MonoBehaviour
{
    private int _countPatient;
    private int _countPassingIlls;
    private int _countInfected;
    private int _countDead;
    private int _countSkillPoints;
    private int _countMoney;
    private int _countHealingIllnesses;
    private int _population;
    private int countExpel = 0;
    [SerializeField] private GameObject panelDefeat;
    [SerializeField] private Slider levelPointsSlider;

    private void Awake()
    {
        _countDead = _countInfected =
            _countMoney = _countPatient = 
                _countHealingIllnesses = _countSkillPoints = 
                    _countPassingIlls = _population = 0;
    }

    public void setCountPatient(int patients)
    {
        _countPatient = patients;
    }

    public void setCountPassIlls(int passIlls)
    {
        _countPassingIlls = passIlls;
    }

    public void incrementExpelPeople()
    {
        countExpel++;
    }
    
    public void setCountInfected(int infected)
    {
        _countInfected = infected;
    }

    public void setCountDead(int dead)
    {
        _countDead = dead;
    }

    public void setMoney()
    {
        _countMoney = (int)(10 + _GameController.countHealedSymptomes * 0.6 - countExpel * 0.4);
 
        // базовые 10 + количество вылеченых симптомов * 0.6 - количество выгнаных людей * 0.4;
        
        int oldMoneyCounter = PlayerPrefs.GetInt(_ResourceKeys.Money);
        Debug.Log(oldMoneyCounter);
        Debug.Log(_countMoney);
        
        PlayerPrefs.SetInt(_ResourceKeys.Money, oldMoneyCounter + _countMoney);
    }

    public void setCountHealed(int healed)
    {
        _countHealingIllnesses = healed;
    }

    public void setPopulation(int population)
    {
        _population = population;
    }

    private int setLevelPointsSlider()
    {
        return (int)((10 + _GameController.countHealedSymptomes * 0.6 - countExpel * 0.4) + _countHealingIllnesses*2);
    }
    
    public void setPanelWinInfo()
    {
        PlayerPrefs.SetInt(_ResourceKeys.Начинающий, 1);
        PlayerPrefs.SetInt(_ResourceKeys.TheFirstLevel, 1);
        levelPointsSlider.maxValue = PlayerPrefs.GetInt(_ResourceKeys.NeddedScore);
        Debug.Log("Value: " + PlayerPrefs.GetInt(_ResourceKeys.NeddedScore));
        gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += " " + _countPatient;
        gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text += " " + _countPassingIlls;
        gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text += " " + _countHealingIllnesses;
        gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text += " " + _countInfected;
        gameObject.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text += " " + _countDead;
        gameObject.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text += " " + _population;
        //gameObject.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text += " " + (_countSkillPoints+1);
        gameObject.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text += " " + _countMoney;
        //PlayerPrefs.SetInt(_ResourceKeys.Money, PlayerPrefs.GetInt(_ResourceKeys.Money) + _countMoney);
        int levelPoints = PlayerPrefs.GetInt(_ResourceKeys.CurrentScore) + setLevelPointsSlider();
        if (levelPoints >= PlayerPrefs.GetInt(_ResourceKeys.NeddedScore))
        {
            int check = levelPoints - PlayerPrefs.GetInt(_ResourceKeys.NeddedScore);
            _ResourceKeys.LevelUp(check);
            levelPointsSlider.maxValue = PlayerPrefs.GetInt(_ResourceKeys.NeddedScore);
            levelPointsSlider.value = check;
            gameObject.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text += " " + 1;
            
            PlayerPrefs.SetInt(_ResourceKeys.skills, PlayerPrefs.GetInt(_ResourceKeys.skills) + 1);
        }
        else
        {    
            gameObject.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text += " " + 0;
            PlayerPrefs.SetInt(_ResourceKeys.CurrentScore, levelPoints);
            levelPointsSlider.value = PlayerPrefs.GetInt(_ResourceKeys.CurrentScore);
        }
        gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(_ResourceKeys.CharacterLevel).ToString();
        if(SceneManager.GetActiveScene().buildIndex == 8)
            PlayerPrefs.SetInt(_ResourceKeys.Первопроходец, 1);
        PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);
    }

    public void setPanelDefeat()
    {
        panelDefeat.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text += " "  + _GameController.Population;
        panelDefeat.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += " " + _countDead;
        panelDefeat.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text += " " + _countPatient;
        panelDefeat.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text += " " + _countPassingIlls;
    }
}