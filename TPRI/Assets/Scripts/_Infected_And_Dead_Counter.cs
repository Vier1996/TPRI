using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Infected_And_Dead_Counter
{
    private static _Infected_And_Dead_Counter instance;
    private int countDead, countInfected, _currentIllInfected;
    private int fatality;

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

    private void setCountDead(int dead)
    {
        countDead += dead;
    }

    private void setCountInfected(int infected)
    {
        countInfected += infected;
    }

    public void countDeadPeople(int fatality, int population)
    {
        int buf = _currentIllInfected - (_currentIllInfected*(fatality / 100));
        population -= buf;
        _GameController.Population -= population;
        countInfected -= buf;
        setCountDead(buf);
    }

    public void countInfectedPeople(int infection, int population, bool cycle)
    {
        int rate = 0;
        for (int i = 0; i < population; i++)
        {
            rate = Random.Range(0, 101);
            if (rate <= infection)
            {
                countInfected++;
            }
        }

        if (!cycle)
        {
            countInfectedPeople(fatality, countInfected, true);
        }

        if (cycle)
        {
            population -= countInfected;
            _GameController.Population = population;
            countInfected = 0;
        }
        //countDeadPeople();
    }

    public int getInfected()
    {
        return countInfected;
    }

    public int getDead()
    {
        return countDead;
    }

    public void setNPC(int fatality)
    {
        this.fatality = fatality;
    }
}
