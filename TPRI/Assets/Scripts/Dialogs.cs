using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UIElements.Image;
using DG.Tweening;
using UnityEngine.Animations;


public class Dialogs : MonoBehaviour
{
    [SerializeField] private Button _where;
    [SerializeField] private Button _problems;
    [SerializeField] private Button _visit;
    [SerializeField] private GameObject deactQuestion;
    [SerializeField] private GameObject textMSG;

    private void Start()
    {
        _where.onClick.AddListener(() =>
        {
            if (_equipmentScript._showDialogs)
            {
                GameObject.FindGameObjectWithTag("WhereD").GetComponent<TextMeshProUGUI>().text = "Ты откуда?";
                GameObject.FindGameObjectWithTag("WhereD").GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else
            {
                deactQuestion.GetComponent<Animation>().Play("DeactPanel");
            }
        });
        
        _problems.onClick.AddListener(() =>
        {
            if (_equipmentScript._showDialogs)
            {
                GameObject.FindGameObjectWithTag("ProblemsD").GetComponent<TextMeshProUGUI>().text = "Как самочуствие?";
                GameObject.FindGameObjectWithTag("ProblemsD").GetComponent<TextMeshProUGUI>().color = Color.green;
            }
            else
            {
                deactQuestion.GetComponent<Animation>().Play("DeactPanel");
            }
        });
        
        _visit.onClick.AddListener(() =>
        {
            if (_equipmentScript._showDialogs)
            {
                GameObject.FindGameObjectWithTag("VisitD").GetComponent<TextMeshProUGUI>().text = "Цель визита?";
                GameObject.FindGameObjectWithTag("VisitD").GetComponent<TextMeshProUGUI>().color = Color.cyan;
            }
            else
            {
                deactQuestion.GetComponent<Animation>().Play("DeactPanel");
            }
        });
    }
}

