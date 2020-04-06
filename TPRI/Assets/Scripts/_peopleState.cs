using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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


    private void Start()
    {
        toSpeak = GameObject.FindWithTag("dialogPanel").GetComponent<TextMeshProUGUI>();
        toSpeak.text = BaseDialogs[0];
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
                GameObject.FindGameObjectWithTag("WhereAnswer").GetComponent<TextMeshProUGUI>().text += WhereDialogs[0];
                _whereD = true;
            }

            if (GameObject.FindGameObjectWithTag("ProblemsD").GetComponent<TextMeshProUGUI>().text != "" && !_problemsD)
            {
                GameObject.FindGameObjectWithTag("ProblemsAnswer").GetComponent<TextMeshProUGUI>().text +=
                    ProblemsDialogs[0];
                _problemsD = true;
            }

            if (GameObject.FindGameObjectWithTag("VisitD").GetComponent<TextMeshProUGUI>().text != "" && !_visitD)
            {
                GameObject.FindGameObjectWithTag("VisitAnswer").GetComponent<TextMeshProUGUI>().text += VisitDialogs[0];
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
    /*public string Blood = "отрицательный";
    public string Pee = "отрицательный";
    public string Smear = "отрицательный"; // мазок
    public string Sputum = "отрицательный"; // мокрота
    public string Saliva = "отрицательный"; // слюна
    public string Shit = "отрицательный";
    public GameObject AnalysController;*/
    private Dictionary<string, string> _availableAnalysis;

    public Analisys(string[] analyses)
    {
        //AnalysController = GameObject.FindGameObjectWithTag("Analysis");
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
