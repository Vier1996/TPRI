using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _osvistController : MonoBehaviour
{
    [SerializeField] private Button shoot;
    [SerializeField] private AudioSource osvist;

    private void Start()
    {
        shoot.onClick.AddListener(() =>
        {
            osvist.Play();
            Invoke(nameof(stopOsvist), 2.3f);
        });
    }

    private void stopOsvist()
    {
        osvist.Stop();
    }
}
