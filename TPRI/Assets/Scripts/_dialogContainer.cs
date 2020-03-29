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
       BaseDiaolgsInitial();
       WhereDiaolgsInitial();
       ProblemsDiaolgsInitial();
       VisitDiaolgsInitial();
    }
    private void BaseDiaolgsInitial() {
        BaseDialogs[0] = "Привет. Меня зовут Саня, я в порядке!";
        BaseDialogs[1] = "...";
        BaseDialogs[2] = "Здравствуйте! ";
        
    }
    private void WhereDiaolgsInitial() {
        WhereDialogs[0] = "С пушкарей.";
        WhereDialogs[1] = "...";
        WhereDialogs[2] = "С шираги.";
       
    }
    private void ProblemsDiaolgsInitial() {
        ProblemsDialogs[0] = "Временами не в порядке.";
        ProblemsDialogs[1] = "...";
        ProblemsDialogs[2] = "";
        
    }
    private void VisitDiaolgsInitial() {
        VisitDialogs[0] = "Ну это... да, ну ты понял.";
        VisitDialogs[1] = "...";
        VisitDialogs[2] = "";
        
    }

  
}
