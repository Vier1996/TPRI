using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class _queuePeopleController : MonoBehaviour
{
    public Animation _institiate;

    void Start()
    {
        _institiate.Play("PeopleStart");
    }

    public void Run()
    {
        transform.DOMove(GameObject.Find("exit").transform.position, 4f);
    }
}
