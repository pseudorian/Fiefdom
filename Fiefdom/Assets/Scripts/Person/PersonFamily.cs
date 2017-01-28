using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonFamily
{
    public Person father { get { return father; } private set { father = value; } }
    public Person mother { get { return mother; } private set { mother = value; } }
    public Person spouse { get { return spouse; } private set { spouse = value; } }
    public List<Person> siblings { get { return siblings; } private set { siblings = value; } }
    public List<Person> children { get { return children; } private set { children = value; } }


    public PersonFamily() : this(null, null) {}

    public PersonFamily(Person father, Person mother) : this(father, mother, null, null, null) {}

    public PersonFamily(Person father, Person mother, Person spouse, List<Person> siblings, List<Person> children)
    {
        this.father = father;
        this.mother = mother;
        this.spouse = spouse;
        this.siblings = siblings;
        this.children = children;
    }

    /// <summary>
    /// Adds a father to the person. Only to be used for initialization purposes.
    /// </summary>
    public void AddFather(Person father)
    {
        this.father = father;
    }

    /// <summary>
    /// Adds a mother to the person. Only to be used for initialization purposes.
    /// </summary>
    public void AddMother(Person mother)
    {
        this.mother = mother;
    }

    /// <summary>
    /// Adds a spouse to the person. This does NOT marry the two people; it is used for discreet spouse addition (i.e. at initialization).
    /// </summary>
    public void AddSpouse(Person spouse)
    {
        this.spouse = spouse;
    }

    public void AddSibling(Person sibling)
    {
        siblings.Add(sibling);
    }

    /// <summary>
    /// Adds a child to the person. This does NOT give birth to the child; it is used for discreet child addition (i.e. at initialization).
    /// </summary>
    public void AddChild(Person child)
    {
        children.Add(child);
    }


    /// <summary>
    /// Marries this person to another, generating a marriage event, the scope of which is determined by some factors.
    /// </summary>
    public void Marry(Person spouse)
    {
        AddSpouse(spouse);
    }
}
