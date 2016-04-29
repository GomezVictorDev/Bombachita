using UnityEngine;
using System.Collections;

public class Bomb : Observer {

	// Use this for initialization
	string owner;
	const float bombTime=0.1f;
	public float actualTime;
	CountDown globalTimer;

	public enum BombStates{ initial,explode,tenSeconds,fiveSeconds }
	public static BombStates bombState;

	public Bomb()
	{
		globalTimer =(CountDown) TimeController.Instance.GetCountDown;
		bombState = BombStates.initial;
		owner="default";
		actualTime=0;

	}

	public string Owner
	{
		get{return owner; }
		set
		{
			owner = value;
			Debug.Log ("Actual Owner: " + owner);
		}
		
	}

	public void UpdateObserver()
	{
		
		actualTime = globalTimer.GetActualValue;
//		Debug.Log("actual time: "+actualTime);
		//GlobalTimer

		if(actualTime<bombTime)
		{
			Explote ();
			//detener los inputs
			
		}
	
	}

	private void Explote()
	{
		bombState = BombStates.explode;
		Debug.Log ("State: "+bombState);
		Debug.Log ("Perdedor: " + owner);
		//lo que pase al explotar la bomba
	}


}
