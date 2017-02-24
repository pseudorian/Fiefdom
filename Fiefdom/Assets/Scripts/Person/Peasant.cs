using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using People;
using Resources;

public class Peasant : Person
{
    //References
    private Builder builder;

    //Traits
    public PersonFavourites favourites;
    public PersonHealth health;
    public PersonInventory inv;
    public PersonMemory memory;
    public PersonPersonality personality;
    public PersonSkills skills;
    public PersonStatus status;

    //Work-related information
    public Task currentTask;


    void Start()
    {
        //Set up references
        builder = GetComponent<Builder>();
    }

    void Update()
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


    public Task FindWork()
    {
        Task newTask = new Task();

        return newTask;
    }
}
