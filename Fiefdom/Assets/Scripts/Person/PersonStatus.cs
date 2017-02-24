using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using People;

public class PersonStatus
{
    //Reference to person
    private Person person;

    /// <summary>
    /// Hunger level of person. -100 = starve to death, 0 = starving, 100 = full
    /// </summary>
    public float hunger
    {
        get { return hunger; }
        private set
        {
            if(value > 0)
                hunger = value;
            else
                person.Die(DeathCause.Hunger);
        }
    }

    /// <summary>
    /// Thirst level of person. -100 = die of thirst, 0 = thirsty, 100 = slaked
    /// </summary>
    public float thirst
    {
        get { return thirst; }
        private set
        {
            if(value > 0)
                thirst = value;
            else
                person.Die(DeathCause.Thirst);
        }
    }

    /// <summary>
    /// Energy level of person. 0 = passing out, 100 = energetic
    /// </summary>
    public float energy
    {
        get { return energy; }
        private set
        {
            energy = value;
        }
    }

    /// <summary>
    /// Happiness level of person. 0 = unhappy, 100 = happy
    /// </summary>
    public float happiness
    {
        get { return happiness; }
        private set
        {
            happiness = value;
        }
    }

    /// <summary>
    /// Inebriation level of person. 0 = sober, 100 = drunk
    /// </summary>
    public float inebriation
    {
        get { return inebriation; }
        private set
        {
            inebriation = value;
        }
    }


    public PersonStatus(Person person)
    {
        //Initialize base status - perhaps later, should be slightly randomized or based on other variables.
        hunger = 100f;
        thirst = 100f;
        energy = 100f;
        happiness = 100f;
        inebriation = 100f;

        this.person = person;
    }


    /// <summary>
    /// Add hunger to person. Use no argument to imply the person is doing nothing or very little.
    /// <para>Only to be used with Peasants.</para>
    /// </summary>
    public void Hunger() { Hunger(WorkToughness.VeryEasy); }

    /// <summary>
    /// Add hunger to person. Use no argument to imply the person is doing nothing or very little.
    /// <para>Only to be used with Peasants.</para>
    /// </summary>
    /// <param name="workToughness">The physical difficulty of the worked being performed.</param>
    public void Hunger(WorkToughness workToughness)
    {
        //Hunger modification is only applied to peasants.
        if(person.GetType() != typeof(Peasant))
            return;

        float h = 0;
        switch(workToughness)
        {
            case WorkToughness.VeryEasy:
                h = 0.5f;
                break;
            case WorkToughness.Easy:
                h = 0.75f;
                break;
            case WorkToughness.Average:
                h = 1f;
                break;
            case WorkToughness.Hard:
                h = 1.5f;
                break;
            case WorkToughness.VeryHard:
                h = 2f;
                break;
            case WorkToughness.Mythical:
                h = 3f;
                break;
        }

        hunger -= h;
    }

    public void SatisfyHunger(float amount)
    {
        hunger += amount;
    }


    public void Thirst() { Thirst(WorkToughness.VeryEasy); }

    public void Thirst(WorkToughness workToughness)
    {
        //Thirst modification is only applied to peasants.
        if(person.GetType() != typeof(Peasant))
            return;

        float t = 0;
        switch(workToughness)
        {
            case WorkToughness.VeryEasy:
                t = 0.75f;
                break;
            case WorkToughness.Easy:
                t = 1f;
                break;
            case WorkToughness.Average:
                t = 1.25f;
                break;
            case WorkToughness.Hard:
                t = 1.5f;
                break;
            case WorkToughness.VeryHard:
                t = 2.5f;
                break;
            case WorkToughness.Mythical:
                t = 5f;
                break;
        }

        thirst -= t;
    }

    public void SatisfyThirst(float amount)
    {
        thirst += amount;
    }


    public void Tire() { Tire(WorkToughness.VeryEasy); }

    public void Tire(WorkToughness workToughness)
    {
        //Energy modification is only applied to peasants.
        if(person.GetType() != typeof(Peasant))
            return;

        float e = 0;
        switch(workToughness)
        {
            case WorkToughness.VeryEasy:
                e = 0.25f;
                break;
            case WorkToughness.Easy:
                e = 0.5f;
                break;
            case WorkToughness.Average:
                e = 0.75f;
                break;
            case WorkToughness.Hard:
                e = 1f;
                break;
            case WorkToughness.VeryHard:
                e = 1.25f;
                break;
            case WorkToughness.Mythical:
                e = 2f;
                break;
        }

        energy -= e;
    }

    public void ReplenishEnergy(float amount)
    {
        energy += amount;
    }
}
