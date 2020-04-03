using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _peopleState : _dialogContainer
{
    [SerializeField] string theDialog;
    [SerializeField] private Button[] analysisButtons;
    private TextMeshProUGUI toSpeak;
    private bool _whereD;
    private bool _problemsD;
    private bool _visitD;
    private int t;
    
    
    private void Start()
    {
        toSpeak = GameObject.FindWithTag("dialogPanel").GetComponent<TextMeshProUGUI>();
        toSpeak.text = BaseDialogs[0];
        _whereD = _problemsD = _visitD = false;
        
        Analisys _analisys = new Analisys(analysisButtons);
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
}

class Analisys
{
    public string Blood = "отрицательный";
    public string Pee = "отрицательный";
    public string Smear = "отрицательный"; // мазок
    public string Sputum = "отрицательный"; // мокрота
    public string Saliva = "отрицательный"; // слюна
    public string Shit = "отрицательный";
    public GameObject AnalysController;
    private Button[] analysisButtons;

    public Analisys(Button[] analyses)
    {
        AnalysController = GameObject.FindGameObjectWithTag("Analysis");
        analysisButtons = analyses;
        setListenersOnButtonsAnalysis();
    }

    public void setListenersOnButtonsAnalysis()
    {
        for (int i = 0; i < analysisButtons.Length; i++)
        {
            //analysisButtons[i].onClick.AddListener();
        }
    }
    
    public Analisys(string _blood, string _pee, string _smear, string _sputum, string _saliva, string _shit)
    {
        if (_blood.Equals("+"))
            _blood = "положительный";
        
        if (_pee.Equals("+"))
            _pee = "положительный";
        
        if (_smear.Equals("+"))
            _smear = "положительный";
        
        if (_sputum.Equals("+"))
            _sputum = "положительный";
        
        if (_saliva.Equals("+"))
            _saliva = "положительный";
        
        if (_shit.Equals("+"))
            _shit = "положительный";
    }
}
