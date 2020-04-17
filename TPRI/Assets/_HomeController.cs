using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _HomeController : MonoBehaviour
{
   [SerializeField] private Button _store;
   [SerializeField] private Button _skills;
   [SerializeField] private Button _eqiepments;
   [SerializeField] private Button _statistic;
   
   [SerializeField] private Button _back;

   private void Start()
   {
      _store.onClick.AddListener(() => { SceneManager.LoadScene("_store");});
      _skills.onClick.AddListener(() => { SceneManager.LoadScene("_skills");});
      _eqiepments.onClick.AddListener(() => { SceneManager.LoadScene("DiscoverMenu");});
      _back.onClick.AddListener(() => { SceneManager.LoadScene("_introMenu"); });
   }
}
