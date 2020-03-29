using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class _bestiaryController : MonoBehaviour
{
    private TextMeshPro[] _viruses;
    private GameObject _scrollForViruses;
    private ScrollView ScrollView;
    private VisualElement _visualElement;
    private ScrollRect _scrollRect;

    private void Awake()
    {
        _scrollForViruses = GameObject.Find("ListOfViruses");
        int countViruses = _scrollForViruses.GetComponent<ScrollView>().contentContainer.childCount;
        ScrollView = _scrollForViruses.GetComponent<ScrollView>();
        TextMeshProUGUI t = new TextMeshProUGUI();
        t.text = "asdasdasd";
        
        _viruses = new TextMeshPro[countViruses];
        for (int i = 0; i < countViruses; i++)
        {
            _visualElement = ScrollView.contentContainer.ElementAt(i);
        }
    }
}
