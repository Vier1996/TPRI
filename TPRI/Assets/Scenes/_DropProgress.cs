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

    public static void DropSkills()
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

        PlayerPrefs.SetInt("pass_1_skl", 0);
        PlayerPrefs.SetInt("pass_2_skl", 0);
        PlayerPrefs.SetInt("pass_3_skl", 0);
        PlayerPrefs.SetInt("pass_4_skl", 0);
        PlayerPrefs.SetInt("pass_5_skl", 0);
        PlayerPrefs.SetInt("pass_6_skl", 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Defense, 0);
        PlayerPrefs.SetInt(_ResourceKeys.CityImunity, 0);
        PlayerPrefs.SetInt(_ResourceKeys.Shoots, 0);
    }
}

