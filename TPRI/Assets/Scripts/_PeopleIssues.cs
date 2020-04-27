using System;
using System.Collections;
using System.Collections.Generic;
using Bestiary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _PeopleIssues : MonoBehaviour
{
    public string _issueName;

    private List<string> _symptoms;
    private InfoAboutIlnesses _illnesses;
    private int _infection, _fatality;

    private void Awake()
    {
        _illnesses = new InfoAboutIlnesses();
        _symptoms = new List<string>();
        _issueName = _IssuesPeopleAccordingScene.getIssue(_GameController.countNPC, SceneManager.GetActiveScene().name);
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
