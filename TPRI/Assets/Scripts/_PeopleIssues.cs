using System;
using System.Collections;
using System.Collections.Generic;
using Bestiary;
using UnityEngine;

public class _PeopleIssues : MonoBehaviour
{
    public string _issueName = "";

    public List<string> _symptoms;
    private InfoAboutIlnesses _illnesses;
    private int _infection, _fatality;

    private void Awake()
    {
        _illnesses = new InfoAboutIlnesses();
        _symptoms = new List<string>();
        setSymptomsFromDictinary();
        setInfectionAndFatality();
    }

    private void setSymptomsFromDictinary()
    {
        if (!_issueName.Equals(""))
        {
            _symptoms = _illnesses.getSymptoms()[_issueName];
        }
    }

    public List<string> getSymptoms()
    {
        return _symptoms;
    }

    public string getIssueName()
    {
        return _issueName;
    }

    public void setSymptoms(List<string> sympt)
    {
        _symptoms = sympt;
    }

    private void setInfectionAndFatality()
    {
        _infection = _illnesses.getValueInfection()[_issueName];
        _fatality = _illnesses.getValueFatality()[_issueName];
    }

    public int getInfection()
    {
        return _infection;
    }

    public int getFatality()
    {
        return _fatality;
    }
}
