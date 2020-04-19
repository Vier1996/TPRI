using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _DescriptionController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Descritption;
    [SerializeField] private TextMeshProUGUI refToAnalysis;
    
    public void setName(string _Name)
    {
        Name.text = _Name;
    }

    public string GetName()
    {
        return Name.text;
    }

    public void setDescription(string _Desc)
    {
        Descritption.text = _Desc;
    }

    public void setRefToAnalysis(string refAnalysis)
    {
        refToAnalysis.text = refAnalysis;
    }
}
