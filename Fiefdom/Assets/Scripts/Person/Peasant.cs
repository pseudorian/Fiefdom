using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using People;

public class Peasant : Person
{
    //Traits
    public PersonFavourites favourites;
    public PersonHealth health;
    public PersonInventory inv;
    public PersonMemory memory;
    public PersonPersonality personality;
    public PersonSkills skills;
    public PersonStatus status;


    public void Start()
    {
        
    }

    /// <summary>
    /// Makes a brand new peasant with no pre-determined family.
    /// </summary>
    public Peasant(Gender gender, float age)
    {
        this.gender = gender;
        this.age = age;
    }

    /// <summary>
    /// Generates a newly born peasant and sets up its pre-determined parameters.
    /// </summary>
    /// <param name="family">Current family of the peasant.</param>
    public Peasant(PersonFamily family)
    {
        this.family = family;
        status = new PersonStatus(this);
    }
}
