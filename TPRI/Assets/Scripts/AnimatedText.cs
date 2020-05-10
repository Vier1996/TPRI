using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimatedText : MonoBehaviour
{
    private const float time = 0.005f; 
    public int outInt = 0;
    private bool _finish = false;

    public void ANIMATEDTEXT(TextMeshProUGUI text, int current, int to, bool adding)
    {
        outInt = current;
        
        StartCoroutine(changeText(text, outInt, to, adding));
        Drop();
        //StopCoroutine(changeText(0, 0, true));
    }

    IEnumerator changeText(TextMeshProUGUI text, int current, int to, bool adding)
    {
        if (!adding)
        {
            while (current != to)
            {
                yield return new WaitForSeconds(time);
                current--;
                text.text = current.ToString();
            }
        }
        else
        {
            while (current != to)
            {
                yield return new WaitForSeconds(time);
                current++;
                text.text = current.ToString();
            }
        }
    }
    

    private void Drop()
    {
        outInt = 0;
        _finish = false;
    }
}
