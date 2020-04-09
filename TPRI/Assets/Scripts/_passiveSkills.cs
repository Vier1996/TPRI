using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _passiveSkills : MonoBehaviour
{
    [SerializeField] private GameObject Layout2;
    [SerializeField] private GameObject Layout3;
    
    [SerializeField] private GameObject Layout5;
    
    
    private void Start()
    {
        Layout2.SetActive(false);
        Layout3.SetActive(false);

        Layout5.SetActive(false);
    }

    private void Update()
    {
        SkillCheker();
    }

    private void SkillCheker()
    {
        if (PlayerPrefs.GetInt("pass_1_skl") == 1)
        {
            Layout2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("pass_2_skl") == 1)
        {
            Layout3.SetActive(true);
        }
        if (PlayerPrefs.GetInt("pass_4_skl") == 1)
        {
            Layout5.SetActive(true);
        }
        
    }
}
