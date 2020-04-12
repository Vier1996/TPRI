﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    void Start()
    {
        sanya.Stop();
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
        if (_NPC == null)
        {
            _NPC = GameObject.FindWithTag("Player");
            _peopleIllness = _NPC.GetComponent<_PeopleIssues>().getSymptoms();
        }
    }

    private void Heal()
    {
        sanya.Play();
        Invoke(nameof(stopper), 1.8f);
        
        int index_cur_sympt = 0;
        for (int i = 0; i < curableSymptoms.Count; i++)
        {
            if (_peopleIllness.Contains(curableSymptoms[i]))
            {
                _peopleIllness.Remove(curableSymptoms[i]);
                PlayerPrefs.SetInt("Key_" + curableSymptoms[i], 1);
            }

            index_cur_sympt++;
        }
        
        _NPC.GetComponent<_PeopleIssues>().setSymptoms(_peopleIllness);
    }

    private void stopper()
    {
        sanya.Stop();
    }
}
