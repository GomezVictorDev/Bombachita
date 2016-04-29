using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]

public class TimeController : MonoBehaviour {
	private static TimeController instance;


	private AudioClip clip;//los audios deberian estar en otra clase
	private AudioSource audioSource;
	private CountDown countDown;
	[SerializeField]
	private float timeClip;

	private Watch globalWatch;
	private List<Watch> watchList;


	public CountDown GetCountDown
	{
		get{return countDown; }
	}
	public static TimeController Instance
	{

		get
		{
			if (instance == null)
				instance = FindObjectOfType<TimeController> ();
			
			return instance;
		}
	}

	void Awake()
	{
		audioSource = GetComponent<AudioSource> ();
		watchList = new List<Watch> ();
		timeClip = 20f;//audioSource.clip.length;
		if (countDown == null) {
			countDown = new CountDown (timeClip);
		}
		CreateGlobalWatch ("GlobalTimer");


	
		//agregar observadores a timer

	//		obs = (Bomb)BombController.bomb;
		


	}
	private void CreateGlobalWatch(string nameId)
	{
		if(FindWatch (nameId) == null) 
		{
			string watchId=nameId;
			GameObject newWatchObject = new GameObject (watchId);
			newWatchObject.AddComponent<Watch>();
			globalWatch =newWatchObject.GetComponent<Watch> ();
			globalWatch.WatchId = watchId;
			globalWatch.StartWatch ();

		} else 
		{
			Debug.Log ("el reloj no se ha podido crear porque el nombre: " + nameId + " Ya exciste en los registros");
		}
	}
	public void CreateWatch(string nameId)
	{
		if(FindWatch (nameId) == null) 
		{
			string watchId=nameId;
			GameObject newWatchObject = new GameObject (watchId);
			newWatchObject.AddComponent<Watch>();
			Watch newWatch =newWatchObject.GetComponent<Watch> ();
			newWatch.WatchId = watchId;
			newWatch.StartWatch ();
			watchList.Add (newWatch);
		} else 
		{
			Debug.Log ("el reloj no se ha podido crear porque el nombre: " + nameId + " Ya exciste en los registros");
		}

	}
	public void CreateWatch(string nameId,int hour,int minute,int seconds)
	{
		if (FindWatch (nameId) == null) {
			string watchId = nameId;
			GameObject newWatchObject = new GameObject (watchId);
			newWatchObject.AddComponent<Watch> ();
			Watch newWatch = newWatchObject.GetComponent<Watch> ();
			newWatch.ChangeTime (hour, minute, seconds);
			newWatch.WatchId = watchId;
			newWatch.StartWatch ();
			watchList.Add (newWatch);

		} else 
		{
			Debug.Log ("el reloj no se ha podido crear porque el nombre: " + nameId + " Ya exciste en los registros");
		}

	}
	public Watch FindWatch(string nameId)
	{
		foreach (Watch watch in watchList)
		{
			if (watch.WatchId.Equals (nameId)) 
			{
				return watch;
			}
		}
		return null;
	}

	void FixedUpdate()
	{
		if (globalWatch != null) 
		{
			countDown.UpdateState (globalWatch.GetSeconds);
		}

		//Debug.Log ("timer " + myTimer.GetActualTime);
	}



}
