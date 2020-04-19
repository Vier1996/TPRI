using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class _HealCityScirpt : MonoBehaviour
{
    private int _amount;
    private _Infected_And_Dead_Counter _infectedAndDead;
    [SerializeField] private TextMeshProUGUI alive, infected;

    private void Start()
    {
        _amount = PlayerPrefs.GetInt(_ResourceKeys.HealCity);
        gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _amount.ToString();
        _infectedAndDead = _Infected_And_Dead_Counter.getInstance();
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (_amount != 0)
            {
                int healed = (int)(_infectedAndDead.getInfected() * 0.35);
                _infectedAndDead.SetInfected(_infectedAndDead.getInfected() - healed);
                infected.text = _infectedAndDead.getInfected().ToString();
                _GameController.Population += healed;
                alive.text = _GameController.Population.ToString();
                _amount--;
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _amount.ToString();
            }
        });
    }

    private void Update()
    {
        if (_amount == 0)
        {
            GetComponent<UnityEngine.UI.Image>().color = new Color(1,1,1,0.5f);
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
