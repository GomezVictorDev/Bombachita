using UnityEngine;
using System.Collections;

public class Watch : MonoBehaviour {

	// Use this for initialization
	float second=0;
	float totalSeconds=0;
	float secondForPause;
	int minute=0,hour=0;
	bool run = false;

	string watchID="default";
	public enum States
	{
		Normal,Reverse
	};
	private States watchState=States.Normal;
	void Init () {
		StopWatch ();
	}
	
	// Update is called once per frame\
	public float SetSecondsForPause
	{
		set{secondForPause = value; }
	}
	public string WatchId
	{
		get{ return watchID;}
		set{ watchID = value;}
	}
	public int GetMinute
	{
		get
		{
			return minute;
		}
	}
	public int GetHour
	{
		get
		{
			return hour;
		}
	}
	public float GetSeconds
	{
		get
		{
			return second;
		}
	}
	public float GetSecondsFromStart
	{
		get
		{
			return totalSeconds;
		}
	}
	void Update () 
	{
		if (watchState == States.Normal) 
		{
			if (run) 
			{
				second = second + Time.deltaTime;
				totalSeconds = totalSeconds + Time.deltaTime;
				if (second >= 60.0f) {
					second = 0;
					minute++;
				}
				if (minute >= 60) {
					minute = 0;
					hour++;
				}
				if (hour == 24) {
					hour = 0;
				}
			
			}
		}

		if (watchState == States.Reverse) 
		{
			if (run) 
			{
				second = second - Time.deltaTime;
				totalSeconds = totalSeconds + Time.deltaTime;
				if (second <= 0) {
					second = 59;
					if(minute>0)
					minute--;
				}
				if (minute <= 0) {
					minute = 60;
					if(hour>0)
					hour--;
				}


			}
		}
		if (totalSeconds >= secondForPause)
		{
			PauseWatch ();
		}
		//Debug.Log ("Hora:" + hour + "|Minuto:" + minute + "|Segundo:" + second);

	}
	public void ChangeState(States state)
	{
		watchState = state;
	}
	public void StartWatch()
	{
		run = true;
	}
	public void StopWatch()
	{
		second = 0;
		minute = 0;
		hour = 0;
		totalSeconds = 0;
		run = false;
	}
	public void RestartWatch()
	{
		StopWatch ();
		StartWatch();
	}
	public void PauseWatch()
	{
		
		run = false;
	}
	public void ChangeTime(int hour,int minute, float second)
	{
		this.hour = hour;
		this.minute = minute;
		this.second = second;
		
	}


}
