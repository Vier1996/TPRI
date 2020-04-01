using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class _bestiaryController : MonoBehaviour
{
    //private GameObject[] _viruses;
    private List<GameObject> _viruses;
    private GameObject _storyVirus, _symptoms;
    private Image _contentContainerForViruses;
    private Dictionary<string, string> _listViruses;
    private Dictionary<string, List<string>> _listSymptoms;
    private GameObject _virusModel;

    private void Awake()
    {

        _contentContainerForViruses = GameObject.Find("ListContent").GetComponent<Image>();
        //_viruses = new GameObject[_contentContainer.transform.childCount];
        _viruses = new List<GameObject>();
        _storyVirus = GameObject.Find("StroyOfVirus");
        _symptoms = GameObject.Find("Symptoms");

        setViruses();
        setSymptoms();
        for (int i = 0; i < _contentContainerForViruses.transform.childCount; i++)
        {
            _viruses.Add(GameObject.Find("Virus" + (i+1)));
        }

        for (int i = 0; i < _viruses.Count; i++)
        {
            var i1 = i;
            _viruses[i].GetComponent<Button>().onClick.AddListener(()=>getInfoAboutVirus(i1));
        }

        _virusModel = GameObject.Find("Вирус2");

    }

    private void Update()
    {
        _virusModel.transform.Rotate(10.0f*Time.deltaTime, 10.0f*Time.deltaTime,0);
    }

    private void setViruses()
    {
        _listViruses = new Dictionary<string, string>();
        _listViruses.Add("1", "Some usefull information 1");
        _listViruses.Add("2", "Some usefull information 2");
        _listViruses.Add("3", "Some usefull information 3");
        _listViruses.Add("4", "Some usefull information 4");
        _listViruses.Add("5", "Some usefull information 5");
        _listViruses.Add("6", "Some usefull information 6");
        _listViruses.Add("7", "Some usefull information 7");
        _listViruses.Add("8", "Some usefull information 8");
        _listViruses.Add("9", "Some usefull information 9");
        _listViruses.Add("10", "Some usefull information 10");
        _listViruses.Add("11", "Some usefull information 11");
        _listViruses.Add("12", "Some usefull information 12");
        _listViruses.Add("13", "Some usefull information 13");
        _listViruses.Add("14", "Some usefull information 14");
        _listViruses.Add("15", "Some usefull information 15");
    }

    private void setSymptoms()
    {
        _listSymptoms = new Dictionary<string, List<string>>();
        _listSymptoms.Add("1", new List<string>(){"1: First", "1: Second"});
        _listSymptoms.Add("2", new List<string>(){"2: First", "2: Second"});
        _listSymptoms.Add("3", new List<string>(){"3: First", "3: Second"});
        _listSymptoms.Add("4", new List<string>(){"4: First", "4: Second"});
        _listSymptoms.Add("5", new List<string>(){"5: First", "5: Second"});
        _listSymptoms.Add("6", new List<string>(){"6: First", "6: Second"});
        _listSymptoms.Add("7", new List<string>(){"7: First", "7: Second"});
        _listSymptoms.Add("8", new List<string>(){"8: First", "8: Second"});
        _listSymptoms.Add("9", new List<string>(){"9: First", "9: Second"});
        _listSymptoms.Add("10", new List<string>(){"10: First", "10: Second"});
        _listSymptoms.Add("11", new List<string>(){"11: First", "11: Second"});
        _listSymptoms.Add("12", new List<string>(){"12: First", "12: Second"});
        _listSymptoms.Add("13", new List<string>(){"13: First", "13: Second"});
        _listSymptoms.Add("14", new List<string>(){"14: First", "14: Second"});
        _listSymptoms.Add("15", new List<string>(){"15: First", "15: Second"});
    }
    
    
    private void getInfoAboutVirus(int position)
    {
        string nameVirus = _viruses[position].GetComponent<TextMeshProUGUI>().text;
        string story = _listViruses[nameVirus];
        List<string> symptoms = _listSymptoms[nameVirus];
        string symptomsToString = getSymptoms(symptoms);
        _storyVirus.GetComponent<TextMeshProUGUI>().text = story;
        _symptoms.GetComponent<TextMeshProUGUI>().text = symptomsToString;
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
}
