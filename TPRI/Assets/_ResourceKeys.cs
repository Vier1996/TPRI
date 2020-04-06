using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ResourceKeys : MonoBehaviour
{
    private static _ResourceKeys instance;
    
    public const string CharacterLevel = "CharacterLevel";
    public const string Town_HealthPeople = "Town_HealthPeople";

    private const string R1 = "";
    private const string R2 = "";
    private const string R3 = "";
    private const string R4 = "";
    private const string R5 = "";
    
    private const string R6 = "";
    private const string R7 = "";
    private const string R8 = "";
    private const string R9 = "";
    private const string R10 = "";
    
    private const string R11 = "";
    private const string R12 = "";
    private const string R13 = "";
    private const string R14 = "";
    private const string R15 = "";
    
    private void Awake()
    {
        PlayerPrefs.SetInt(CharacterLevel, 1);
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
