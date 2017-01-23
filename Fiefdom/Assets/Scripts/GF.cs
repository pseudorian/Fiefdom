using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class GF
{
    /// <summary>
    /// Takes a SortedList of (object, int) where the key (object) is the potential result and the value (int) 
    /// is the key's weight (i.e. higher weight, more likely the chance of being selected.)<para/> 
    /// The weight is proportional to the other pairs in the list.
    /// </summary>
    public static T WeightedRandom<T>(SortedList<T,int> list)
    {
        int totalWeight = 0;
        foreach(KeyValuePair<T,int> pair in list)
        {
            totalWeight += pair.Value;

            //Set pair's value to the current totalWeight value for comparison purposes when determining the result to return.
            list[pair.Key] = totalWeight;
        }

        int randNum = Random.Range(0,totalWeight + 1);

        foreach(KeyValuePair<T,int> pair in list)
        {
            if(randNum <= pair.Value)
                return pair.Key;
        }

        //In case of no match, return default (often null).
        return default(T);
    }

    public static T WeightedRandom<T>(SortedList<T,float> list)
    {
        float totalWeight = 0;
        foreach(KeyValuePair<T,float> pair in list)
        {
            totalWeight += pair.Value;

            //Set pair's value to the current totalWeight value for comparison purposes when determining the result to return.
            list[pair.Key] = totalWeight;
        }

        float randNum = Random.Range(0,totalWeight + 0.1f);

        //Catches if float goes beyond totalWeight (due to nature of Random.Rnage()).
        if(randNum > totalWeight)
            randNum = totalWeight;

        foreach(KeyValuePair<T,float> pair in list)
        {
            if(randNum <= pair.Value)
                return pair.Key;
        }

        //In case of no match, return default (often null).
        return default(T);
    }
}
