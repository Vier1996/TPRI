﻿using System;
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
    [SerializeField] private GameObject b_killHim;
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
    [SerializeField] private GameObject panelDefeat;
    private int _additionalShoot;
    private float patientX = -11f, patientY = -14f, patientZ = 86f;

    [SerializeField] private Button endMenu;
    [SerializeField] private Button endNextLevel;

    /// <summary>
    
    /// </summary>

    private void Awake()
    {
        countNPC = LoadPeopleState();
        InitNPC();
        setAdditonalShoot();
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
        
        b_killHim.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (_additionalShoot != 0)
            {
                if (_NPC != null)
                {
                    Destroy(_NPC);
                    Invoke(nameof(InitNPC), 3);
                    _additionalShoot--;
                }
            }
        });
        
        endMenu.onClick.AddListener(() => { SceneManager.LoadScene("_introMenu"); });
        endNextLevel.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }); //пофиксить для 7го левла
    }

    private void setAdditonalShoot()
    {
        bool checkShoot = false;
        if (PlayerPrefs.GetInt("pass_1_skl") == 1)
        {
            _additionalShoot = 1;
            checkShoot = true;
        }
        if (PlayerPrefs.GetInt("pass_2_skl") == 1)
        {
            _additionalShoot = 2;
            checkShoot = true;
        }
        if (PlayerPrefs.GetInt("pass_3_skl") == 1)
        {
            _additionalShoot = 3;
            checkShoot = true;
        }
        if(!checkShoot) _additionalShoot = 0;
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
        int numOfSymptoms = info.getSymptoms()[issues._issueName].Count;
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
            double changeInfection = (double)issues.getSymptoms().Count / numOfSymptoms;
            Debug.Log("Infection before changes: " + issues.getInfection());
            infection = (int)(issues.getInfection() * changeInfection);
            Debug.Log("After changes: " + infection);
            
            _infectedAndDeadCounter.setFatality(issues.getFatality());
            _infectedAndDeadCounter.countInfectedPeople(infection, Population, _cityImmunity);
            infectedPeople.GetComponent<TextMeshProUGUI>().text = _infectedAndDeadCounter.getInfected().ToString();
            alivePeople.GetComponent<TextMeshProUGUI>().text = Population.ToString();
            if (_infectedAndDeadCounter.getInfected() == 0)
            {
                Time.timeScale = 0;
                panelDefeat.SetActive(true);
                _levelEndController.setCountDead(_infectedAndDeadCounter.getDead());
                _levelEndController.setCountPatient(countNPC);
                _levelEndController.setCountPassIlls(passIlls);
                _levelEndController.setPanelDefeat();
            }
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
            GameObject npc = Resources.Load<GameObject>("Peolple/Patient" + countNPC);
            _NPC = Instantiate(npc);
            _NPC.transform.position = new Vector3(patientX, patientY, patientZ);
            resetDialog();
            countNPC++;
            
            _PeopleIssues issues = _NPC.GetComponent<_PeopleIssues>();
            if (issues.getSymptoms().Count != 0)
            {
                List<string> randomSymptoms = issues.getSymptoms();
                _SkillsActivator.SkillDetection(randomSymptoms[Random.Range(0, randomSymptoms.Count)]);
            }

            MaybeIDie(_NPC.GetComponent<_PeopleIssues>().getInfection());
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
            _levelEndController.setPopulation(Population + _infectedAndDeadCounter.getInfected());
            _levelEndController.setMoney();
            _levelEndController.setCountSkillPoints();
            panelWin.transform.GetChild(0).GetComponent<_LevelEndController>().setPanelWinInfo();
            
            if(GetComponent<_WorldController>().GetDays() > 0)
                GetComponent<_WorldController>().SetDays(GetComponent<_WorldController>().GetDays() - 1);
        }
    }

    private void setScalePatient()
    {
        List<int> indexPatients1 = new List<int>() {0, 1, 4, 6, 7, 8, 10};
        List<int> indexPatients2 = new List<int>() {2, 5, 9, 11, 12, 13};
        float scale = 0f;
        if (indexPatients1.Contains(countNPC))
        {
            scale = 441.5f;
        }

        if (indexPatients2.Contains(countNPC))
        {
            scale = 15;
        }

        if (countNPC == 3) scale = 400f;
        _NPC.GetComponent<_scaler>()._Scale = scale;
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

    private void MaybeIDie(int infection)
    {
        int _defaultProtection = (int) (infection * (0.3 + PlayerPrefs.GetInt(_ResourceKeys.Defense)/100));
        int rate = infection - _defaultProtection;
        int Chance = Random.Range(1, 101);

        Debug.Log(rate);
        
        if(Chance <= rate)
            PlayerPrefs.SetInt(_ResourceKeys.OurDeath, 1);
    }
}