using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonName
{
    public string first
    {
        get { return first; }
        private set { first = value; }
    }
    public string sur
    {
        get { return sur; }
        private set { sur = value; }
    }
    public string nick
    {
        get { return nick; }
        private set { nick = value; }
    }

    
    public PersonName(string first, string sur)
    {
        this.first = first;
        this.sur = sur;
    }

    public void ChangeSurname(string newSurname)
    {
        sur = newSurname;
    }
}
