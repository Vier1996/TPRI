using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Infected_And_Dead_Counter
{
    private static _Infected_And_Dead_Counter instance;
    private int countDead, countInfected, _currentIllInfected;
    private int fatality;
    private int LivePeople;

    private _Infected_And_Dead_Counter()
    {
        countDead = countInfected = 0;
    }

    public static _Infected_And_Dead_Counter getInstance()
    {
        if (instance == null)
        {
            instance = new _Infected_And_Dead_Counter();
        }

        return instance;
    }

    /*private void setCountDead(int dead)
    {
        countDead += dead;
    }

    private void setCountInfected(int infected)
    {
        countInfected += infected;
    }*/

    public void countInfectedPeople(int infection, int population)
    {
        int rate = 0, infected = 0;
        for (int i = 0; i < population; i++)
        {
            rate = Random.Range(0, 101);
            if (rate <= infection)
            {
                infected++;
            }
        }
        
        CountDead(fatality, infected);

        countInfected += infected;
    }

    public void CountDead(int fatal, int infected)
    {
        int rate = 0, dead = 0;
        for (int i = 0; i < infected; i++)
        {
            rate = Random.Range(0, 101);
            if (rate <= fatal)
            {
                dead++;
            }
        }

        countDead += dead;
        _GameController.Population -= dead;
    }

    public int getInfected()
    {
        return countInfected;
    }

    public int getDead()
    {
        return countDead;
    }

    public int getPopulation()
    {
        return 1;
    }

    public void setFatality(int fatality)
    {
        this.fatality = fatality;
    }
}
