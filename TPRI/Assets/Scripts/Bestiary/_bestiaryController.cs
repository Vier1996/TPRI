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

    private void Awake()
    {
        _contentContainerForViruses = GameObject.Find("ListContent").GetComponent<Image>();
        //_viruses = new GameObject[_contentContainer.transform.childCount];
        _viruses = new List<GameObject>();
        _storyVirus = GameObject.Find("StroyOfVirus");
        _symptoms = GameObject.Find("Symptoms");
        
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
        
        backToMenu.onClick.AddListener(() => { SceneManager.LoadScene("_level_1");});
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
        _virusModelGameObject = GameObject.FindWithTag("VirusModel");
        _nameVirus = GameObject.Find("NameVirus");
        if (_virusModelGameObject != null)
        {
            Destroy(_virusModelGameObject);
        }

        _virusModel = Resources.Load<GameObject>("3dPrefabs/Вирус" + position);
        if (_virusModel != null)
        {
            _virusModelGameObject = Instantiate(_virusModel);
        }

        //VirusInformaiton = _virusModelGameObject.GetComponent<Information>();
        
        string nameVirus = _viruses[position-1].GetComponent<TextMeshProUGUI>().text;
        _storyVirus.GetComponent<TextMeshProUGUI>().text = _info.getViruses()[nameVirus];
        _symptoms.GetComponent<TextMeshProUGUI>().text = "Симптомы:\n" + getSymptoms(_info.getSymptoms()[nameVirus]);
        _nameVirus.GetComponent<TextMeshProUGUI>().text = nameVirus;
        _infectionDegreeSlider.GetComponent<Slider>().value = _info.getValueInfection()[nameVirus];
        _fatalityDegreeSlider.GetComponent<Slider>().value = _info.getValueFatality()[nameVirus];
    }

    private string getSymptoms(List<string> symptoms)
    {
        string symptom = "";
        for (int i = 0; i < symptoms.Count; i++)
        {
            
            symptom += symptoms[i] + "\n";
        }

        return symptom;
    }

    public List<string> getSymptomsByNameIllness(String name)
    {
        return _listSymptoms[name];
    }
}