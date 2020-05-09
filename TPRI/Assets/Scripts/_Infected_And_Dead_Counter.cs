using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Infected_And_Dead_Counter
{
    private static _Infected_And_Dead_Counter instance;
    private int countDead, countInfected, _currentIllInfected;
    private int fatality;
    private int LivePeople;
    _GameController gc = GameObject.FindWithTag("MainCamera").GetComponent<_GameController>();
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

    public void countInfectedPeople(int infection, int population, double immuntiy)
    {
        int rate = 0, infected = 0, people = 0;

        if (population != 0)
        {
            people = population;
            for (int i = 0; i < people; i++)
            {
                rate = Random.Range(0, 101);
                if (rate <= infection)
                {
                    infected++;
                }
            }
            
            double percentOfInfected = infected * (immuntiy / 100);
            infected = infected - (int) (percentOfInfected);

            CountDead(fatality, infected);
            countInfected += infected;
            int pop = _GameController.Population;
            gc.changeTextPopulation(pop, pop - infected, false);
            _GameController.Population -= infected;
        }
        else
        {
            people = countInfected;
            infection += 50;
            fatality += 50;
            CountDead(fatality, people);
        }

        /*for (int i = 0; i < people; i++)
        {
            rate = Random.Range(0, 101);
            if (rate <= infection)
            {
                infected++;
            }
        }

        if (population != 0)
        {
            double percentOfInfected = infected * (immuntiy / 100);
            infected = infected - (int) (percentOfInfected);

            CountDead(fatality, infected);
            countInfected += infected;
            _GameController.Population -= infected;
        }
        */

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

        countInfected -= dead;
        countDead += dead;
        /*countInfected -= dead;
        countDead += dead;
        //_GameController.Population -= dead;
        if (_GameController.Population != 0)
        {
            _GameController.Population -= dead;
            countDead += dead;
        }*/
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

    public void SetInfected(int inf)
    {
        countInfected = inf;
    }

    public void setFatality(int fatality)
    {
        this.fatality = fatality;
    }
}
