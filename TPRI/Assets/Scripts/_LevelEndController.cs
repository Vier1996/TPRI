using System;
using TMPro;
using UnityEngine;

public class _LevelEndController : MonoBehaviour
{
    private int _countPatient;
    private int _countPassingIlls;
    private int _countInfected;
    private int _countDead;
    private int _countSkillPoints;
    private int _countMoney;
    private int _countHealingIllnesses;

    private void Awake()
    {
        _countDead = _countInfected =
            _countMoney = _countPatient = _countHealingIllnesses = _countSkillPoints = _countPassingIlls = 0;
    }

    public void setCountPatient(int patients)
    {
        _countPatient = patients;
    }

    public void setCountPassIlls(int passIlls)
    {
        _countPassingIlls = passIlls;
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
        
    }

    public void setCountHealed(int healed)
    {
        _countHealingIllnesses = healed;
    }

    public void setCountSkillPoints()
    {
        
    }

    public void setPanelWinInfo()
    {
        gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text += " " + _countPatient;
        gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += " " + _countPassingIlls;
        gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text += " " + _countHealingIllnesses;
        gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text += " " + _countInfected;
        gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text += " " + _countDead;
        gameObject.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text += " " + _GameController.Population;
        gameObject.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text += " " + _countSkillPoints;
        gameObject.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text += " " + _countMoney;
        
    }
}