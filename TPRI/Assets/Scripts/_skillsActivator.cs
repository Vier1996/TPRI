using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class _skillsActivator : MonoBehaviour
{
    [SerializeField] private GameObject _skill_Detection;
    [SerializeField] private TextMeshProUGUI symptom;

    private void Awake()
    {
        _skill_Detection.SetActive(false);
    }

    public void SkillDetection(string symptom)
    {
        if (PlayerPrefs.GetInt("3_skl") != 0)
        {

            int Rate = Random.Range(0, 101);
            if (Rate <= 10)
            {
                this.symptom.text = symptom;
                _skill_Detection.SetActive(true);
            }

            Invoke(nameof(SkillDetectionDeactivated), 2f);
        }
    }

    private void SkillDetectionDeactivated()
    {
        _skill_Detection.SetActive(false);
    }
}