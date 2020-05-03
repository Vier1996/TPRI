using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnalysMap : MonoBehaviour
{
    [SerializeField] private string[] symptoms;
    [SerializeField] private _GameController obj;

    public string _check()
    {
        List<string> continer = obj._issues;
        string exp = "negative";
        
        foreach (var var in continer)
        {
            if (symptoms.Contains(var))
            {
                return "positive";
                break;
            }
        }

        return exp;
    }
}


