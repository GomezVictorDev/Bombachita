using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace  observerPattern{
public class Subject  {

	// Use this for initialization
	Observer observer;
	List<Observer> observers;

	public void AddObserver(ref Observer newObserver)
	{
		observer = newObserver;

	}
	public void AddObservers(ref Observer newObserver)
	{
		if (observers == null)
		{
			observers = new List<Observer> ();
		}
		observers.Add (newObserver);
	}
	public void DeleteObserver(ref Observer observer)
	{
		
		if (observer != null)
		{
			observer =null;
		}
		if (observers != null)
		{
			observers.Remove (observer);
		}
	}
	public void Notify()
	{
		if (observer != null)
		{
			observer.UpdateObserver ();
		}
	
	}
}
}