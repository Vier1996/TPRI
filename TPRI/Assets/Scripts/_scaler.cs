using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _scaler : MonoBehaviour
{
    [SerializeField] public float _Scale = 1;
    void Start()
    {
        transform.localScale = new Vector3(_Scale, _Scale, _Scale);
    }
    
}
