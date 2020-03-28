using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _dialogContainer : MonoBehaviour
{
    protected string[] BaseDialogs = new string[30];
    protected string[] WhereDialogs = new string[30];
    protected string[] ProblemsDialogs = new string[30];
    protected string[] VisitDialogs = new string[30];
    void Awake()
    {
        BaseDialogs[0] = "Привет. Меня зовут Саня, я в порядке!";
        WhereDialogs[0] = "С пушкарей.";
        ProblemsDialogs[0] = "Временами не в порядке.";
        VisitDialogs[0] = "Ну это... да, ну ты понял.";
    }

  
}
