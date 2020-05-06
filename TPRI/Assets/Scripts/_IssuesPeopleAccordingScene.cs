using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _IssuesPeopleAccordingScene
{
    private static Dictionary<string, List<string>> issues;
    private static Dictionary<string, int> countNPCAccordingLevel;

    public static string getIssue(int index, string scene)
    {
        setDictionary();
        return issues[scene][index];
    }

    private static void setDictionary()
    {
        issues = new Dictionary<string, List<string>>
        {
            {
                "_level_1", new List<string>()
                {
                    //"Простуда",
                    "Коронавирус",
                    "Коронавирус",
                    //"Гастрит",
                    "Мигрень",
                    "Грипп",
                    "Чесотка"
                }
            },
            {
                "_level_2", new List<string>()
                {
                    "Бронхит",
                    "Простуда",
                    "Гепатит",
                    "Гастрит",
                    "Гепатит",
                    "Чесотка",
                    "Грипп"
                }
            },
            {
                "_level_3", new List<string>()
                {
                    "Простуда",
                    "Гастрит",
                    "Мигрень",
                    "Грипп",
                    "Чесотка",
                    "Простуда",
                    "Туберкулез",
                    "Мигрень",
                    "Язва",
                    "Пневмония",
                    "Гепатит",
                    "Грипп"
                }
            },
            {
                "_level_4", new List<string>()
                {
                    "Гастрит",
                    "Менингит",
                    "Мигрень",
                    "Грипп",
                    "Чесотка",
                    "Простуда",
                    "Пневмония",
                    "Язва",
                    "Грипп",
                    "Менингит",
                    "Туберкулез",
                    "Грипп"
                }
            },
            {
                "_level_5", new List<string>()
                {
                    "Простуда",
                    "Мигрень",
                    "Менингит",
                    "Корь",
                    "Чесотка",
                    "Простуда",
                    "Пневмония",
                    "Корь",
                    "Грипп",
                    "Менингит",
                    "Туберкулез",
                    "Коронавирус",
                    "Язва",
                    "Бронхит",
                    "Пневмония"
                }
            },
            {
                "_level_6", new List<string>()
                {
                    "Менингит",
                    "Простуда",
                    "Менингит",
                    "Корь",
                    "Чесотка",
                    "Гепатит",
                    "Пневмония",
                    "Рак",
                    "Грипп",
                    "Язва",
                    "Туберкулез",
                    "Коронавирус",
                    "Язва",
                    "Цинга",
                    "Гастрит",
                    "Рак",
                    "Пневмония",
                    "Простуда"
                }
            },
            {
            "_level_7", new List<string>()
            {
                "Коронавирус",
                "Язва",
                "Менингит",
                "Простуда",
                "Чесотка",
                "Корь",
                "Гепатит",
                "Рак",
                "Грипп",
                "Язва",
                "Туберкулез",
                "Цинга",
                "Корь",
                "Чесотка",
                "Пневмония",
                "Рак",
                "Пневмония",
                "Коронавирус",
                "Менингит",
                "Простуда",
            }
        }
        };
    }

    private static void setCountNPC()
    {
        countNPCAccordingLevel = new Dictionary<string, int>
        {
            {"_level_1", 5},
            {"_level_2", 7},
            {"_level_3", 12},
            {"_level_4", 12},
            {"_level_5", 15},
            {"_level_6", 18},
            {"_level_7", 20}
        };
    }

    public static int getCountNPC(string scene)
    {
        setCountNPC();
        return countNPCAccordingLevel[scene];
    }
}