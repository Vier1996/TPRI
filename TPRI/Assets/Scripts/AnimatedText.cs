using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimatedText : MonoBehaviour
{
    private const float time = 0.5f; 
    public int outInt = 0;
    private bool _finish = false;

    public void ANIMATEDTEXT(TextMeshProUGUI text, int current, int to, bool adding)
    {
        outInt = current;

        StartCoroutine(changeText(text, outInt, to, adding));
        
        while (!_finish)
        {
            
        }
        
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

        if (current == to)
            _finish = true;
    }

    private void Drop()
    {
        outInt = 0;
        _finish = false;
    }
}
