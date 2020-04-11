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
    public GameObject[] people;
    [SerializeField] private int CountPuppets;
    [SerializeField] private Transform spawnPlace;
    private static int Ctr = 0;
    public static int Population = 348;


    private Button _grassMedicine;
    private GameObject _NPC;
    [SerializeField] private GameObject spawnForPeople;
    [SerializeField] private GameObject panelWin;
    private _LevelEndController _levelEndController;
    private int _numberNotHealedIssues = 0;
    private Button _passingPeople;
    private Button _expel; // не пропускать
    private List<string> _issues;
    private GameObject _camera;
    private GameObject _dialogPanel;
    private int countNPC = 0;
    private int passIlls = 0, healed = 0;
    private _Infected_And_Dead_Counter _infectedAndDeadCounter;
    
    /// <summary>
    
    /// </summary>

    private void Awake()
    {
        InitNPC();

        _passingPeople = GameObject.Find("Yes").GetComponent<Button>();
        _passingPeople.onClick.AddListener(() => Passing());

        _expel = GameObject.Find("No").GetComponent<Button>();
        _expel.onClick.AddListener(() => Expel());

        _camera = GameObject.FindWithTag("MainCamera");

        _PeopleIssues issuesScript = _NPC.GetComponent<_PeopleIssues>();
        _issues = issuesScript.getSymptoms();

        _levelEndController = panelWin.transform.GetChild(0).GetComponent<_LevelEndController>();
        _infectedAndDeadCounter = _Infected_And_Dead_Counter.getInstance();
    }

    private void Start()
    {
        Invoke(nameof(SpawnPuppets), 1f);
        Invoke(nameof(SpawnPuppets), 2f);
        Invoke(nameof(SpawnPuppets), 3f);
        Invoke(nameof(SpawnPuppets), 4f);
        Invoke(nameof(SpawnPuppets), 5f);
    }

    private void SpawnPuppets()
    {
        Instantiate(people[Ctr], spawnPlace);
        Ctr++;
    }

    private void Passing()
    {
        _PeopleIssues issues = _NPC.GetComponent<_PeopleIssues>();
        
        //people[CountPuppets - 1].GetComponent<_queuePeopleController>().Run();
        //CountPuppets--;
        _levelEndController.setCountPatient(1);
        if (issues.getSymptoms().Count != 0)
        {
            passIlls += 1;
            _infectedAndDeadCounter.setNPC(issues.getFatality());
            _infectedAndDeadCounter.countInfectedPeople(issues.getInfection(), Population);
            Debug.Log(Population);
            //_infectedAndDeadCounter.countDeadPeople(issues.getFatality(), Population);
        }
        else
        {
            healed += 1;
        }
        
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
        if (countNPC < 3)
        {
            GameObject npc = Resources.Load<GameObject>("Peolple/PeopleTemplate " + countNPC);
            _NPC = Instantiate(npc, spawnForPeople.transform);
            resetDialog();
            countNPC++;
        }
        else
        {
            Time.timeScale = 0f;
            panelWin.SetActive(true);
            _levelEndController.setCountHealed(healed);
            _levelEndController.setCountPatient(countNPC);
            _levelEndController.setCountPassIlls(passIlls);
            _levelEndController.setCountInfected(_infectedAndDeadCounter.getInfected());
            _levelEndController.setCountDead(_infectedAndDeadCounter.getDead());
            panelWin.transform.GetChild(0).GetComponent<_LevelEndController>().setPanelWinInfo(Population);
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