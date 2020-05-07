using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class _levelItemController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private string key;
    [SerializeField] private Button get;
    [SerializeField] private List<string> curableSymptoms;
    [SerializeField] private AudioSource sanya;
    private GameObject _NPC;
    private List<string> _peopleIllness;
    private int amount;
    private int index = 0;
    private bool _fullHealing;

    void Start()
    {
        amount = PlayerPrefs.GetInt(key);
        counter.text = amount.ToString();
        if(amount <= 0)
            Empty();
        else
        {
            get.onClick.AddListener(() =>
            {
                if (amount > 0)
                {
                    counter.text = (--amount).ToString();
                    PlayerPrefs.SetInt(key, amount);
                    if (amount == 0)
                        Empty();
                }
            });
        }
        _NPC = GameObject.FindWithTag("Player");
        _peopleIllness = _NPC.GetComponent<_PeopleIssues>().getSymptoms();
        gameObject.GetComponent<Button>().onClick.AddListener(() => Heal());
    }

    private void Empty()
    {
        get.interactable = false;
    }

    void Update()
    {
        try
        {
            if (_NPC == null && index < 5)
            {
                _NPC = GameObject.FindWithTag("Player");
                _peopleIllness = _NPC.GetComponent<_PeopleIssues>().getSymptoms();
                index++;
            }
        }
        catch(NullReferenceException){}
    }

    private void Heal()
    {
        sanya.Play();
        Invoke(nameof(stopper), 1.8f);

        if (_peopleIllness != null)
        {
            tryToHealFull();
            if (!_fullHealing)
            {
                if (key.Equals("Key_Panacea"))
                {
                    Healling();
                }
                else if (key.Equals("Key_Saint_water"))
                {
                    int rate = Random.Range(0, 101);
                    if (rate <= 95)
                    {
                        Healling();
                    }
                }
                else if (key.Equals("Key_Cross"))
                {
                    PlayerPrefs.SetInt(_ResourceKeys.OurDeath, 0);
                }
                else
                {
                    int index_cur_sympt = 0;
                    for (int i = 0; i < curableSymptoms.Count; i++)
                    {
                        if (_peopleIllness.Contains(curableSymptoms[i]))
                        {
                            _peopleIllness.Remove(curableSymptoms[i]);
                            PlayerPrefs.SetInt("Key_" + curableSymptoms[i], 1);
                            _GameController.countHealedSymptomes++;
                        }

                        index_cur_sympt++;
                    }

                    _NPC.GetComponent<_PeopleIssues>().setSymptoms(_peopleIllness);
                    if (_GameController.countHealedSymptomes == 3)
                    {
                        PlayerPrefs.SetInt(_ResourceKeys.Первые_шаги, 1);
                    }
                }
            }
        }
    }

    private void Healling()
    {
        List<string> ills = new List<string>(_peopleIllness);
        for (int i = 0; i < ills.Count; i++)
        {
            PlayerPrefs.SetInt("Key_" + ills[i], 1);
            _GameController.countHealedSymptomes++;
            _peopleIllness.Remove(ills[i]);
        }
    }
    
    private void tryToHealFull()
    {
        if (PlayerPrefs.GetInt("pass_6_skl") == 1)
        {
            int range = Random.Range(0, 101);
            if (range <= 50)
            {
                _GameController.countHealedSymptomes += _peopleIllness.Count;
                _peopleIllness.Clear();
                _NPC.GetComponent<_PeopleIssues>().setSymptoms(_peopleIllness);
                _fullHealing = true;
            }
            else
            {
                _fullHealing = false;
            }
        }
        else
        {
            _fullHealing = false;
        }
    }
    
    private void stopper()
    {
        sanya.Stop();
    }
}
