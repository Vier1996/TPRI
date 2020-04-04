using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _skillContext : MonoBehaviour
{
   private void Awake()
   {
      PlayerPrefs.SetInt("1_skl", 0);
      PlayerPrefs.SetInt("2_skl", 0);
      PlayerPrefs.SetInt("3_skl", 0);
      PlayerPrefs.SetInt("4_skl", 0);
      PlayerPrefs.SetInt("5_skl", 0);
      PlayerPrefs.SetInt("6_skl", 0);
      PlayerPrefs.SetInt("7_skl", 0);
      PlayerPrefs.SetInt("8_skl", 0);
      PlayerPrefs.SetInt("9_skl", 0);
   }
}
