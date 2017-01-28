using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonTraits
{
    public int intelligence;
    public int strength;
    public int stamina;


    /// <summary>
    /// Generate a brand new person's traits with no parameters to affect their values.
    /// </summary>
    public PersonTraits()
    {
        intelligence = CalculateTrait(0, 0);
        strength = CalculateTrait(0, 0);
        stamina = CalculateTrait(0, 0);
    }

    /// <summary>
    /// Generate a person's traits using parameters to affect their values.
    /// </summary>
    /// <param name="family">The person's family.</param>
    public PersonTraits(PersonFamily family)
    {
        int fint = family.father.traits.intelligence;
        int mint = family.mother.traits.intelligence;
        int fstr = family.father.traits.strength;
        int fsta = family.father.traits.stamina;

        int intInherited = 0;
        int strInherited = 0;
        int staInherited = 0;
        int intRange = 0;
        int strRange = 0;
        int staRange = 0;

        //Father has main effect on all three traits.
        intInherited = CalculateInheritance(fint, out intRange);
        strInherited = CalculateInheritance(fstr, out strRange);
        staInherited = CalculateInheritance(fsta, out staRange);

        //Mother's effect on intelligence - create's reliance on father's intelligence, but mother's intelligence can have a massive effect.
        int mintRange = 0;
        int mintInherited = CalculateInheritance(mint, out mintRange);
        intInherited = (intInherited + mintInherited) / 2;
        if(mintRange > intRange)
            intRange += 1;
        
    }

    /// <summary>
    /// Calculates inherited value based on the parent's trait value.
    /// <para>Returns the weight modification value, outs the weight range to modify.</para>
    /// </summary>
    /// <param name="value">The parent's trait value.</param>
    /// <param name="range">Captures the trait weight range to be modified.</param>
    private int CalculateInheritance(int value, out int range)
    {
        int inheritance = 0;
        if(value < 21)
        {
            range = 0;
            inheritance = (1 / value) * 5;
        }
        else if(value >= 21 && value < 51)
        {
            range = 1;
            inheritance = (1 / (value - 20)) * 4;
        }
        else if(value >= 51 && value < 80)
        {
            range = 2;
            inheritance = (value - 50) / 6;
        }
        else
        {
            range = 3;
            inheritance = (value - 79) / 3;
        }

        return inheritance;
    }

    /// <summary>
    /// Calculates the trait's value based on inheritance from parents.
    /// </summary>
    /// /// <param name="inherited">Value to add to the weight.</param>
    /// <param name="range">Weight range to be modified.</param>
    private int CalculateTrait(int inherited, int range)
    {
        int[] weights = new int[4] {6,10,3,1};
        weights[range] += inherited;

        //Create a list with each potential trait outcome and chance to be assigned.
        SortedList<int,int> list = new SortedList<int,int>()
        {
            { Random.Range(1, 21), weights[0] } , { Random.Range(21, 51), weights[1] } ,
            { Random.Range(51, 80), weights[2] } , { Random.Range(80, 101), weights[3] }
        };

        return GF.WeightedRandom(list);
    }
}