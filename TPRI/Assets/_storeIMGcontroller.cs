using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _storeIMGcontroller : MonoBehaviour
{
    [SerializeField] private string _Name;
    [SerializeField] private string _Description;
    [SerializeField] private string _refToAnalysis;
    [SerializeField] private int prcie;

    private _DescriptionController info;
    
    private void Start()
    {
        info = GameObject.FindGameObjectWithTag("store").GetComponent<_DescriptionController>();
        
        GetComponent<Button>().onClick.AddListener(() =>
        {
            info.setName(_Name);
            info.setPrice(prcie);
            info.setDescription(_Description);
            info.setRefToAnalysis(_refToAnalysis);
        });
    }
}
