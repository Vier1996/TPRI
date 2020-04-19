using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _LocalizedText : MonoBehaviour
{
    [SerializeField] private string KEY;

    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = _LocalizedMap.GetLocalisedText(KEY);
    }

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = _LocalizedMap.GetLocalisedText(KEY);
    }
}
