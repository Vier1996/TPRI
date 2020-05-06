using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class __bestiariiEventController : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.насморк) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.головная_боль) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.першение_в_горле) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.простуда, 1);
        }
        
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.зуд) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.сыпь) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.чесотка, 1);
        }

        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.головная_боль) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.боль_в_глазах) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.тошнота) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.рвота) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.боль_в_ушах) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.мигрень, 1);
        }

        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.боль_в_животе) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.изжога) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.тошнота) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.гастрит, 1);
        }
        
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.тошнота) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.изжога) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.горечь_во_рту) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.слабость) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.температура) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.гепатит, 1);
        }
        
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.температура) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.кашель) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.утомаляемость) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.боль_в_теле) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.грипп, 1);
        }
        
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.слабость) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.длительный_кашель) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.температура) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.тубиркулез, 1);
        }
        
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.слабость) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.температура) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.характерная_сыпь) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.корь, 1);
        }
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.лающий_кашель) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.температура) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.слабость) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.бронхит, 1);
        }
        
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.сильная_боль_в_животе) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.изжога) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.голодные_боли_в_животе) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.слабость) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.язва, 1);
        }
        
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.температура) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.сильная_головная_боль) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.тошнота) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.рвота) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.менингит, 1);
        }
        
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.отсутсвие_обоняния) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.кашель) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.температура) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.боль_в_горле) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.сильная_слабость) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.коронавирус, 1);
        }
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.кашель) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.температура) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.слабость) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.пневмония, 1);
        }
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.боль_в_животе) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.тошнота) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.рвота) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.потеря_веса) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.отсутсвие_аппетита) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.рак, 1);
        }
        if (PlayerPrefs.GetInt(_SYMPTOMESKEY.слабость) == 1 && 
            PlayerPrefs.GetInt(_SYMPTOMESKEY.головная_боль) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.кровоточивость_десен) == 1 &&
            PlayerPrefs.GetInt(_SYMPTOMESKEY.выпадение_зубов) == 1)
        {
            PlayerPrefs.SetInt(_ISSUESKEY.цинга, 1);
        }
    }
}
