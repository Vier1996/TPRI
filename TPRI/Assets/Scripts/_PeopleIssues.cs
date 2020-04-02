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

    private void Awake()
    {
        _illnesses = new InfoAboutIlnesses();
        _symptoms = new List<string>();
        setSymptoms();
    }

    private void setSymptoms()
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
}
