using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

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
       
    }

    public void PsholVon(bool anim)
    {
      dodiki[lenght].GetComponent<_queueController>().GoodBye(anim);
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

    public void adaptation(int SIZE)
    {
        Time.timeScale = 3;
        if (SIZE > 0)
        {
            int Nlength = lenght;
            for (int i = 0; i < SIZE; i++)
            {
                dodiki[Nlength].GetComponent<Image>().color = new Color(0, 0, 0, 0);
                PsholVon(false);
                Nlength--;
            }
        }
        Time.timeScale = 1;
    }
}
