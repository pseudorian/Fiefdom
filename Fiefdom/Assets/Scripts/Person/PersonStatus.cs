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
                person.Die(DeathCause.hunger);
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
                person.Die(DeathCause.thirst);
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
    public void Hunger() { Hunger(WorkToughness.veryEasy); }

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
            case WorkToughness.veryEasy:
                h = 0.5f;
                break;
            case WorkToughness.easy:
                h = 0.75f;
                break;
            case WorkToughness.average:
                h = 1f;
                break;
            case WorkToughness.hard:
                h = 1.5f;
                break;
            case WorkToughness.veryHard:
                h = 2f;
                break;
            case WorkToughness.mythical:
                h = 3f;
                break;
        }

        hunger -= h;
    }

    public void SatisfyHunger(float amount)
    {
        hunger += amount;
    }


    public void Thirst() { Thirst(WorkToughness.veryEasy); }

    public void Thirst(WorkToughness workToughness)
    {
        //Thirst modification is only applied to peasants.
        if(person.GetType() != typeof(Peasant))
            return;

        float t = 0;
        switch(workToughness)
        {
            case WorkToughness.veryEasy:
                t = 0.75f;
                break;
            case WorkToughness.easy:
                t = 1f;
                break;
            case WorkToughness.average:
                t = 1.25f;
                break;
            case WorkToughness.hard:
                t = 1.5f;
                break;
            case WorkToughness.veryHard:
                t = 2.5f;
                break;
            case WorkToughness.mythical:
                t = 5f;
                break;
        }

        thirst -= t;
    }

    public void SatisfyThirst(float amount)
    {
        thirst += amount;
    }


    public void Tire() { Tire(WorkToughness.veryEasy); }

    public void Tire(WorkToughness workToughness)
    {
        //Energy modification is only applied to peasants.
        if(person.GetType() != typeof(Peasant))
            return;

        float e = 0;
        switch(workToughness)
        {
            case WorkToughness.veryEasy:
                e = 0.25f;
                break;
            case WorkToughness.easy:
                e = 0.5f;
                break;
            case WorkToughness.average:
                e = 0.75f;
                break;
            case WorkToughness.hard:
                e = 1f;
                break;
            case WorkToughness.veryHard:
                e = 1.25f;
                break;
            case WorkToughness.mythical:
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
