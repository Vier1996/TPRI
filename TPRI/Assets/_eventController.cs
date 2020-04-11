using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _eventController : MonoBehaviour
{
   public int OurDefense;

   private void Start()
   {
      Debug.Log(PlayerPrefs.GetInt(_ResourceKeys.Defense));
   }
}
