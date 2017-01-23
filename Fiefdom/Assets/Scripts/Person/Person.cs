using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using People;

public class Person : MonoBehaviour
{
    //Global traits to all people
    public new PersonName name;     //Use "gameObject.name" to get the Game Object's name.
    public PersonFamily family;
    public PersonTraits traits;
    public Gender gender;
    public float age;
    //pseudo: public building home
    

    //Pathfinding
    private AIPath pathing;

    protected void SetPathTarget(Transform target)
    {
        pathing.target = target;
    }

    
    public void Die(DeathCause cause)
    {
        
    }
}
