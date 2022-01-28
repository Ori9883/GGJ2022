using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : StaticInstance<ObserverManager>
{
    List<Observer> observersList = new List<Observer>();

    public void Addobserver(Observer ob)
    {
        observersList.Add(ob);
    }

    public void RemoveObserver(Observer ob)
    {
        observersList.Remove(ob);
    }

    public void Noitfy()
    {
        foreach(var child in observersList)
        {
            child.NotifyChange();
        }
    }
}
