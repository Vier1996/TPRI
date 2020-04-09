using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _CommonSkillsController : MonoBehaviour
{
    [SerializeField] private Button _active;
    [SerializeField] private Button _passive;
    [SerializeField] private GameObject _activeBack;
    [SerializeField] private GameObject _passiveBack;

    private void Start() {
        
        _active.onClick.AddListener(() =>
        {
            
        });
    }

    private void SetupActiveSkillsMenu()
    {
        
        _activeBack.SetActive(true);
    }
    
    private void SetupPassiveSkillsMenu()
    {
        
    }
}
