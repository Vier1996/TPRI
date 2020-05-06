using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _skillDialogController : MonoBehaviour
{
    [SerializeField] private Animation defaultDialogAnimation;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Descritption;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Button Get;

    private void Start()
    {
        Debug.Log("Animation");
        defaultDialogAnimation.Play();
    }

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
    
    public void setPrice(string _price)
    {
        price.text = _price;
    }
    
    public Button GetButton()
    {
        return Get;
    }
}
