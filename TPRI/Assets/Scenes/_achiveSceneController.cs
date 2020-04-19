using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _achiveSceneController : MonoBehaviour
{
    [SerializeField] private Button back;

    private void Start()
    {
        back.onClick.AddListener(() => { SceneManager.LoadScene("_home"); });
    }
}
