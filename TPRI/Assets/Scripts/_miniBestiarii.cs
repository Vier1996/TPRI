using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _miniBestiarii : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    [SerializeField] private Button toBestiarii;
    [SerializeField] private Button toBack;
    [SerializeField] private Button toNext;

    private GameObject _CurrentPage;
    private int CurrentPage = 0;
    private GameObject _modelVirus;
    private GameObject _modelForLoadVirus;
    private const float ModelX = 12.5f, ModelY = 2.9f, ModelZ = 80.75f;

    void Start()
    {
        toBestiarii.onClick.AddListener(() => { SceneManager.LoadScene("_bestiariy"); });
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
        });
        
        _CurrentPage = Instantiate(pages[0], transform);
        _modelForLoadVirus = Resources.Load<GameObject>("3dPrefabs/Вирус1");
        _modelVirus = Instantiate(_modelForLoadVirus);
        _modelVirus.transform.position = new Vector3(ModelX, ModelY, ModelZ);
        _modelVirus.GetComponent<_scaler>()._Scale = 1.5f;
    }

    private void InstantiateModelVirus(int index)
    {
        _modelForLoadVirus = Resources.Load<GameObject>("3dPrefabs/Вирус" + (index+1));
        _modelVirus = Instantiate(_modelForLoadVirus);
        _modelVirus.transform.position = new Vector3(ModelX, ModelY, ModelZ);
        if (index + 1 == 3)
        {
            _modelVirus.GetComponent<_scaler>()._Scale = 0.3f;
        }
        else
        {
            _modelVirus.GetComponent<_scaler>()._Scale = 1.5f;
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_modelVirus != null)
        {
            _modelVirus.transform.Rotate(10.0f * Time.deltaTime, 10.0f * Time.deltaTime, 0);
        }
    }
}
