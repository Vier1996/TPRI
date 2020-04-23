using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ResourceKeys : MonoBehaviour
{
    private static _ResourceKeys instance;
    
    public const string CharacterLevel = "CharacterLevel";
    public const string NeddedScore = "NeddedScore";
    public const string CurrentScore = "CurrentScore";

    public const string Money = "Key_Money";
    public const string Defense = "Key_Defense";
    public const string CityImunity = "Key_CityImunity";
    public const string Shoots = "Key_Shoots";
    public const string skills = "Ket_avaialble_skills";
    public const string Town_HealthPeople = "Town_HealthPeople";
    public const string OurDeath = "Key_OurDeath";
    public const string HealCity = "Key_HealCity";

    public const string Defense_1 = "Key_Defense_1";
    public const string Defense_2 = "Key_Defense_2";
    public const string Healing_1 = "Key_Healing_1";
    public const string Healing_2 = "Key_Healing_2";
    public const string Detection = "Key_Detection";
    public const string Researcher = "Key_Researcher";
    public const string Warning_1 = "Key_Warning_1";
    public const string Warning_2 = "Key_Warning_1";
    public const string SecondShoot_1 = "Key_SecondShoot_1";
    public const string SecondShoot_2 = "KeySecondShoot_2";
    public const string SecondShoot_3 = "Key_SecondShoot_3";
    public const string LifeCity_1 = "Key_LifeCity_1";
    public const string LifeCity_2 = "Key_LifeCity_2";
    public const string SupremeEye = "Key_SupremeEye";
    public const string FullHealing = "Key_FullHealing";

    // Олег, еще твои 5 нужны.
    public const string Mixture = "Key_Mixture";
    public const string Tincture = "Key_Tincture";
    public const string Healing_salve = "Key_Healing_salve";
    public const string Candy = "Key_Candy";
    public const string Panacea = "Key_Panacea";
    
    public const string Bunch_of_rosemary = "Key_Bunch_of_rosemary";
    public const string Orchid_Leaf = "Key_Orchid_Leaf";
    public const string Gargoyle_saliva = "Key_Gargoyle_saliva";
    public const string Ginger_root = "Key_Ginger_root";
    public const string Liver_eel = "Liver_eel";
    
    // Достижения

    public const string Начинающий = "Начинающий";
    public const string _Начинающий = "Начинающий_buyed";
    
    public const string Первые_шаги = "Первые шаги";
    public const string _Первые_шаги = "Первые шаги_buyed";
    
    public const string Первопроходец = "Первопроходец";
    public const string _Первопроходец = "Первопроходец_buyed";
    
    public const string Неудачник = "Неудачник";
    public const string _Неудачник = "Неудачник_buyed";
    
    public const string  Врач_от_бога = "Врач от бога";
    public const string _Врач_от_бога = "Врач от бога_buyed";
    
    public const string Продовольствие = "Продовольствие";
    public const string _Продовольствие = "Продовольствие_buyed";
    
    public const string Крепкий_имунитет = "Крепкий имунитет";
    public const string _Крепкий_имунитет = "Крепкий имунитет_buyed";
    
    public const string Геноцид = "Геноцид";
    public const string _Геноцид = "Геноцид_buyed";
    
    public const string Всезнайка = "Всезнайка";
    public const string _Всезнайка = "Всезнайка_buyed";
    
    public const string Золотые_руки = "Золотые руки";
    public const string _Золотые_руки = "Золотые руки_buyed";
    
    public const string Телепат = "Телепат";
    public const string _Телепат = "Телепат_buyed";
    
    public const string Лучший_гардероб = "Лучший гардероб";
    public const string _Лучший_гардероб = "Лучший гардероб_buyed";
    
    public const string Решимость = "Решимость";
    public const string _Решимость = "Решимость_buyed";
    
    public const string Подгончик = "Подгончик";
    public const string _Подгончик = "Подгончик_buyed";


    public const string Buyed_items_count = "Buyed_items_count";
    public const string Count_healed_People = "Count_healed_people";
    public const string Count_Killed = "Killed";
    
    private void Awake()
    {
        PlayerPrefs.SetInt(CharacterLevel, 1);
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void LevelUp()
    {
        PlayerPrefs.SetInt(CharacterLevel, PlayerPrefs.GetInt(CharacterLevel) + 1);
        float multiplicator = Random.Range(1.5f, 1.9f);
        PlayerPrefs.SetFloat(NeddedScore, PlayerPrefs.GetFloat(NeddedScore) + multiplicator);
        PlayerPrefs.SetInt(CurrentScore, 0);
    }
}
