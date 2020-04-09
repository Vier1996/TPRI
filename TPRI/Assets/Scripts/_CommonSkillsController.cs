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
        
        _passiveBack.SetActive(false);
        _active.interactable = false;
        _passive.interactable = true;

        _active.onClick.AddListener(SetupActiveSkillsMenu);
        _passive.onClick.AddListener(SetupPassiveSkillsMenu);
    }

    private void SetupActiveSkillsMenu()
    {
        _active.interactable = false;
        _passive.interactable = true;
        
        _passiveBack.SetActive(false);
        _activeBack.SetActive(true);
    }
    
    private void SetupPassiveSkillsMenu()
    {
        _active.interactable = true;
        _passive.interactable = false;
        
        _activeBack.SetActive(false);
        _passiveBack.SetActive(true);
    }
}
