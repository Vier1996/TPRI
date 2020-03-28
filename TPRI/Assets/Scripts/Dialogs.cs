using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogs : MonoBehaviour
{
    [SerializeField] private Button _where;
    [SerializeField] private Button _problems;
    [SerializeField] private Button _visit;

    private void Start()
    {
        _where.onClick.AddListener(() =>
        {
            GameObject.FindGameObjectWithTag("WhereD").GetComponent<TextMeshProUGUI>().text = "Ты откуда?";
            GameObject.FindGameObjectWithTag("WhereD").GetComponent<TextMeshProUGUI>().color = Color.red;
        });
        
        _problems.onClick.AddListener(() =>
        {
            GameObject.FindGameObjectWithTag("ProblemsD").GetComponent<TextMeshProUGUI>().text = "Как самочуствие?";
            GameObject.FindGameObjectWithTag("ProblemsD").GetComponent<TextMeshProUGUI>().color = Color.green;
        });
        
        _visit.onClick.AddListener(() =>
        {
            GameObject.FindGameObjectWithTag("VisitD").GetComponent<TextMeshProUGUI>().text = "Цель визита?";
            GameObject.FindGameObjectWithTag("VisitD").GetComponent<TextMeshProUGUI>().color = Color.cyan;
        });
    }
}

