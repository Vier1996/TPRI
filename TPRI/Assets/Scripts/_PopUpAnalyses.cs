using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _PopUpAnalyses : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI patient, nameOfAnalysis, result;
    [SerializeField] private Button close;
    [SerializeField] private GameObject resultOfAnalysis, table;

    private GameObject _NPC;
    private const string PATIENT = "Patient:", ANALYSIS = "Analysis: ", RESULT = "Result: ";

    private void Start()
    {
        _NPC = GameObject.FindWithTag("Player");
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (GetComponent<_ResearchElementScript>().IntegerAmount > 0 && _NPC != null)
            {
                resultOfAnalysis.SetActive(true);
                patient.text += " " + _NPC.GetComponent<_peopleState>().nameOfPatient;
                nameOfAnalysis.text += " " + gameObject.name.ToLower();
                result.text += " " + GetComponent<AnalysMap>()._check();
            }
        });
        close.onClick.AddListener(() =>
        {
            patient.text = PATIENT;
            nameOfAnalysis.text = ANALYSIS;
            result.text = RESULT;
            resultOfAnalysis.SetActive(false);
        });
    }

    private void Update()
    {
        if (_NPC == null)
        {
            _NPC = GameObject.FindWithTag("Player");
        }
    }
}