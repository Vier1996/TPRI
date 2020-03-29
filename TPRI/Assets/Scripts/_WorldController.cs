using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _WorldController : MonoBehaviour
{
    private int _numPassingIllnesses;
    private int _numPassingSymptoms;
    private List<string> _listPassingIllnesses;

    private void Awake()
    {
        _numPassingIllnesses = 0;
        _listPassingIllnesses = new List<string>();
        _numPassingSymptoms = 0;
    }

    public void setPassingIllnesses(int count, string illness, int countSymptoms)
    {
        _numPassingIllnesses = count;
        _numPassingSymptoms = countSymptoms;
        _listPassingIllnesses.Add(illness);
        Debug.Log("Count symptoms: " + _numPassingSymptoms + "\nCount illnesses: " + _numPassingIllnesses);
        Debug.Log("Illnesses: " + illness);
    }
}
