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
                    /*"Простуда",
                    "Гастрит",
                    "Мигрень",
                    "HEALTHY",
                    "Чесотка"*/
                    "Туберкулез",
                    "Туберкулез",
                    "Туберкулез",
                    "Туберкулез",
                    "Туберкулез"
                }
            },
            {
                "_level_2", new List<string>()
                {
                    "Бронхит",
                    "HEALTHY",
                    "Гепатит",
                    "Гастрит",
                    "HEALTHY",
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
                    "HEALTHY",
                    "Туберкулез",
                    "Мигрень",
                    "Язва",
                    "HEALTHY",
                    "Пневмония",
                    "Гепатит",
                    "HEALTHY"
                }
            },
            {
                "_level_4", new List<string>()
                {
                    "Гастрит",
                    "Менингит",
                    "Мигрень",
                    "HEALTHY",
                    "Чесотка",
                    "Простуда",
                    "HEALTHY",
                    "Язва",
                    "Грипп",
                    "HEALTHY",
                    "Туберкулез",
                    "Грипп"
                }
            },
            {
                "_level_5", new List<string>()
                {
                    "HEALTHY",
                    "Мигрень",
                    "Менингит",
                    "Корь",
                    "Чесотка",
                    "Простуда",
                    "Пневмония",
                    "HEALTHY",
                    "Грипп",
                    "Менингит",
                    "Туберкулез",
                    "Коронавирус",
                    "Язва",
                    "Бронхит",
                    "HEALTHY"
                }
            },
            {
                "_level_6", new List<string>()
                {
                    "Менингит",
                    "Простуда",
                    "Менингит",
                    "Корь",
                    "HEALTHY",
                    "Гепатит",
                    "Пневмония",
                    "Рак",
                    "Грипп",
                    "HEALTHY",
                    "HEALTHY",
                    "Коронавирус",
                    "Язва",
                    "Цинга",
                    "HEALTHY",
                    "Рак",
                    "Пневмония",
                    "Простуда"
                }
            },
            {
            "_level_7", new List<string>()
            {
                "Коронавирус",
                "HEALTHY",
                "Менингит",
                "HEALTHY",
                "Чесотка",
                "Корь",
                "Гепатит",
                "Рак",
                "HEALTHY",
                "Язва",
                "Туберкулез",
                "Цинга",
                "Корь",
                "HEALTHY",
                "Пневмония",
                "Рак",
                "HEALTHY",
                "Коронавирус",
                "Менингит",
                "HEALTHY",
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