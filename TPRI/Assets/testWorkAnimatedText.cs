using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class testWorkAnimatedText : MonoBehaviour
{
    [SerializeField] private AnimatedText AT;
    private TextMeshProUGUI test;
    void Start()
    {
        test = GetComponent<TextMeshProUGUI>();
        
        AT.ANIMATEDTEXT(test, 999, 666, false);
    }
    
    void Update()
    {
        
    }
}
