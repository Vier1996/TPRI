using UnityEngine;


public class _DropProgress
{
    public static void Drop()
    {
        PlayerPrefs.SetInt(_ResourceKeys.Money, 0);
        PlayerPrefs.SetInt(_ResourceKeys.CharacterLevel, 0);
        PlayerPrefs.SetInt(_ResourceKeys.skills, 0);
    }

    public static void DropResources()
    {
        PlayerPrefs.SetInt(_ResourceKeys.Mixture, 0);
        PlayerPrefs.SetInt(_ResourceKeys.Tincture, 0);
        PlayerPrefs.SetInt(_ResourceKeys.Healing_salve, 0);
        PlayerPrefs.SetInt(_ResourceKeys.Candy, 0);
        PlayerPrefs.SetInt(_ResourceKeys.Panacea, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Bunch_of_rosemary, 0);
        PlayerPrefs.SetInt(_ResourceKeys.Orchid_Leaf, 0);
        PlayerPrefs.SetInt(_ResourceKeys.Gargoyle_saliva, 0);
        PlayerPrefs.SetInt(_ResourceKeys.Ginger_root, 0);
        PlayerPrefs.SetInt(_ResourceKeys.Liver_eel, 0);
    }
}

