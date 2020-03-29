using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _contextUPGR : MonoBehaviour
{
   [SerializeField] public string Path;
   private void Awake()
   {
      PlayerPrefs.SetString(Path + 2, "No");
      PlayerPrefs.SetString(Path + 3, "No");
   }
}
