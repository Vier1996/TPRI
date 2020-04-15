using System;
using System.Collections;
using System.Collections.Generic;
using Bestiary;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class _GameController : MonoBehaviour
{
    public _skillsActivator _SkillsActivator;
    public GameObject[] people;
    [SerializeField] private int CountPuppets;
    [SerializeField] private Transform spawnPlace;
    private static int Ctr = 0;
    public static int Population = 348;

    private Button _grassMedicine;
    private GameObject _NPC;
    [SerializeField] private GameObject spawnForPeople;
    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject alivePeople;
    [SerializeField] private GameObject infectedPeople;
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
    [SerializeField] private int _cityImmunity = 0;

    /// <summary>
    
    /// </summary>

    private void Awake()
    {
        countNPC = LoadPeopleState();
        InitNPC();

        //_DropProgress.DropSkills();
        _passingPeople = GameObject.Find("Yes").GetComponent<Button>();
        _passingPeople.onClick.AddListener(() => Passing());

        _expel = GameObject.Find("No").GetComponent<Button>();
        _expel.onClick.AddListener(() => Expel());

        _camera = GameObject.FindWithTag("MainCamera");

        _PeopleIssues issuesScript = _NPC.GetComponent<_PeopleIssues>();
        _issues = issuesScript.getSymptoms();

        _levelEndController = panelWin.transform.GetChild(0).GetComponent<_LevelEndController>();
        _infectedAndDeadCounter = _Infected_And_Dead_Counter.getInstance();

        if (LoadPeopleState() == 0)
        {
            Population = 348;
            _infectedAndDeadCounter.SetInfected(0);
        }
        else
        {
            Population = PlayerPrefs.GetInt("AlivePeople");
            _infectedAndDeadCounter.SetInfected(PlayerPrefs.GetInt("InfectedPeople"));
        }
    }

    private void Start()
    {
        alivePeople.GetComponent<TextMeshProUGUI>().text = Population.ToString();
        infectedPeople.GetComponent<TextMeshProUGUI>().text = _infectedAndDeadCounter.getInfected().ToString();
        
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
        InfoAboutIlnesses info = new InfoAboutIlnesses();
        int num_of_symptoms = info.getSymptoms()[issues._issueName].Count;
        //people[CountPuppets - 1].GetComponent<_queuePeopleController>().Run();
        //CountPuppets--;
        _levelEndController.setCountPatient(1);
        issues.setSymptoms(tryToHealOneSymptom(issues.getSymptoms()));
        if (issues.getSymptoms().Count != 0)
        {
            int infection = 0;
            passIlls += 1;
            if (PlayerPrefs.GetInt("8_skl") == 1)
            {
                _cityImmunity = 15;
            } 
            if (PlayerPrefs.GetInt("9_skl") == 1)
            {
                _cityImmunity = 30;
            }
            Debug.Log("Count sympt: " + issues.getSymptoms().Count);
            infection = issues.getInfection() * (issues.getSymptoms().Count / num_of_symptoms);
            
            _infectedAndDeadCounter.setFatality(issues.getFatality());
            _infectedAndDeadCounter.countInfectedPeople(infection, Population, _cityImmunity);
            infectedPeople.GetComponent<TextMeshProUGUI>().text = _infectedAndDeadCounter.getInfected().ToString();
            alivePeople.GetComponent<TextMeshProUGUI>().text = Population.ToString();
        }
        else
        {
            healed += 1;
        }
        
        Destroy(_NPC);
        Invoke(nameof(InitNPC), 3);
    }

    private List<string> tryToHealOneSymptom(List<string> symptoms)
    {
        int rate = 0, checkHeal = 0;
        int[] healRandMassHealLvl1 = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9,10};
        int[] healRandMassHealLvl2 = new[] {1, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        
        rate = Random.Range(0, 10);
        
        
        /*if (PlayerPrefs.GetInt(_ResourceKeys.Healing_1) == 10)
        {
            checkHeal = healRandMassHealLvl1[rate];
            Debug.Log("Info from PlayerPrefs: " + PlayerPrefs.GetInt(_ResourceKeys.Healing_1));
        }
        if (PlayerPrefs.GetInt(_ResourceKeys.Healing_2) == 20)
        {
            checkHeal = healRandMassHealLvl2[rate];
            Debug.Log("Info from PlayerPrefs: " + PlayerPrefs.GetInt(_ResourceKeys.Healing_1));
        }*/

        if (PlayerPrefs.GetInt("4_skl") == 1)
        {
            Debug.Log("With healing 1");
            checkHeal = healRandMassHealLvl1[rate];
            Debug.Log("Info from PlayerPrefs: " + checkHeal);
        }

        if (PlayerPrefs.GetInt("7_skl") == 1)
        {
            Debug.Log("With healing 2");
            checkHeal = healRandMassHealLvl2[rate];
            
            Debug.Log("Info from PlayerPrefs: " + checkHeal);
        }
        
        int length = symptoms.Count, randSymptom;
        
        if (checkHeal == 1)
        {
            randSymptom = Random.Range(0, length);
            string symptom = symptoms[randSymptom];
            Debug.Log(symptom);
            symptoms.Remove(symptom);
        }
        return symptoms;
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
        if (countNPC < 5)
        {
            GameObject npc = Resources.Load<GameObject>("Peolple/PeopleTemplate " + countNPC);
            _NPC = Instantiate(npc, spawnForPeople.transform);
            resetDialog();
            countNPC++;
            
            _PeopleIssues issues = _NPC.GetComponent<_PeopleIssues>();
            if (issues.getSymptoms().Count != 0)
            {
                List<string> randomSymptoms = issues.getSymptoms();
                _SkillsActivator.SkillDetection(randomSymptoms[Random.Range(0, randomSymptoms.Count)]);
            }
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
            panelWin.transform.GetChild(0).GetComponent<_LevelEndController>().setPanelWinInfo();
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

    public void SavePeopleState()
    {
        PlayerPrefs.SetInt("AlivePeople", Population);
        PlayerPrefs.SetInt("InfectedPeople", _infectedAndDeadCounter.getInfected());
        PlayerPrefs.SetInt("PEOPLE", countNPC - 1);
    }

    public int LoadPeopleState()
    {
        return PlayerPrefs.GetInt("PEOPLE");
    }

    public void SetNPCcount(int C)
    {
        Debug.Log("drop");
        PlayerPrefs.SetInt("PEOPLE", C);
    }

    private void OnApplicationQuit()
    {
        SetNPCcount(0);
    }

    public void SaveCommonState()
    {
        PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);
        SavePeopleState();
    }
}