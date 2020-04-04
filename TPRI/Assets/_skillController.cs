using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class _skillController : MonoBehaviour
{
   [SerializeField] private string SkillsPath;
   [SerializeField] private string SkillsName;
   [SerializeField] private string SkillsDescription;
   private Button acceptBrn;

   private GameObject _skillDialog;

   private void Start()
   {
      GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
      GetComponent<Button>().onClick.AddListener(() =>
      {
         Initialize();
      });
   }

   private void Initialize()
   {
      _skillDialog = GameObject.FindGameObjectWithTag("_SklsDlg");
      _skillDialog.GetComponent<_skillDialogController>().setName(SkillsName);
      _skillDialog.GetComponent<_skillDialogController>().setDescription(SkillsDescription);
      acceptBrn = _skillDialog.GetComponent<_skillDialogController>().GetButton();
      
      acceptBrn.onClick.AddListener(() =>
      {
         if ( _skillDialog.GetComponent<_skillDialogController>().GetName().Equals(SkillsName))
         {
            Debug.Log(SkillsName);
            PlayerPrefs.SetInt(SkillsPath, 1);
            GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 2);
         }
      });
   }
   
}
