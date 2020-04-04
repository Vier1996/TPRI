using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _storeIMGcontroller : MonoBehaviour
{
    private const string key = "DWEQ";
    
    [SerializeField] private string _Name;
    [SerializeField] private string _Description;

    private _DescriptionController info;
    
    private void Start()
    {
        info = GameObject.FindGameObjectWithTag("store").GetComponent<_DescriptionController>();
        
        GetComponent<Button>().onClick.AddListener(() =>
        {
            info.setName(_Name);
            info.setDescription(_Description);
        });
    }
}
