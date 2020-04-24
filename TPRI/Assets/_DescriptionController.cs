using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _DescriptionController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Descritption;
    [SerializeField] private TextMeshProUGUI refToAnalysis;
    [SerializeField] private TextMeshProUGUI Price;
    private int _Price = 0;
    
    public void setName(string _Name)
    {
        Name.text = _Name;
    }

    public void setPrice(int _price)
    {
        _Price = _price;
        Price.text = _price.ToString();
    }
    public int GetPrice()
    {
        return _Price;
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
