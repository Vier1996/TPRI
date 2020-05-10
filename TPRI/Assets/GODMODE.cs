using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GODMODE : MonoBehaviour
{
   
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(_DropProgress.GodMode);
    }
    
}
