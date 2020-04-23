using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class _peopleState : _dialogContainer
{
    [SerializeField] string theDialog;
    [SerializeField] private string[] analysis;

    public string nameOfPatient;
    
    private TextMeshProUGUI toSpeak;
    private bool _whereD;
    private bool _problemsD;
    private bool _visitD;
    private Analisys _analisys;
    private string issue;


    private void Start()
    {
        issue = gameObject.GetComponent<_PeopleIssues>()._issueName;
        toSpeak = GameObject.FindWithTag("dialogPanel").GetComponent<TextMeshProUGUI>();
        toSpeak.text = BaseDialogs[issue] + nameOfPatient;
        _whereD = _problemsD = _visitD = false;
        _analisys = new Analisys(analysis);
        // 
    }

    // Update is called once per frame
    private void Update()
    {
        try
        {
            if (GameObject.FindGameObjectWithTag("WhereD").GetComponent<TextMeshProUGUI>().text != "" && !_whereD)
            {
                GameObject.FindGameObjectWithTag("WhereAnswer").GetComponent<TextMeshProUGUI>().text += WhereDialogs[issue];
                _whereD = true;
            }

            if (GameObject.FindGameObjectWithTag("ProblemsD").GetComponent<TextMeshProUGUI>().text != "" && !_problemsD)
            {
                GameObject.FindGameObjectWithTag("ProblemsAnswer").GetComponent<TextMeshProUGUI>().text +=
                    ProblemsDialogs[issue];
                _problemsD = true;
            }

            if (GameObject.FindGameObjectWithTag("VisitD").GetComponent<TextMeshProUGUI>().text != "" && !_visitD)
            {
                GameObject.FindGameObjectWithTag("VisitAnswer").GetComponent<TextMeshProUGUI>().text += VisitDialogs[Random.Range(0, VisitDialogs.Count)];
                _visitD = true;
            }
        }
        catch (NullReferenceException)
        {
        }
    }

    public Analisys getAnalysis()
    {
        return _analisys;
    }
}

public class Analisys
{
    private Dictionary<string, string> _availableAnalysis;

    public Analisys(string[] analyses)
    {
        _availableAnalysis = new Dictionary<string, string>();
        setAvailableResult(analyses);
    }

    private void setAvailableResult(string[] analysis)
    {
        _availableAnalysis.Add("Blood", analysis[0]);
        _availableAnalysis.Add("Pee", analysis[1]);
        _availableAnalysis.Add("Smear", analysis[2]);
        _availableAnalysis.Add("Sputum", analysis[3]);
        _availableAnalysis.Add("Saliva", analysis[4]);
        _availableAnalysis.Add("Shit", analysis[5]);
    }

    public string getResultOfAnalysis(string name)
    {
        return _availableAnalysis[name];
    }
}
