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
   [SerializeField] private string SkillPrice;
   private Button acceptBrn;

   public bool reserched = false;

   private GameObject _skillDialog;

   private void Start()
   {
      if(PlayerPrefs.GetInt(SkillsPath) == 0)
         GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
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
      _skillDialog.GetComponent<_skillDialogController>().setPrice(SkillPrice);
      acceptBrn = _skillDialog.GetComponent<_skillDialogController>().GetButton();
      
      acceptBrn.onClick.AddListener(() =>
      {
         if ( _skillDialog.GetComponent<_skillDialogController>().GetName().Equals(SkillsName))
         {
            if (PlayerPrefs.GetInt(SkillsPath) != 1)
            {
               if (PlayerPrefs.GetInt(_ResourceKeys.skills) >= Int32.Parse(SkillPrice))
               {
                  Debug.Log(SkillsName);
                  PlayerPrefs.SetInt(SkillsPath, 1);
                  GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 2);
                  reserched = true;
                  PlayerPrefs.SetInt(_ResourceKeys.skills, PlayerPrefs.GetInt(_ResourceKeys.skills) - Int32.Parse(SkillPrice));
               }
            }
         }
      });
   }
   
}
