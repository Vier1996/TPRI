﻿using System;
using System.Collections;
using System.Collections.Generic;
using Bestiary;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class _GameController : MonoBehaviour
{
    public AnimatedText AT;
    public _skillsActivator _SkillsActivator;
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
    [SerializeField] private GameObject notificationPanel;
    private _LevelEndController _levelEndController;
    private int _numberNotHealedIssues = 0;
    private Button _passingPeople;
    private Button _expel; // не пропускать
    public List<string> _issues;
    private GameObject _camera;
    private GameObject _dialogPanel;
    public static int countNPC = 0;
    private int passIlls = 0, healed = 0;
    private _Infected_And_Dead_Counter _infectedAndDeadCounter;
    [SerializeField] private int _cityImmunity = 0;
    [SerializeField] private GameObject panelDefeat;
    [SerializeField] private GameObject panelDefeat1;
    private int _additionalShoot;
    private float patientX = -11f, patientY = -14f, patientZ = 86f;
    private float patientSecX = -11, patientSecY = -5, patientSecZ = 86f;
    public static int countHealedSymptomes = 0;
    private int _countNPCAccrodingLevel = 0;
    private const string FIRST_TiME = "first time";

    [SerializeField] private Button endMenu;
    [SerializeField] private Button endNextLevel;

    [SerializeField] private QUEUE _queue;
    
    
    [SerializeField] private Animation BIGDOOR;
    
    [SerializeField] private GameObject[] Particles;
    
    [SerializeField] private Animation pistolAnim;
    [SerializeField] private Animation SekiraInam;
    
    [SerializeField] private AudioSource SwordStrike;
    [SerializeField] private AudioSource endGame;
    [SerializeField] private AudioSource victory;
    [SerializeField] private AudioSource toBeContinue;
    [SerializeField] private AudioSource _DoorSound;
    [SerializeField] private AudioSource WARNING;
    [SerializeField] private AudioSource backGround;
    private bool isWarning = false;


    private string oldPopulation;

    [SerializeField] private GameObject warningAffectPanel;
    
    private List<string> UPPERSymptoms;

    /// <summary>
    
    /// </summary>

    private void Awake()
    {
        PlayerPrefs.SetInt(_ResourceKeys.CharacterLevel, 20);
        isWarning = false;
        backGround.Play();
       
        if (PlayerPrefs.GetInt(FIRST_TiME) == 0)
        {
            PlayerPrefs.SetInt("AlivePeople", 348);
            PlayerPrefs.SetInt("InfectedPeople", 0);
            PlayerPrefs.SetInt("PEOPLE", 0);
            PlayerPrefs.SetInt(FIRST_TiME, 1);
        }
        
        _countNPCAccrodingLevel = _IssuesPeopleAccordingScene.getCountNPC(SceneManager.GetActiveScene().name);
        countNPC = 0;
      
        setAdditonalShoot();

        //_DropProgress.DropSkills();
        _passingPeople = GameObject.Find("Yes").GetComponent<Button>();
        _passingPeople.onClick.AddListener(() => Passing());

        _levelEndController = panelWin.transform.GetChild(0).GetComponent<_LevelEndController>();
        _infectedAndDeadCounter = _Infected_And_Dead_Counter.getInstance();
        _infectedAndDeadCounter.SetInfected(PlayerPrefs.GetInt("InfectedPeople"));
        AddAffectRedScreen();
        

        _expel = GameObject.Find("No").GetComponent<Button>();
        _expel.onClick.AddListener(() => Expel());

        _camera = GameObject.FindWithTag("MainCamera");
        
        if (PlayerPrefs.GetInt("GCBesiariiCome") != 1)
        {
            Population = PlayerPrefs.GetInt("AlivePeople");
            _infectedAndDeadCounter.SetInfected(PlayerPrefs.GetInt("InfectedPeople"));
        }
        else
        {
            PlayerPrefs.SetInt("GCBesiariiCome", 0);
            Population = PlayerPrefs.GetInt("AlivePeople");
            _infectedAndDeadCounter.SetInfected(PlayerPrefs.GetInt("InfectedPeople"));
            countNPC = PlayerPrefs.GetInt("PEOPLE");
            _queue.adaptation(countNPC);
        }
        
        alivePeople.GetComponent<TextMeshProUGUI>().text = Population.ToString();
        infectedPeople.GetComponent<TextMeshProUGUI>().text = _infectedAndDeadCounter.getInfected().ToString();

        if (_additionalShoot == 0)
        {
            b_killHim.GetComponent<Button>().interactable = false;
        }
        else
        {
            b_killHim.GetComponent<Button>().interactable = true;
        }
        b_killHim.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (_additionalShoot != 0)
            {
                if (_NPC != null)
                {
                    pistolAnim.Play();
                    SekiraInam.Play();

                    Invoke(nameof(swordStrike), 1f);
                    Destroy(_NPC);
                    Invoke(nameof(InitNPC), 3);
                    _additionalShoot--;
                    int count = PlayerPrefs.GetInt(_ResourceKeys.Count_Killed) + 1;
                    if (count == 50)
                    {
                        PlayerPrefs.SetInt(_ResourceKeys.Геноцид, 1);
                    }
                    PlayerPrefs.SetInt(_ResourceKeys.Count_Killed, count);

                    if (_additionalShoot == 0)
                    {
                        b_killHim.GetComponent<Button>().interactable = false;
                    }
                }
            }
        });
        
        InitNPC();
        
        _PeopleIssues issuesScript = _NPC.GetComponent<_PeopleIssues>();
        _issues = issuesScript.getSymptoms();

        endMenu.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("_introMenu");
            LevelClearedHelper();
        });
        
        endNextLevel.onClick.AddListener(() =>
        {
            SaveStateToNextLevel();
            Time.timeScale = 1;
            PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            LevelClearedHelper();
        });

        foreach (var Part in Particles)
        {
            Part.SetActive(false);
        }

        oldPopulation = Population.ToString();
    }

    private void swordStrike()
    {
        SwordStrike.Play();
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
    private void stopper()
    {
        _passingPeople.interactable = true;
        _expel.interactable = true;
    }

    private void Passing()
    {
        _queue.PsholVon(true);
        _passingPeople.interactable = false;
        _expel.interactable = false;
        TurnOffParticles();
        Invoke(nameof(stopper), 5f);
        
        
        _PeopleIssues issues = _NPC.GetComponent<_PeopleIssues>();
        InfoAboutIlnesses info = new InfoAboutIlnesses();
        if (!issues._issueName.Equals("HEALTHY"))
        {
            int numOfSymptoms = info.getSymptoms()[issues._issueName].Count;
            _levelEndController.setCountPatient(1);
            if (issues.getSymptoms().Count != 0)
            {
                issues.setSymptoms(tryToHealOneSymptom(issues.getSymptoms()));
            }

            if (issues.getSymptoms().Count != 0)
            {
                int infection = 0;
                passIlls += 1;
                Warnings();
                if (PlayerPrefs.GetInt("8_skl") == 1)
                {
                    _cityImmunity = 15;
                }

                if (PlayerPrefs.GetInt("9_skl") == 1)
                {
                    _cityImmunity = 30;
                }

                Debug.Log("Count sympt: " + issues.getSymptoms().Count);
                double changeInfection = (double) issues.getSymptoms().Count / numOfSymptoms;
                Debug.Log("Infection before changes: " + issues.getInfection());
                infection = (int) (issues.getInfection() * changeInfection);
                Debug.Log("After changes: " + infection);
                
               int preinfected = _infectedAndDeadCounter.getInfected();
               
               _infectedAndDeadCounter.setFatality(issues.getFatality());
               _infectedAndDeadCounter.countInfectedPeople(infection, Population, _cityImmunity);

               if (preinfected < _infectedAndDeadCounter.getInfected())
               {
                   changeTextInfetced(preinfected, _infectedAndDeadCounter.getInfected(), true);
               }
               else
               {
                   changeTextInfetced(preinfected, _infectedAndDeadCounter.getInfected(), false);
               }

               if (Population <= 75 && !isWarning)
                {
                    backGround.volume = backGround.volume - 0.5f;
                    isWarning = true;
                    WARNING.Play();
                    Invoke(nameof(stopWarning), 3f);
                }

                if (issues._issueName.Equals("Коронавирус"))
                {
                    backGround.volume = backGround.volume - 0.5f;
                    toBeContinue.Play();
                    Invoke(nameof(stopToBeContinue), 8f);
                }
            }
            else
            {
                healed += 1;
                int count = PlayerPrefs.GetInt(_ResourceKeys.Count_healed_People) + 1;
                if (count >= 20)
                {
                    PlayerPrefs.SetInt(_ResourceKeys.Врач_от_бога, 1);
                }

                PlayerPrefs.SetInt(_ResourceKeys.Count_healed_People, count);
            }
        }
        
        if (_infectedAndDeadCounter.getInfected() == 0 && Population == 0)
        {
            Particles[0].SetActive(false);
            Particles[1].SetActive(false);
            Particles[2].SetActive(false);
            PlayerPrefs.SetInt(FIRST_TiME, 0);
            PlayerPrefs.SetInt("AlivePeople", 348);
            PlayerPrefs.SetInt("InfectedPeople", 0);
            PlayerPrefs.SetInt("PEOPLE", 0);
            panelDefeat1.SetActive(true);
            Instantiate(panelDefeat, panelDefeat1.transform);
            backGround.Stop();
            endGame.Play();
            PlayerPrefs.SetInt("CurrentLevel", 3);
        }
        
       AddAffectRedScreen();
        
        Destroy(_NPC);
        if(countNPC != 0)
            BIGDOOR.Play("BIGDOOR");
        backGround.volume = backGround.volume - 0.5f;
        _DoorSound.Play();
        Invoke(nameof(DoorSoundStop), 2f);
        Invoke(nameof(InitNPC), 3);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);
    }

    private void stopToBeContinue()
    {
        backGround.volume = backGround.volume + 0.5f;
        toBeContinue.Stop();
    }

    private void stopWarning()
    {
        backGround.volume = backGround.volume + 0.5f;
        WARNING.Stop();
    }
    
    private void DoorSoundStop()
    {
        backGround.volume = backGround.volume + 0.5f;
        _DoorSound.Stop();
    }

    private void AddAffectRedScreen()
    {
        var col = warningAffectPanel.GetComponent<Image>().color;
        if (Population + _infectedAndDeadCounter.getInfected() <= 250)
        {
            col = new Color(col.r, col.g, col.b, 0.1058824f);
        }
        else if (Population + _infectedAndDeadCounter.getInfected() <= 150)
        {
            col = new Color(col.r, col.g, col.b, 0.1686275f);
        }
        else if (Population + _infectedAndDeadCounter.getInfected() <= 75)
        {
            col = new Color(col.r, col.g, col.b, 0.3568628f);
        }
        else if (Population + _infectedAndDeadCounter.getInfected() <= 50)
        {
            col = new Color(col.r, col.g, col.b, 0.6f);
        }
        else
        {
            col = new Color(col.r, col.g, col.b, 0f);
        }
        warningAffectPanel.GetComponent<Image>().color = col;
    }
    
    private void Warnings()
    {
        int range, percent = 0;
        if (PlayerPrefs.GetInt("pass_4_skl") == 1)
        {
            percent = 99;
        }

        if (PlayerPrefs.GetInt("pass_5_skl") == 1)
        {
            percent = 99;
        }
        range = Random.Range(0, 101);
        if (range <= percent)
        {
            notificationPanel.SetActive(true);
            string nameIssue = _NPC.GetComponent<_PeopleIssues>()._issueName.ToLower();
            notificationPanel.transform.GetChild(0)
                    .GetComponent<TextMeshProUGUI>().text = "Была пропущена болезнь - " 
                                                            + (PlayerPrefs.GetInt("Key_" + nameIssue)==1 ? nameIssue : "???");
            Invoke(nameof(DisableNotification), 13f);
        }
    }

    private void DisableNotification()
    {
        notificationPanel.SetActive(false);
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
            countHealedSymptomes++;
        }
        return symptoms;
    } 
        
    private void Expel()
    {
        Debug.Log("Пидуй науй");
        Destroy(_NPC);
        resetDialog();
        
        TurnOffParticles();
        
        if(countNPC != 0)
            BIGDOOR.Play("BIGDOOR");
        _DoorSound.Play();
        Invoke(nameof(DoorSoundStop), 2f);
        
        _queue.PsholVon(true);
        _passingPeople.interactable = false;
        Invoke(nameof(stopper), 5f);
        
        Invoke(nameof(InitNPC), 3);
        _levelEndController.incrementExpelPeople();
    }
    
    private void InitNPC()
    {
        if (countNPC < _countNPCAccrodingLevel)
        {
            GameObject npc = Resources.Load<GameObject>("Peolple/Patient" + countNPC);
            Debug.Log("           " + countNPC);
            _NPC = Instantiate(npc);
            if (countNPC == 5  || countNPC>=18)
            {
                _NPC.transform.position = new Vector3(patientX, patientY, patientZ);
            }
            else if (countNPC == 0)
            {
                _NPC.transform.position = new Vector3(-11, -3.55f, 86);
            }
            else if (countNPC == 10)
            {
                _NPC.transform.position = new Vector3(patientX, -3.4f, patientZ);
            }
            else
            {
                _NPC.transform.position = new Vector3(patientSecX, patientSecY, patientSecZ);
            }
            
            resetDialog();
            countNPC++;
            
            _PeopleIssues issues = _NPC.GetComponent<_PeopleIssues>();
            _issues = _NPC.GetComponent<_PeopleIssues>().getSymptoms();
            if (issues.getSymptoms() != null && issues.getSymptoms().Count != 0)
            {
                List<string> randomSymptoms = issues.getSymptoms();
                UPPERSymptoms = randomSymptoms;
                
                ParticleHelper(randomSymptoms);
                
                _SkillsActivator.SkillDetection(randomSymptoms[Random.Range(0, randomSymptoms.Count)]);
            }

            MaybeIDie(_NPC.GetComponent<_PeopleIssues>().getInfection());
        }
        else
        {
            backGround.Stop();
            panelWin.SetActive(true);
            victory.Play();
            _levelEndController.setCountHealed(healed);
            _levelEndController.setCountPatient(countNPC);
            _levelEndController.setCountPassIlls(passIlls);
            _levelEndController.setCountInfected(_infectedAndDeadCounter.getInfected());
            _levelEndController.setCountDead(_infectedAndDeadCounter.getDead());
            _levelEndController.setPopulation(Population + _infectedAndDeadCounter.getInfected());
            _levelEndController.setMoney();
            panelWin.transform.GetChild(0).GetComponent<_LevelEndController>().setPanelWinInfo();
            
            PlayerPrefs.SetInt("AlivePeople", Population);
            PlayerPrefs.SetInt("InfectedPeople", _infectedAndDeadCounter.getInfected());
            
            if(GetComponent<_WorldController>().GetDays() > 0)
                GetComponent<_WorldController>().SetDays(GetComponent<_WorldController>().GetDays() - 1);

            LevelClearedHelper();
        }
    }

    public void RESETSYMPTOMES()
    {
        UPPERSymptoms = _NPC.GetComponent<_PeopleIssues>().getSymptoms();
        ParticleHelper(UPPERSymptoms);
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

    public void SaveStateToNextLevel()
    {
         PlayerPrefs.SetInt("AlivePeople", Population);
         PlayerPrefs.SetInt("InfectedPeople", _infectedAndDeadCounter.getInfected());
    }

    public int LoadPeopleState()
    {
        return PlayerPrefs.GetInt("AlivePeople");
    }

    public void SetNPCcount(int C)
    {
        Debug.Log("drop");
        PlayerPrefs.SetInt("PEOPLE", C);
    }

    public void SaveCommonState()
    {
        PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);
        SavePeopleState();
    }

    private void MaybeIDie(int infection)
    {
        int defense = PlayerPrefs.GetInt(_ResourceKeys.Defense) + DefenseEquipmentsHelper.GetEqupmentDefense();
        int _defaultProtection = (int) (infection * (0.3 + defense/100));
        int rate = infection - _defaultProtection;
        int Chance = Random.Range(1, 101);

        Debug.Log(rate);

        if (Chance <= rate)
        {
            if(PlayerPrefs.GetInt(_ResourceKeys.TheFirstLevel) == 0)
                PlayerPrefs.SetInt(_ResourceKeys.Неудачник, 1);
            PlayerPrefs.SetInt(_ResourceKeys.OurDeath, 1);
        }
    }

    public void ParticleHelper(List<string> sympt)
    {
        if (sympt.Count <= 0 || sympt == null)
        {
            Particles[0].SetActive(false);
            Particles[1].SetActive(false);
            Particles[2].SetActive(false);
        }
        else
        {
            foreach (var s in sympt)
            {
                if (s.Equals("Рвота") || s.Equals("Тошнота"))
                {
                    Particles[0].SetActive(false);
                    Particles[1].SetActive(true);
                    Particles[2].SetActive(false);
                    break;
                }

                if (s.Equals("Кашель") || s.Equals("Длительный кашель") || s.Equals("Лающий кашель"))
                {
                    Particles[0].SetActive(true);
                    Particles[1].SetActive(false);
                    Particles[2].SetActive(false);
                    break;
                }

                if (s.Equals("Температура"))
                {
                    Particles[0].SetActive(false);
                    Particles[1].SetActive(false);
                    Particles[2].SetActive(true);
                    break;
                }

                Particles[0].SetActive(false);
                Particles[1].SetActive(false);
                Particles[2].SetActive(false);
            }
        }
    }

    private void TurnOffParticles()
    {
        Particles[0].SetActive(false);
        Particles[1].SetActive(false);
        Particles[2].SetActive(false);
    }

    private void LevelClearedHelper()
    {
        int inx = SceneManager.GetActiveScene().buildIndex;

        switch (inx)
        {
            case 3: PlayerPrefs.SetInt("clrd_lvl_1", 1); break;
            case 4: PlayerPrefs.SetInt("clrd_lvl_2", 1); break;
            case 5: PlayerPrefs.SetInt("clrd_lvl_3", 1); break;
            case 6: PlayerPrefs.SetInt("clrd_lvl_4", 1); break;
            case 7: PlayerPrefs.SetInt("clrd_lvl_5", 1); break;
            case 8: PlayerPrefs.SetInt("clrd_lvl_6", 1); break;
            case 9: PlayerPrefs.SetInt("clrd_lvl_7", 1); break;
        }
    }

    public void changeTextPopulation(int current, int to, bool operation)
    {
        AT.ANIMATEDTEXT(alivePeople.GetComponent<TextMeshProUGUI>(), current, to, operation);
    }
    private void changeTextInfetced(int current, int to, bool operation)
    {
        AT.ANIMATEDTEXT(infectedPeople.GetComponent<TextMeshProUGUI>(), current, to, operation);
    }
}