using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _discoverMenu : MonoBehaviour
{
    [SerializeField] Button Helmet;
    [SerializeField] Button Mask;
    [SerializeField] Button Gloves;
    [SerializeField] Button Butcher;
    [SerializeField] Button Suit;
    [SerializeField] Button Boots;
    [SerializeField] Button Back;

    [SerializeField] private GameObject HelmetMenu;
    [SerializeField] private GameObject MaskMenu;
    [SerializeField] private GameObject GlovesMenu;
    [SerializeField] private GameObject ButcherMenu;
    [SerializeField] private GameObject SuitMenu;
    [SerializeField] private GameObject BootsMenu;
    
    private int showedMenu = 0;
    
    /*
     в зависимости от нашего лвла, будут открыватся различные вариации экиперовок, + покупка их
     */
    
    void Start()
    {
        HelmetMenu.SetActive(false);
        MaskMenu.SetActive(false);
        GlovesMenu.SetActive(false);
        ButcherMenu.SetActive(false);
        SuitMenu.SetActive(false);
        BootsMenu.SetActive(false);
        
        Helmet.onClick.AddListener(() =>
        {
            if (HelmetMenu.activeSelf)
            {
                HelmetMenu.SetActive(false);
            }
            else
            {
                Deact();
                HelmetMenu.SetActive(true);
                showedMenu = 1;
            }
        });
        
        Mask.onClick.AddListener(() =>
        {
            if (MaskMenu.activeSelf)
            {
                MaskMenu.SetActive(false);
            }
            else
            {
                Deact();
                MaskMenu.SetActive(true);
                showedMenu = 2;
            }
        });
        
        Gloves.onClick.AddListener(() =>
        {
            if (GlovesMenu.activeSelf)
            {
                GlovesMenu.SetActive(false);
            }
            else
            {
                Deact();
                GlovesMenu.SetActive(true);
                showedMenu = 3;
            }
        });
        
        Butcher.onClick.AddListener(() =>
        {
            if (ButcherMenu.activeSelf)
            {
                ButcherMenu.SetActive(false);
            }
            else
            {
                Deact();
                ButcherMenu.SetActive(true);
                showedMenu = 4;
            }
        });
        
        Suit.onClick.AddListener(() =>
        {
            if (SuitMenu.activeSelf)
            {
                SuitMenu.SetActive(false);
            }
            else
            {
                Deact();
                SuitMenu.SetActive(true);
                showedMenu = 5;
            }
        });
        
        Boots.onClick.AddListener(() =>
        {
            if (BootsMenu.activeSelf)
            {
                BootsMenu.SetActive(false);
            }
            else
            {
                Deact();
                BootsMenu.SetActive(true);
                showedMenu = 6;
            }
        });
        
        Back.onClick.AddListener(() => { SceneManager.LoadScene("_home"); });
    }

    private void Deact()
    {
        switch (showedMenu)
        {
            case 1: HelmetMenu.SetActive(false); break;
            case 2: MaskMenu.SetActive(false); break;
            case 3: GlovesMenu.SetActive(false); break;
            case 4: ButcherMenu.SetActive(false); break;
            case 5: SuitMenu.SetActive(false); break;
            case 6: BootsMenu.SetActive(false); break;
            default: break;
        }
    }
}
