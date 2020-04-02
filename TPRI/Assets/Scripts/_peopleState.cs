using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _peopleState : _dialogContainer
{
    [SerializeField] string theDialog;
    private TextMeshProUGUI toSpeak;
    private GameObject dialogPanel;
    
    private bool _whereD;
    private bool _problemsD;
    private bool _visitD;

    private void Awake()
    {
        dialogPanel = GameObject.FindGameObjectWithTag("DP");
        toSpeak = dialogPanel.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        toSpeak.text = BaseDialogs[0];
        _whereD = _problemsD = _visitD = false;
    }

    // Update is called once per frame
    void Update()
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
