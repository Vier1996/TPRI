using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicines : MonoBehaviour
{
    private string _nameMedicine;

    private List<string> _curableSymptoms;

    private void Awake()
    {
        _nameMedicine = "Трава";
        setCurableSymptoms();
    }

    private void setCurableSymptoms()
    {
        _curableSymptoms = new List<string>();
        _curableSymptoms.Add("Кашель");
        _curableSymptoms.Add("Озноб");
        _curableSymptoms.Add("Потливость");
        _curableSymptoms.Add("Мигрень");
    }

    public List<string> getCurableSymptoms()
    {
        return _curableSymptoms;
    }
}
