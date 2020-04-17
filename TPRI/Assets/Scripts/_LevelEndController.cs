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
    private int _population;
    private int POPULATION;
    [SerializeField] private GameObject panelDefeat;

    private void Awake()
    {
        _countDead = _countInfected =
            _countMoney = _countPatient = _countHealingIllnesses = _countSkillPoints = _countPassingIlls = _population =0;
        POPULATION = _GameController.Population;
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
        int moneyHealedIlls = _countHealingIllnesses - _countPassingIlls + 10;
        int moneyPercentPopulation = (POPULATION - _countDead) / 30;
        _countMoney = moneyHealedIlls + moneyPercentPopulation + 10;
    }

    public void setCountHealed(int healed)
    {
        _countHealingIllnesses = healed;
    }

    public void setCountSkillPoints()
    {
        _countSkillPoints = _countHealingIllnesses*2;
    }

    public void setPopulation(int population)
    {
        _population = population;
    }

    public void setPanelWinInfo()
    {
        gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text += " " + _countPatient;
        gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += " " + _countPassingIlls;
        gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text += " " + _countHealingIllnesses;
        gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text += " " + _countInfected;
        gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text += " " + _countDead;
        gameObject.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text += " " + _population;
        gameObject.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text += " " + (_countSkillPoints+1);
        gameObject.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text += " " + _countMoney;
        
    }

    public void setPanelDefeat()
    {
        panelDefeat.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text += " "  + _GameController.Population;
        panelDefeat.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += " " + _countDead;
        panelDefeat.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text += " " + _countPatient;
        panelDefeat.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text += " " + _countPassingIlls;
    }
}