using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class _upgradeController : MonoBehaviour
{
    [SerializeField] public string Path;
    [SerializeField] Button Upgrade1;
    [SerializeField] Button Upgrade2;
    [SerializeField] Button Upgrade3;

    private bool UPGG2 = false;
    private bool UPGG3 = false;

    private void Awake()
    {
        if (PlayerPrefs.GetString(Path + 2) == "Yes")
        {
            UPGG2 = true;
        }
        if (PlayerPrefs.GetString(Path + 3) == "Yes")
        {
            UPGG3 = true;
        }
        
        if(!UPGG2) Upgrade2.GetComponent<Image>().color = Color.gray;
        if(!UPGG3) Upgrade3.GetComponent<Image>().color = Color.gray;
    }

   
    private void Start()
    {
        Upgrade1.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt(Path, 1);
            Debug.Log(Path + ": upgrade - " + 1);
        });
        Upgrade2.onClick.AddListener(() =>
        {
            if (UPGG2)
            {
                PlayerPrefs.SetInt(Path, 2);
                Debug.Log(Path + ": upgrade - " + 2);
            }
            else
            {
                Sequence s = DOTween.Sequence();

                s.Append(Upgrade2.GetComponent<Image>().DOColor(Color.red, 1))
                    .OnComplete(() =>
                    {
                        Upgrade2.GetComponent<Image>().DOColor(Color.gray, 1);
                    });

            }
        });
        Upgrade3.onClick.AddListener(() =>
        {
            if (UPGG3)
            {
                PlayerPrefs.SetInt(Path, 3);
                Debug.Log(Path + ": upgrade - " + 3);
            }
            else
            {
                Sequence s = DOTween.Sequence();

                s.Append(Upgrade3.GetComponent<Image>().DOColor(Color.red, 1))
                    .OnComplete(() =>
                    {
                        Upgrade3.GetComponent<Image>().DOColor(Color.gray, 1);
                    });

            }
        });
    }
}
