using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PeopleIssues : MonoBehaviour
{
    private string _issueName;

    private List<string> _symptoms;

    private void Awake()
    {
        _issueName = "Грипп";
        setSymptoms();
    }

    private void setSymptoms()
    {
        _symptoms = new List<string>();
        _symptoms.Add("Кашель");
        _symptoms.Add("Потливость");
        _symptoms.Add("Насморк");
        _symptoms.Add("Озноб");
        _symptoms.Add("Температура");
    }

    public List<string> getSymptoms()
    {
        return _symptoms;
    }

    public string getIssueName()
    {
        return _issueName;
    }
}
