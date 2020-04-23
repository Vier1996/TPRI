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

    public static void DporBestiarii(int Open)
    {
        PlayerPrefs.SetInt(_ISSUESKEY.простуда, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.чесотка, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.мигрень, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.гастрит, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.гепатит, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.грипп, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.тубиркулез, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.корь, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.бронхит, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.язва, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.менингит, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.коронавирус, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.пневмония, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.рак, Open);
        PlayerPrefs.SetInt(_ISSUESKEY.цинга, Open);
    }

    public static void DropSymptomys(int Open)
    {
        PlayerPrefs.SetInt(_SYMPTOMESKEY.боль_в_глазах, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.боль_в_животе, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.боль_в_теле, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.боль_в_ушах, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.выпадение_зубов, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.головная_боль, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.голодные_боли_в_животе, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.голодные_боли_в_животе, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.горечь_во_рту, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.длительный_кашель, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.зуд, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.изжога, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.кашель, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.кровоточивость_десен, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.лающий_кашель, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.насморк, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.отсутсвие_аппетита, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.отсутсвие_обоняния, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.першение_в_горле, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.потеря_веса, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.рвота, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.сильная_головная_боль, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.сильная_слабость, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.слабость, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.сыпь, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.температура, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.тошнота, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.утомаляемость, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.характерная_сыпь, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.сильная_боль_в_животе, Open);
        PlayerPrefs.SetInt(_SYMPTOMESKEY.боль_в_горле, Open);
    }

    public static void DropEquipments()
    {
        PlayerPrefs.SetInt("Helmet_upg1", 0);
        PlayerPrefs.SetInt("Helmet_upg2", 0);
        PlayerPrefs.SetInt("Helmet_upg3", 0);
        
        PlayerPrefs.SetInt("Mask_upg1", 0);
        PlayerPrefs.SetInt("Mask_upg2", 0);
        PlayerPrefs.SetInt("Mask_upg3", 0);
        
        PlayerPrefs.SetInt("Gloves_upg1", 0);
        PlayerPrefs.SetInt("Gloves_upg2", 0);
        PlayerPrefs.SetInt("Gloves_upg3", 0);
        
        PlayerPrefs.SetInt("Butcher_upg1", 0);
        PlayerPrefs.SetInt("Butcher_upg2", 0);
        PlayerPrefs.SetInt("Butcher_upg3", 0);
        
        PlayerPrefs.SetInt("Suit_upg1", 0);
        PlayerPrefs.SetInt("Suit_upg2", 0);
        PlayerPrefs.SetInt("Suit_upg3", 0);
        
        PlayerPrefs.SetInt("Boots_upg1", 0);
        PlayerPrefs.SetInt("Boots_upg2", 0);
        PlayerPrefs.SetInt("Boots_upg3", 0);
    }

    public static void DropAchive()
    {
        PlayerPrefs.SetInt(_ResourceKeys.Начинающий, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Начинающий, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Первые_шаги, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Первые_шаги, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Первопроходец, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Первопроходец, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Неудачник, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Неудачник, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Врач_от_бога, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Врач_от_бога, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Продовольствие, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Продовольствие, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Крепкий_имунитет, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Крепкий_имунитет, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Геноцид, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Геноцид, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Всезнайка, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Всезнайка, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Золотые_руки, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Золотые_руки, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Телепат, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Телепат, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Лучший_гардероб, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Лучший_гардероб, 0);
        
        PlayerPrefs.SetInt(_ResourceKeys.Решимость, 0);
        PlayerPrefs.SetInt(_ResourceKeys._Решимость, 0);

        PlayerPrefs.SetInt(_ResourceKeys.Подгончик, 1);
        PlayerPrefs.SetInt(_ResourceKeys._Подгончик, 0);
    }
}

