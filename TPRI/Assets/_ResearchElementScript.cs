using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _ResearchElementScript : MonoBehaviour
{
    [SerializeField] private int Koef;
    [SerializeField] private TextMeshProUGUI amount;
    public int IntegerAmount;

    void Start()
    {
        IntegerAmount = PlayerPrefs.GetInt(_ResourceKeys.CharacterLevel) + Koef;
        amount.text = IntegerAmount.ToString();
        
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (!amount.text.Equals("0"))
            {
                Invoke(nameof(Decrement), 0.05f);
            }
        });
    }

    private void Decrement()
    {
        amount.text = (--IntegerAmount).ToString();
    }

}
