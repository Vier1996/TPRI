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
    void Start()
    {
        toBestiarii.onClick.AddListener(() => { SceneManager.LoadScene("_bestiariy"); });
        toBack.onClick.AddListener(() =>
        {
            Destroy(_CurrentPage);
            if (CurrentPage == 0)
            {
                CurrentPage = pages.Length - 1;
                _CurrentPage = Instantiate(pages[CurrentPage], transform);
            }
            else
            {
                _CurrentPage = Instantiate(pages[--CurrentPage], transform);
            }
        });
        toNext.onClick.AddListener(() =>
        {
            Destroy(_CurrentPage);
            if (CurrentPage == pages.Length - 1)
            {
                CurrentPage = 0;
                _CurrentPage = Instantiate(pages[CurrentPage], transform);
            }
            else
            {
                _CurrentPage = Instantiate(pages[++CurrentPage], transform);
            }
        });
        
        _CurrentPage = Instantiate(pages[0], transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
