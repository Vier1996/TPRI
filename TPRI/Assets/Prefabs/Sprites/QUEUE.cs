using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QUEUE : MonoBehaviour
{
    public GameObject[] dodiki;
    public Transform[] dodikiPos;
    [SerializeField] private int lenght;

    private Vector3[] BLYA;
    
    public QUEUE(Transform[] dodikiPos, Vector3[] blya)
    {
        this.dodikiPos = dodikiPos;
        BLYA = blya;
    }

    private void Start()
    {
        lenght--;
        //Recycle();
    }

    public void PsholVon()
    {
      dodiki[lenght].GetComponent<_queueController>().GoodBye();
      lenght--;
      //Invoke(nameof(QueueMovement), 5f);
    }

    private void QueueMovement()
    {
        lenght--;
        for (int i = lenght; i >= 0; i--)
        {
            dodiki[i].GetComponent<Transform>().transform.DOMove(BLYA[i + 1], 1.5f);
        }
        
        Recycle();
    }

    private void Recycle()
    {
        for (int i = 0; i <= lenght; i++)
        {
            BLYA[i] = dodikiPos[i].position;
        }
    }
}
