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
               "Простуда",
               "Гастрит",
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
               "Менингит",
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
               "Чесотка"
            }
         },
         {
            "_level_4", new List<string>()
            {
               "Простуда",
               "Гастрит",
               "Мигрень",
               "Грипп",
               "Чесотка"
            }
         }
      };
   }

   private static void setCountNPC()
   {
      countNPCAccordingLevel = new Dictionary<string, int> {{"_level_1", 5}, {"_level_2", 7}};
   }

   public static int getCountNPC(string scene)
   {
      setCountNPC();
      return countNPCAccordingLevel[scene];
   }
}
