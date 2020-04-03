using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class _GameController : MonoBehaviour
{
    private Button _grassMedicine;
    private GameObject _NPC;
    [SerializeField] private GameObject spawnForPeople; 
    private int _numberNotHealedIssues = 0;
    private Button _passingPeople;
    private Button _expel; // не пропускать
    private List<string> _issues;
    private GameObject _camera;
    private GameObject _dialogPanel;
    private int countNPC = 1;

    private void Awake()
    {
        _grassMedicine = GameObject.Find("Grass").GetComponent<Button>();
        _grassMedicine.onClick.AddListener(()=> Heal());
        
        InitNPC();

        _passingPeople = GameObject.Find("Yes").GetComponent<Button>();
        _passingPeople.onClick.AddListener(()=> Passing());

        _expel = GameObject.Find("No").GetComponent<Button>();
        _expel.onClick.AddListener(()=>Expel());
        
        _camera = GameObject.FindWithTag("MainCamera");
        
        _PeopleIssues issuesScript = _NPC.GetComponent<_PeopleIssues>();
        _issues = issuesScript.getSymptoms();
    }
    

    private void Heal()
    {
        
        Medicines medicines = _grassMedicine.GetComponent<Medicines>();
        List<string> curableSymptoms = medicines.getCurableSymptoms();
        List<string> bufList = new List<string>( _issues);
        for (int i = 0; i < _issues.Count; i++)
        {
            if (curableSymptoms.Contains(_issues[i]))
            {
                bufList.Remove(_issues[i]);
            }
        }

        _issues = bufList;
        Debug.Log(_issues[0] + "   " + _issues[1]);
    }

    private void Passing()
    {
        _PeopleIssues issues = _NPC.GetComponent<_PeopleIssues>();
        _camera.GetComponent<_WorldController>().setPassingIllnesses(1, issues.getIssueName(), _issues.Count);
        Destroy(_NPC);
        Invoke(nameof(InitNPC), 3);
    }

    private void Expel()
    {
        Debug.Log("Пидуй науй");
        Destroy(_NPC);
        resetDialog();
        Invoke(nameof(InitNPC), 3);
    }

    private void InitNPC()
    {
        GameObject npc = Resources.Load<GameObject>("Peolple/PeopleTemplate " + countNPC);
        _NPC = Instantiate(npc, spawnForPeople.transform);
        resetDialog();
        countNPC++;
        if (countNPC == 3)
        {
            countNPC = 0;
        }
    }

    private void resetDialog()
    {
        _dialogPanel = GameObject.Find("dialogsPanel");

        for (int i = 0; i < _dialogPanel.transform.childCount; i++)
        {
            _dialogPanel.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
