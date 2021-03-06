﻿using System;
using System.Collections;
using System.Collections.Generic;
using Bestiary;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _queueController : MonoBehaviour
{
    [SerializeField] private Transform underDoor;
    [SerializeField] private Transform Exit;
    [SerializeField] private Animation door;
    [SerializeField] private GameObject ourPeople;
    [SerializeField] private string nameGameObjectPatient;
    private GameObject npc;
    private string issue;
    
    
    void Start()
    {
        InfoAboutIlnesses info = new InfoAboutIlnesses();
        int numOfSymptoms = info.getSymptoms()[ourPeople.GetComponent<_PeopleIssues>()._issueName].Count;
        //npc = GameObject.FindWithTag("Player");

        string issue = _IssuesPeopleAccordingScene
            .getIssue(Convert.ToInt32(gameObject.name), SceneManager.GetActiveScene().name);

        if (PlayerPrefs.GetInt("10_skl") == 1 && !issue.Equals("HEALTHY"))
        {
            GetComponent<Image>().color = Color.red;
        }
    }
    
    public void GoodBye(bool anim)
    {
        transform.DOMove(underDoor.position, 2f).OnComplete(() =>
        {
            if(anim)
                door.Play();
            Invoke(nameof(RealyGoodBye), 1.5f);
        });
    }

    private void RealyGoodBye()
    {
        transform.DOMove(Exit.position, 2f).OnComplete(() =>
        {
           // Destroy(gameObject);
        });
    }

    private void Update()
    {
        try
        {
            npc = GameObject.Find(nameGameObjectPatient);
            if (npc != null)
            {
                if (npc.GetComponent<_PeopleIssues>().getSymptoms().Count == 0)
                {
                    GetComponent<Image>().color = Color.white;
                }
            }
        }
        catch(NullReferenceException) {}
    }
}
