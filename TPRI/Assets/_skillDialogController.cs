using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _skillDialogController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Descritption;
    [SerializeField] private Button Get;

    public void setName(string _Name)
    {
        Name.text = _Name;
    }

    public string GetName()
    {
        return Name.text;
    }

    public void setDescription(string _Desc)
    {
        Descritption.text = _Desc;
    }

    public Button GetButton()
    {
        return Get;
    }
}
