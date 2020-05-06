using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bestiary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class _bestiaryController : MonoBehaviour
{
    private List<GameObject> _viruses;
    private GameObject _storyVirus, _symptoms;
    private Image _contentContainerForViruses;
    private Dictionary<string, string> _listViruses;
    private Dictionary<string, List<string>> _listSymptoms;
    private Dictionary<string, int> _valueOfInfection;
    private GameObject _virusModel;
    private GameObject _virusModelGameObject;
    private GameObject _infectionDegreeSlider, _fatalityDegreeSlider;
    private GameObject _nameVirus;
    private InfoAboutIlnesses _info;

    private Information VirusInformaiton;
    [SerializeField] private Button backToMenu;
    
    [SerializeField] private Animation leaf;
    [SerializeField] private AudioSource _leaf;

    private void Awake()
    {
        _contentContainerForViruses = GameObject.Find("ListContent").GetComponent<Image>();
        //_viruses = new GameObject[_contentContainer.transform.childCount];
        _viruses = new List<GameObject>();
        _storyVirus = GameObject.Find("StroyOfVirus");
        _symptoms = GameObject.Find("Symptoms");
        _nameVirus = GameObject.Find("NameVirus");
        
        _info = new InfoAboutIlnesses();
        /*_listViruses = _info.getViruses();
        _listSymptoms = _info.getSymptoms();
        _valueOfInfection = _info.getValueInfection();*/
        for (int i = 0; i < _contentContainerForViruses.transform.childCount; i++)
        {
            _viruses.Add(GameObject.Find("Virus" + (i + 1)));
        }

        for (int i = 0; i < _viruses.Count; i++)
        {
            var i1 = i+1;
            _viruses[i].GetComponent<Button>().onClick.AddListener(() => getInfoAboutVirus(i1));
        }

        _infectionDegreeSlider = GameObject.Find("degreeOfInfection");
        _fatalityDegreeSlider = GameObject.Find("degreeOfFatality");
        
        backToMenu.onClick.AddListener(() => { SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel")); });
    }

    private void Start()
    {
        string name;
        bool check = false;
        for (int i = 0; i < _viruses.Count; i++)
        {
            name = _info.getNameOfVirus(i).ToLower();
            if (PlayerPrefs.GetInt("Key_" + name) == 1)
            {
                checkOpenIssues(i);
            }
            else
            {
                check = true;
            }
        }

        if (!check)
        {
            PlayerPrefs.SetInt(_ResourceKeys.Всезнайка, 1);
        }
    }

    private void Update()
    {
        if (_virusModelGameObject != null)
        {
            _virusModelGameObject.transform.Rotate(10.0f * Time.deltaTime, 10.0f * Time.deltaTime, 0);
        }
    }

    

    private void getInfoAboutVirus(int position)
    {
        string name = _viruses[position - 1].GetComponent<TextMeshProUGUI>().text;
        string nameSomeVirus = _info.getNameOfVirus(position - 1);
        _virusModelGameObject = GameObject.FindWithTag("VirusModel");
        if (_virusModelGameObject != null)
        {
            Destroy(_virusModelGameObject);
        }
        if (name.Equals(nameSomeVirus))
        {
            setOpenIssues(position);
        }
        else
        {
            setClosedIssues(nameSomeVirus);
        }
        _leaf.Play();
        Invoke(nameof(Stopper), 1f);
        
        leaf.Play();
    }
    
    private void Stopper()
    {
        _leaf.Stop();
    }

    private void setClosedIssues(string name)
    {
        _nameVirus.GetComponent<TextMeshProUGUI>().text = "???";
        _infectionDegreeSlider.GetComponent<Slider>().value = 0;
        _fatalityDegreeSlider.GetComponent<Slider>().value = 0;
        _storyVirus.GetComponent<TextMeshProUGUI>().text = "Информация о вирусе будет доступа после его открытия!";
        _symptoms.GetComponent<TextMeshProUGUI>().text = _symptoms.GetComponent<TextMeshProUGUI>().text =
            "Симптомы:\n" + getSymptoms(_info.getSymptoms()[name]);
    }

    private void setOpenIssues(int position)
    {
        _virusModel = Resources.Load<GameObject>("3dPrefabs/ВирусыСматериалами/Вирус" + position);
        if (_virusModel != null)
        {
            _virusModelGameObject = Instantiate(_virusModel);
        }

        string name = _info.getNameOfVirus(position - 1);
        _storyVirus.GetComponent<TextMeshProUGUI>().text = _info.getViruses()[name];
        _symptoms.GetComponent<TextMeshProUGUI>().text =
            "Симптомы:\n" + getSymptoms(_info.getSymptoms()[name]);
        _nameVirus.GetComponent<TextMeshProUGUI>().text = name;
        _infectionDegreeSlider.GetComponent<Slider>().value = _info.getValueInfection()[name];
        _fatalityDegreeSlider.GetComponent<Slider>().value = _info.getValueFatality()[name];
    }

    private string getSymptoms(List<string> symptoms)
    {
        string symptom = "";
        for (int i = 0; i < symptoms.Count; i++)
        {
            if (PlayerPrefs.GetInt("Key_" + symptoms[i]) == 1)
            {
                symptom += symptoms[i] + "\n";
            }
            else
            {
                symptom += "???\n";
            }
        }

        return symptom;
    }

    private void checkOpenIssues(int position)
    {
        _viruses[position].GetComponent<TextMeshProUGUI>().text = _info.getNameOfVirus(position);
    }
}