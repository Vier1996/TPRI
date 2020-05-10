using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _miniBestiarii : MonoBehaviour
{
    [SerializeField] private _GameController _game;
    
    [SerializeField] private GameObject[] pages;
    [SerializeField] private Button toBestiarii;
    [SerializeField] private Button toBack;
    [SerializeField] private Button toNext;
    
    [SerializeField] private AudioSource bookLeaf;

    private GameObject _CurrentPage;
    private int CurrentPage = 0;
    private GameObject _modelVirus;
    private GameObject _modelForLoadVirus;
    private const float ModelX = 12.5f, ModelY = 2.48f, ModelZ = 80.75f;

    void Start()
    {
        toBestiarii.onClick.AddListener(() =>
        {
          _game.SavePeopleState();
          PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);
          SceneManager.LoadScene("_bestiariy");
          PlayerPrefs.SetInt("BesiariiCome", 1);
          PlayerPrefs.SetInt("GCBesiariiCome", 1);
        });
        toBack.onClick.AddListener(() =>
        {
            Destroy(_CurrentPage);
            Destroy(_modelVirus);
            if (CurrentPage == 0)
            {
                CurrentPage = pages.Length - 1;
                _CurrentPage = Instantiate(pages[CurrentPage], transform);
                InstantiateModelVirus(CurrentPage);
            }
            else
            {
                _CurrentPage = Instantiate(pages[--CurrentPage], transform);
                InstantiateModelVirus(CurrentPage);
            }
            bookLeaf.Play();
            Invoke(nameof(Stopper), 1f);
        });
        toNext.onClick.AddListener(() =>
        {
            Destroy(_CurrentPage);
            Destroy(_modelVirus);
            if (CurrentPage == pages.Length - 1)
            {
                CurrentPage = 0;
                _CurrentPage = Instantiate(pages[CurrentPage], transform);
                InstantiateModelVirus(CurrentPage);
            }
            else
            {
                _CurrentPage = Instantiate(pages[++CurrentPage], transform);
                InstantiateModelVirus(CurrentPage);
            }
            bookLeaf.Play();
            Invoke(nameof(Stopper), 1f);
        });
        
        _CurrentPage = Instantiate(pages[0], transform);
        _modelForLoadVirus = Resources.Load<GameObject>("3dPrefabs/ВирусыСматериалами/Вирус1");
        _modelVirus = Instantiate(_modelForLoadVirus);
        _modelVirus.transform.position = new Vector3(ModelX, ModelY, ModelZ);
        _modelVirus.GetComponent<_scaler>()._Scale = 1.5f;
    }

    private void Stopper()
    {
        bookLeaf.Stop();
    }

    private void InstantiateModelVirus(int index)
    {
        _modelForLoadVirus = Resources.Load<GameObject>("3dPrefabs/ВирусыСматериалами/Вирус" + (index+1));
        _modelVirus = Instantiate(_modelForLoadVirus);
        _modelVirus.transform.position = new Vector3(ModelX, ModelY, ModelZ);
        if (index + 1 == 3)
        {
            _modelVirus.GetComponent<_scaler>()._Scale = 0.3f;
        }
        if (index + 1 == 5 || index + 1 == 6)
        {
            _modelVirus.GetComponent<_scaler>()._Scale = 5.43f;
        }
        if (index + 1 == 2)
        {
            _modelVirus.GetComponent<_scaler>()._Scale = 1.3f;
        }
    }
    
    void Update()
    {
        if (_modelVirus != null)
        {
            _modelVirus.transform.Rotate(10.0f * Time.deltaTime, 10.0f * Time.deltaTime, 0);
        }
    }
}
